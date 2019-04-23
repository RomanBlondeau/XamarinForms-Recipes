using System;
using System.Net.Http;
using FinalProject.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace FinalProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            HandleRecipe();
            HandleCocktail();
        }

        async void HandleRecipe()
        {
            var client = new HttpClient();
            var apiAddress = "https://api.edamam.com/search?q=best&app_id=29e734df&app_key=dde9178172fd1f5797053d93a0d58b2b";
            var uri = new Uri(apiAddress);

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Recipe>(jsonContent);
            }
        }

        async void HandleCocktail()
        {
            var client = new HttpClient();
            var apiAddress = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?a=Alcoholic";
            var uri = new Uri(apiAddress);

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Cocktail>(jsonContent);
            }
        }
    }
}
