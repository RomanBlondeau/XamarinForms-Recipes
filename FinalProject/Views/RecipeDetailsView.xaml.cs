using System;
using System.Collections.Generic;

using FinalProject.Models;
using FinalProject.ViewModels;
using Xamarin.Forms;

namespace FinalProject.Views
{
    public partial class RecipeDetailsView : ContentPage
    {
        private RecipeClass recipe;
        public RecipeDetailsView()
        {
            InitializeComponent();
            BindingContext = RecipeViewModel._viewModelInstance;
        }

        public RecipeDetailsView(RecipeClass recipe)
        {
            this.recipe = recipe;
            InitializeComponent();
            BindingContext = RecipeViewModel._viewModelInstance;
            var vm = BindingContext as RecipeViewModel;
            vm.getRecipeDetails(recipe);
            if (vm.IsFavorite(recipe.Uri.ToString()) == true)
            {
                FavoriteButton.Source = "fav.png";
            }
            else
            {
                FavoriteButton.Source = "fav_border.png";
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var vm = BindingContext as RecipeViewModel;
            var fav = new Favorite
            {
                Id = recipe.Uri.ToString(),
                Name = recipe.Label,
                PhotoUrl = recipe.Image.ToString()
            };
            vm.AddToFavorite(fav);
        }
    }
}
