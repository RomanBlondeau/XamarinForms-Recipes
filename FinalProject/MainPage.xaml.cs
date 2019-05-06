using System;
using System.Net.Http;
using FinalProject.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace FinalProject
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
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
