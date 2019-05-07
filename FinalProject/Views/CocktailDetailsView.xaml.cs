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
            //vm.IsFavorite(cocktail.Uri.ToString());
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            //    var vm = BindingContext as CocktailViewModel;
            //    var fav = new Favorite();
            //    fav.Id = recipe.Uri.ToString();
            //    fav.Name = recipe.Label;
            //    fav.PhotoUrl = recipe.Image.ToString();
            //    vm.AddToFavorite(fav);
            //}

            //void HandleRecipeLink(object sender, System.EventArgs e)
            //{
            //    var vm = BindingContext as CocktailViewModel;
            //    vm.HandleRecipeLink.Execute("viewRecipe");
        }
    }
}
