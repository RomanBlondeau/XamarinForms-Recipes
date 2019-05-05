using System;
using System.Collections.Generic;
using FinalProject.Models;
using FinalProject.ViewModels;
using SQLite;
using Xamarin.Forms;

namespace FinalProject.Views
{
    public partial class FavoriteView : ContentPage
    {
        public FavoriteView()
        {
            InitializeComponent();
            BindingContext = FavoriteViewModel.ViewModelInstance;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Favorite fav = new Favorite();
            fav.Id = "http://www.edamam.com/ontologies/edamam.owl#recipe_c10b255970c1f8feb70719c7cfa42ef9";
            fav.Name = "The Best Hot Chocolate Ever";
            fav.PhotoUrl = "https://www.edamam.com/web-img/eec/eec32294f7fc04639f2ee8a3f351d0ed.jpg";
            var vm = BindingContext as FavoriteViewModel;
            vm.InsertFavorite(fav);
        }

        void Handle_Clicked_Remove(object sender, System.EventArgs e)
        {
            var vm = BindingContext as FavoriteViewModel;
        }
    }
}
