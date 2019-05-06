using System;
using System.Collections.Generic;
using FinalProject.ViewModels;

using Xamarin.Forms;

namespace FinalProject.Views
{
    public partial class RecipeView : ContentPage
    {
        public RecipeView()
        {
            InitializeComponent();
            var vm = BindingContext as FavoriteViewModel;
        }

        void HandleSearch(object sender, System.EventArgs e)
        {
            var vm = BindingContext as RecipeViewModel;
            vm.HandleSearchCommand.Execute("search");
        }
    }
}
