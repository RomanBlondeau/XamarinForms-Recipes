using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FinalProject.Models;

using Xamarin.Forms;

namespace FinalProject.ViewModels
{
    public class RecipeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static RecipeViewModel _viewModelInstance;
        Database database = new Database();

        private string _appId = "&app_id=29e734df&app_key="; // add app_key
        private string _apiAdress = "https://api.edamam.com/search?q=";

        public List<Hit> _recipeListView { get; set; }
        public string _loadingBackgroundColor { get; set; }
        public string _loadingText { get; set; }
        public string _search { get; set; }
        public string _mainLabel { get; set; }
        public bool _activityIndicatorRunning { get; set; }

        public RecipeClass                          _recipeDetails { get; set; }
        public string                               _recipeImage { get; set; }
        public string                               _recipeTitle { get; set; }
        public string                               _recipeAuthor { get; set; }
        public string                               _recipeLink { get; set; }
        public string                               _recipeCalories { get; set; }
        public List<string>                         _recipeHealthLabels { get; set; }
        public List<string>                         _recipeIngredients { get; set; }

        public RecipeViewModel()
        {
            _viewModelInstance = this;
            _recipeListView = new List<Hit>();
            _loadingBackgroundColor = "#fff";
            _loadingText = "Search";
            _search = "";
            _mainLabel = "Top recipes";
            _activityIndicatorRunning = false;
            _ = SearchBestRecipes();
        }

        public void getRecipeDetails(RecipeClass recipe)
        {
            _recipeDetails = recipe;
            _recipeImage = recipe.Image.ToString();
            _recipeTitle = recipe.Label;
            _recipeAuthor = recipe.Source;
            _recipeLink = recipe.Url.ToString();
            _recipeHealthLabels = recipe.HealthLabels;
            _recipeIngredients = recipe.IngredientLines;
            _recipeCalories = recipe.Calories.ToString();

            OnPropertyChanged("_recipeImage");
            OnPropertyChanged("_recipeTitle");
            OnPropertyChanged("_recipeAuthor");
            OnPropertyChanged("_recipeHealthLabels");
            OnPropertyChanged("_recipeIngredients");
            OnPropertyChanged("_recipeCalories");
        }

        public Command HandleSearchCommand => new Command(async (e) => {
            if (e.ToString() != "search")
            {
                _search = e.ToString();
                OnPropertyChanged("_search");
            }
            await SearchRecipes();
        });

        public Command HandleRecipeLink => new Command(() => {
            Device.OpenUri(new System.Uri(_recipeLink));
        });

        async Task SearchRecipes()
        {
            _recipeListView = new List<Hit>();
            OnPropertyChanged("_recipeListView");
            _mainLabel = "";
            OnPropertyChanged("_mainLabel");

            Loading();
            await GetRecipes();
            Loading();

            _mainLabel = "Results for: " + _search;
            OnPropertyChanged("_mainLabel");
        }

        async Task GetRecipes()
        {
            var client = new HttpClient();
            var apiAddress = _apiAdress + _search + _appId;
            var uri = new Uri(apiAddress);

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Recipe>(jsonContent);
                if (data.Hits != null)
                {
                    _recipeListView = data.Hits;
                    OnPropertyChanged("_recipeListView");
                }
            }
        }

        async Task SearchBestRecipes()
        {
            Loading();
            await GetBestRecipes();
            Loading();
        }

        async Task GetBestRecipes()
        {
            var client = new HttpClient();
            var apiAddress = _apiAdress + "best" + _appId;
            var uri = new Uri(apiAddress);

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Recipe>(jsonContent);
                if (data.Hits != null)
                {
                    _recipeListView = data.Hits;
                    OnPropertyChanged("_recipeListView");
                }
            }
        }

        private void Loading()
        {
            if (_activityIndicatorRunning == false)
            {
                _activityIndicatorRunning = true;
                OnPropertyChanged("_activityIndicatorRunning");
            }
            else
            {
                _activityIndicatorRunning = false;
                OnPropertyChanged("_activityIndicatorRunning");
            }
        }

        protected void PropertiesChanged(string[] properties)
        {
            foreach(string p in properties)
            {
                OnPropertyChanged(p);
            }
        }

        public void IsFavorite(String favoriteId)
        {
            database.CheckIsFavorite(favoriteId);
        }

        public void AddToFavorite(Favorite fav)
        {
            database.InsertFavorite(fav);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

