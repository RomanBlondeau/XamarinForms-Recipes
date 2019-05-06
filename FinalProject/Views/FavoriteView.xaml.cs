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
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = BindingContext as FavoriteViewModel;
            vm.GetFavorite();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Favorite fav = new Favorite();
            fav.Id = "http://www.edamam.com/ontologies/edamam.owl#recipe_c10b255970c1f8feb70719c7cfa42ef";
            fav.Name = "The Best Hot Chocolate Ever II";
            fav.PhotoUrl = "https://www.edamam.com/web-img/eec/eec32294f7fc04639f2ee8a3f351d0ed.jpg";
            var vm = BindingContext as FavoriteViewModel;
            vm.InsertFavorite(fav);
        }

        void Handle_Clicked_Remove(object sender, System.EventArgs e)
        {
            var mi = (Favorite)((MenuItem)sender).CommandParameter;
            var vm = BindingContext as FavoriteViewModel;
            vm.DeleteFavorite(mi.Id);
            vm.GetFavorite();
        }
    }
}
