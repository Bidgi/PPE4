using PPE4_3.Modeles;
using PPE4_3.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PPE4_3.VueModeles
{
    class RestaurantVueModele : BaseVueModele
    {
        #region Attributs
        private Restaurant _leRestaurant;
        private List<Plat> _lesPlats;
        private List<Modeles.Menu> _lesMenus;
        private ObservableCollection<Object> _lesPlatsSelect;
        private ObservableCollection<Object> _lesMenusSelect;
        private List<Plat> _lesPlatCommand;
        private float _totalPrixCommande;
        #endregion

        #region Constructeurs
        public RestaurantVueModele(Restaurant leRestaurant)
        {
            TotalPrixCommande = 0;
            LeRestaurant = leRestaurant;
            LesPlats = leRestaurant.LesPlats;
            LesMenus = leRestaurant.LesMenus;
            CommandeButtonRestaurant = new Command(ActionPageRestaurant);
            CommandLesPlatsSelect = new Command(ActionCommandLesPlatsSelect);
            LesPlatsSelect = new ObservableCollection<object>();
            LesMenusSelect = new ObservableCollection<Object>();
            LesPlatCommand = new List<Plat>();
        }
        #endregion

        #region Getters setters
        public ICommand CommandLesPlatsSelect { get; }
        public ICommand CommandeButtonRestaurant { get; }
        public Restaurant LeRestaurant { get => _leRestaurant; set => _leRestaurant = value; }
        public List<Plat> LesPlats { get => _lesPlats; set => _lesPlats = value; }
        public List<Modeles.Menu> LesMenus { get => _lesMenus; set => _lesMenus = value; }
        public ObservableCollection<Object> LesPlatsSelect { get => _lesPlatsSelect; set => SetProperty(ref _lesPlatsSelect, value); }
        public ObservableCollection<Object> LesMenusSelect { get => _lesMenusSelect; set => SetProperty(ref _lesMenusSelect, value); }
        public List<Plat> LesPlatCommand { get => _lesPlatCommand; set => _lesPlatCommand = value; }
        public float TotalPrixCommande { get => _totalPrixCommande; set => SetProperty(ref _totalPrixCommande, value); }
        #endregion

        #region Methodes
        /// <summary>
        /// permet de calculer le prix des plat selectionner
        /// </summary>
        public float GetPrix(List<Plat> plats)
        {
            float tt = 0;
            foreach (Plat unPlat in plats) tt += unPlat.Prix;
            return tt;
        }

        /// <summary>
        /// permet de passer a la page suivante
        /// </summary>
        private void ActionPageRestaurant()
        {
            try
            {
                if (LesPlatCommand.Count > 0) App.Current.MainPage = new CommandeVue(LesPlatCommand, LeRestaurant, TotalPrixCommande);
                else App.Current.MainPage.DisplayAlert("Alerte", "Vous devez sélectionner un plat pour accéder au récapitulatif.", "OK");
            }
            catch 
            { 
                App.Current.MainPage.DisplayAlert("Alerte", "Vous devez sélectionner un plat pour accéder au récapitulatif.", "OK"); 
            }
        }

        /// <summary>
        /// permet d'actualiser le prix
        /// </summary>
        private void ActionCommandLesPlatsSelect()
        {
            LesPlatCommand.Clear();
            foreach (Plat UnPlat in LesPlatsSelect.ToList()) LesPlatCommand.Add(UnPlat);
            foreach (Modeles.Menu UnMenu in LesMenusSelect.ToList()) LesPlatCommand.AddRange(UnMenu.LesPlats);
            TotalPrixCommande = GetPrix(LesPlatCommand);
        }
        #endregion
    }
}