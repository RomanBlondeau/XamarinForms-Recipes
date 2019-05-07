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
        public List<string> _recipeIngredients { get; set; }
        public List<string> _recipeMeasures { get; set; }
        public string _recipeInstructions { get; set; }
        public string _recipeIsAlcoholic { get; set; }

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
            if (cocktail.strCategory != null)
                _recipeCategory = cocktail.strCategory;
            _recipeIngredients = new List<string>();
            _recipeMeasures = new List<string>();

            if (cocktail.strIngredient1 != null)
            {
                if (cocktail.strIngredient1 != "")
                    _recipeIngredients.Add(cocktail.strIngredient1);
                if (cocktail.strIngredient2 != "")
                    _recipeIngredients.Add(cocktail.strIngredient2);
                if (cocktail.strIngredient3 != "")
                    _recipeIngredients.Add(cocktail.strIngredient3);
                if (cocktail.strIngredient4 != "")
                    _recipeIngredients.Add(cocktail.strIngredient4);
                if (cocktail.strIngredient5 != "")
                    _recipeIngredients.Add(cocktail.strIngredient5);
                if (cocktail.strIngredient6 != "")
                    _recipeIngredients.Add(cocktail.strIngredient6);
                if (cocktail.strIngredient7 != "")
                    _recipeIngredients.Add(cocktail.strIngredient7);
                if (cocktail.strIngredient8 != "")
                    _recipeIngredients.Add(cocktail.strIngredient8);
                if (cocktail.strIngredient9 != "")
                    _recipeIngredients.Add(cocktail.strIngredient9);
            }
            if (cocktail.strMeasure1 != null)
            {
                if (cocktail.strMeasure1 != "")
                    _recipeMeasures.Add(cocktail.strMeasure1);
                if (cocktail.strMeasure2 != "")
                    _recipeMeasures.Add(cocktail.strMeasure2);
                if (cocktail.strMeasure3 != "")
                    _recipeMeasures.Add(cocktail.strMeasure3);
                if (cocktail.strMeasure4 != "")
                    _recipeMeasures.Add(cocktail.strMeasure4);
                if (cocktail.strMeasure5 != "")
                    _recipeMeasures.Add(cocktail.strMeasure5);
                if (cocktail.strMeasure6 != "")
                    _recipeMeasures.Add(cocktail.strMeasure6);
                if (cocktail.strMeasure7 != "")
                    _recipeMeasures.Add(cocktail.strMeasure7);
                if (cocktail.strMeasure8 != "")
                    _recipeMeasures.Add(cocktail.strMeasure8);
                if (cocktail.strMeasure9 != "")
                    _recipeMeasures.Add(cocktail.strMeasure9);
            }

            if (cocktail.strInstructions != null)
                _recipeInstructions = cocktail.strInstructions;

            if (cocktail.strAlcoholic != null)
                _recipeIsAlcoholic = cocktail.strAlcoholic;

            OnPropertyChanged("_recipeImage");
            OnPropertyChanged("_recipeTitle");
            OnPropertyChanged("_recipeIngredients");
            OnPropertyChanged("_recipeCategory");
            OnPropertyChanged("_recipeMeasures");
            OnPropertyChanged("_recipeInstructions");
            OnPropertyChanged("_recipeIsAlcoholic");
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
            var apiAddress = _apiAdressRecipe + "?s=cocktail";
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

