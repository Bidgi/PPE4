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
            NomTypeCuisine = string.Concat("Le type cuisine : ", leTypeCuisine.Libelle);
            LesRestaurants = new ObservableCollection<Restaurant>(leTypeCuisine.LesRestaurants);
        }
        public ListeRestaurantVueModele()
        {
            LesRestaurants = new ObservableCollection<Restaurant>(Restaurant.CollClasse);
        }
        #endregion

        #region Getters-Setters
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
                this.ActionListeRestaurants();
            }
        }
        public string NomTypeCuisine { get => _nomTypeCuisine; set => _nomTypeCuisine = value; }
        #endregion

        #region Méthodes
        /// <summary>
        /// permet de passer a la page suivante
        /// </summary>
        private void ActionListeRestaurants() => App.Current.MainPage = new RestaurantVue(LeRestaurant);
        #endregion
    }
}
