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

        public void GetFavorite()
        {
            FavoriteListView = database.GetFavorite();
            OnPropertyChanged("FavoriteListView");
        }

        public void InsertFavorite(Favorite fav)
        {
            database.InsertFavorite(fav);
            GetFavorite();
        }

        public void DeleteFavorite(string favoriteId)
        {
            database.DeleteFavorite(favoriteId);
            GetFavorite();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
