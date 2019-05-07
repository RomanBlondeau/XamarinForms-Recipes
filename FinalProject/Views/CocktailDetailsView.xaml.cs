using System;
using System.Collections.Generic;
using FinalProject.Models;
using FinalProject.ViewModels;
using DLToolkit.Forms.Controls;

using Xamarin.Forms;

namespace FinalProject.Views
{
    public partial class CocktailDetailsView : ContentPage
    {
        private DrinkDetail cocktails;
        public CocktailDetailsView()
        {
            InitializeComponent();
            FlowListView.Init();
            BindingContext = CocktailViewModel._viewModelInstance;
        }

        public CocktailDetailsView(DrinkDetail cocktail)
        {
            this.cocktails = cocktail;
            InitializeComponent();
            FlowListView.Init();
            BindingContext = CocktailViewModel._viewModelInstance;
            var vm = BindingContext as CocktailViewModel;
            vm.getCocktailDetails(cocktail);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var vm = BindingContext as CocktailViewModel;
            var fav = new Favorite
            {
                Id = cocktails.IdDrink,
                Name = cocktails.StrDrink,
                PhotoUrl = cocktails.StrDrinkThumb.ToString(),
                Type = "Cocktail"
            };
            vm.AddToFavorite(fav);
        }
    }
}
