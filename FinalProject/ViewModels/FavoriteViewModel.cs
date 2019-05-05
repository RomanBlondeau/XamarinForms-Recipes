using System;
using System.Collections.Generic;
using System.ComponentModel;
using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class FavoriteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static FavoriteViewModel ViewModelInstance;
        Database database = new Database();
        public List<Favorite> FavoriteListView { get; set; }

        public FavoriteViewModel()
        {
            ViewModelInstance = this;
            GetFavorite();
        }

        void GetFavorite()
        {
            FavoriteListView = database.GetFavorite();
        }

        public void InsertFavorite(Favorite fav)
        {
            database.InsertFavorite(fav);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
