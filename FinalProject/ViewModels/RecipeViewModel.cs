using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FinalProject.Models;

using Xamarin.Forms;

namespace FinalProject.ViewModels
{
    public class RecipeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler    PropertyChanged;
        public static RecipeViewModel               _viewModelInstance;

        private string                              _appId = "&app_id=29e734df&app_key=dde9178172fd1f5797053d93a0d58b2b";
        private string                              _apiAdress = "https://api.edamam.com/search?q=";

        public List<Hit>                            _recipeListView { get; set; }
        public string                               _loadingBackgroundColor { get; set; }
        public string                               _loadingText { get; set; }
        public string                               _search { get; set; }

        public RecipeViewModel()
        {
            _viewModelInstance = this;
            _recipeListView = new List<Hit>();
            _loadingBackgroundColor = "#fff";
            _loadingText = "Search";
            _search = "";
        }

        public Command HandleSearchCommand => new Command(async () => { await SearchRecipes(); });

        async Task SearchRecipes()
        {
            //Loading();
            await GetRecipes();
            //if (err == true)
            //{
            //    await Handle_GetStockDailyValue();
            //}
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
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

