using System;
using System.Collections.Generic;
using FinalProject.ViewModels;
using FinalProject.Models;

using Xamarin.Forms;

namespace FinalProject.Views
{
    public partial class RecipeView : ContentPage
    {
        public RecipeView()
        {
            InitializeComponent();
            BindingContext = RecipeViewModel._viewModelInstance;
        }

        void HandleSearch(object sender, System.EventArgs e)
        {
            var vm = BindingContext as RecipeViewModel;
            vm.HandleSearchCommand.Execute("search");
        }

        void HandleDessertsSearch(object sender, System.EventArgs e)
        {
            var vm = BindingContext as RecipeViewModel;
            vm.HandleSearchCommand.Execute("dessert");
        }

        void HandleSoupsSearch(object sender, System.EventArgs e)
        {
            var vm = BindingContext as RecipeViewModel;
            vm.HandleSearchCommand.Execute("soup");
        }

        void HandlePastasSearch(object sender, System.EventArgs e)
        {
            var vm = BindingContext as RecipeViewModel;
            vm.HandleSearchCommand.Execute("pasta");
        }

        void HandleChickenSearch(object sender, System.EventArgs e)
        {
            var vm = BindingContext as RecipeViewModel;
            vm.HandleSearchCommand.Execute("chicken");
        }

        void HandleRecipeDetails(object sender, System.EventArgs e)
        {
            var recipe = (Hit)((ListView)sender).SelectedItem;
            Navigation.PushAsync(new RecipeDetailsView(recipe.Recipe));
        }
    }
}
