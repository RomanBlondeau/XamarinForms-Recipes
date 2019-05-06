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
            vm.IsFavorite(recipe.Uri.ToString());
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var vm = BindingContext as RecipeViewModel;
            var fav = new Favorite();
            fav.Id = recipe.Uri.ToString();
            fav.Name = recipe.Label;
            fav.PhotoUrl = recipe.Image.ToString();
            vm.AddToFavorite(fav);
        }
    }
}
