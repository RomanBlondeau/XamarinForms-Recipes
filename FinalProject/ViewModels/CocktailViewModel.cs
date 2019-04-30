using System;
using System.ComponentModel;

using Xamarin.Forms;

namespace FinalProject.ViewModels
{
    public class CocktailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

