using PPE4_3.Modeles;
using PPE4_3.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PPE4_3.VueModeles
{
    class ListeRestaurantVueModele : BaseVueModele
    {
        #region Attributs
        private ObservableCollection<Restaurant> _lesRestaurants;
        private Restaurant _leRestaurant;
        private string _nomTypeCuisine;
        #endregion

        #region Constructeur
        public ListeRestaurantVueModele(TypeCuisine leTypeCuisine)
        {
            LesRestaurants = new ObservableCollection<Restaurant>(leTypeCuisine.LesRestaurants);
            CommandeButtonRestaurants = new Command(ActionRestaurants);
        }
        public ListeRestaurantVueModele()
        {
            LesRestaurants = new ObservableCollection<Restaurant>(Restaurant.CollClasse);
            CommandeButtonRestaurants = new Command(ActionRestaurants);
        }
        #endregion

        #region Getters-Setters
        public ICommand CommandeButtonRestaurants { get; }
        public ObservableCollection<Restaurant> LesRestaurants
        {
            get => _lesRestaurants;
            set => SetProperty(ref _lesRestaurants, value);
        }
        public Restaurant LeRestaurant
        {
            get => _leRestaurant;
            set
            {
                SetProperty(ref _leRestaurant, value);
                this.ActionRestaurants();
            }
        }
        public string NomTypeCuisine { get => _nomTypeCuisine; set => _nomTypeCuisine = value; }
        #endregion

        #region Méthodes
        public void ActionRestaurants() => Device.BeginInvokeOnMainThread(() => Application.Current.MainPage = new NavigationPage(new RestaurantVue(LeRestaurant)));
        #endregion
    }
}
