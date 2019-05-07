using System;
using System.Collections.Generic;
using FinalProject.ViewModels;
using FinalProject.Models;
using Xamarin.Forms;

namespace FinalProject.Views
{
    public partial class CocktailView : ContentPage
    {
        public CocktailView()
        {
            InitializeComponent();
            var vm = BindingContext as FavoriteViewModel;
        }

        void HandleSearch(object sender, System.EventArgs e)
        {
            var vm = BindingContext as CocktailViewModel;
            vm.HandleSearchCommand.Execute("search");
        }

        void HandleCosmoSearch(object sender, System.EventArgs e)
        {
            var vm = BindingContext as CocktailViewModel;
            vm.HandleSearchCommand.Execute("cosmopolitan");
        }

        void HandleGinSearch(object sender, System.EventArgs e)
        {
            var vm = BindingContext as CocktailViewModel;
            vm.HandleSearchCommand.Execute("gin");
        }

        void HandleBeachSearch(object sender, System.EventArgs e)
        {
            var vm = BindingContext as CocktailViewModel;
            vm.HandleSearchCommand.Execute("orange");
        }

        void HandleRecipeDetails(object sender, System.EventArgs e)
        {
            var cocktail = (DrinkDetail)((ListView)sender).SelectedItem;
            Navigation.PushAsync(new CocktailDetailsView(cocktail));
        }
    }
}
