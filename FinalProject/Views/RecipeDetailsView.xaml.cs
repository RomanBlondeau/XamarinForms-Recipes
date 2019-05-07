using System;
using System.Collections.Generic;
using DLToolkit.Forms.Controls;
using FinalProject.Models;
using FinalProject.ViewModels;
using Xamarin.Forms;

namespace FinalProject.Views
{
    public partial class RecipeDetailsView : ContentPage
    {
        public RecipeDetailsView()
        {
            InitializeComponent();
            FlowListView.Init();
            BindingContext = RecipeViewModel._viewModelInstance;
        }

        public RecipeDetailsView(RecipeClass recipe)
        {
            InitializeComponent();
            FlowListView.Init();
            BindingContext = RecipeViewModel._viewModelInstance;
            var vm = BindingContext as RecipeViewModel;
            vm.getRecipeDetails(recipe);
        }

        void HandleRecipeLink(object sender, System.EventArgs e)
        {
            var vm = BindingContext as RecipeViewModel;
            vm.HandleRecipeLink.Execute("viewRecipe");
        }
    }
}
