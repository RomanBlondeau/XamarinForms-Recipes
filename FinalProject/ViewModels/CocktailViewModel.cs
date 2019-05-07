using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FinalProject.Models;

using Xamarin.Forms;

namespace FinalProject.ViewModels
{
    public class CocktailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static CocktailViewModel _viewModelInstance;
        Database database = new Database();

        private string _apiAdress = "https://www.thecocktaildb.com/api/json/v1/1/filter.php";
        private string _apiAdressRecipe = "https://www.thecocktaildb.com/api/json/v1/1/search.php";

        public List<DrinkDetail> _cocktailsListView { get; set; }
        public string _loadingBackgroundColor { get; set; }
        public string _loadingText { get; set; }
        public string _search { get; set; }
        public string _mainLabel { get; set; }
        public bool _activityIndicatorRunning { get; set; }

        public DrinkDetail _recipeDetails { get; set; }
        public string _recipeImage { get; set; }
        public string _recipeTitle { get; set; }
        public string _recipeCategory { get; set; }
        //public string _recipeLink { get; set; }
        //public string _recipeCalories { get; set; }
        //public List<string> _recipeHealthLabels { get; set; }
        //public List<string> _recipeIngredients { get; set; }

        public CocktailViewModel()
        {
            _viewModelInstance = this;
            _cocktailsListView = new List<DrinkDetail>();
            _loadingBackgroundColor = "#fff";
            _loadingText = "Search";
            _search = "";
            _mainLabel = "Top cocktails";
            _activityIndicatorRunning = false;
            _ = SearchBestRecipes();
        }

        public void getCocktailDetails(DrinkDetail cocktail)
        {
            _recipeDetails = cocktail;
            _recipeImage = cocktail.StrDrinkThumb.ToString();
            _recipeTitle = cocktail.StrDrink;
            _recipeCategory = cocktail.strCategory;
            //_recipeLink = recipe.Url.ToString();
            //_recipeHealthLabels = recipe.HealthLabels;
            //_recipeIngredients = recipe.IngredientLines;
            //_recipeCalories = recipe.Calories.ToString();

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

        async Task SearchRecipes()
        {
            _cocktailsListView = new List<DrinkDetail>();
            OnPropertyChanged("_cocktailsListView");
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
            var apiAddress = _apiAdressRecipe + "?s=" + _search;
            var uri = new Uri(apiAddress);

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<CocktailDetail>(jsonContent);
                if (data.drinks != null)
                {
                    _cocktailsListView = data.drinks;
                    OnPropertyChanged("_cocktailsListView");
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
            var apiAddress = _apiAdress + "?a=Alcoholic";
            var uri = new Uri(apiAddress);

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<CocktailDetail>(jsonContent);
                if (data.drinks != null)
                {
                    _cocktailsListView = data.drinks;
                    OnPropertyChanged("_cocktailsListView");
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
            foreach (string p in properties)
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

