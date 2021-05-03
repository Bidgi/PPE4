using PPE4_3.Modeles;
using PPE4_3.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PPE4_3.VueModeles
{
    class RestaurantVueModele
    {
        #region Attributs
        private Restaurant _leRestaurant;
        private List<Plat> _lesPlats;
        private List<Modeles.Menu> _lesMenus;
        private ObservableCollection<Plat> _lesPlatsOC;
        private float _totalPrixCommande;
        #endregion

        #region Constructeurs
        public RestaurantVueModele(Restaurant leRestaurant)
        {
            LeRestaurant = leRestaurant;
            LesPlats = leRestaurant.LesPlats;
            LesMenus = leRestaurant.LesMenus;
            CommandeButtonRestaurant = new Command(ActionPageRestaurant);
            /*LesPlatsOC.CollectionChanged += LesPlatsOC_CollectionChanged; /// MARCHE PAS*/
        }
        #endregion

        #region Getters setters
        public ICommand CommandeButtonRestaurant { get; }
        public Restaurant LeRestaurant { get => _leRestaurant; set => _leRestaurant = value; }
        public ObservableCollection<Plat> LesPlatsOC { get => _lesPlatsOC; set => _lesPlatsOC = value; }
        public List<Plat> LesPlats { get => _lesPlats; set => _lesPlats = value; }
        public List<Modeles.Menu> LesMenus { get => _lesMenus; set => _lesMenus = value; }
        public float TotalPrixCommande { get => _totalPrixCommande; set => _totalPrixCommande = value; }
        #endregion

        #region Methodes
        /*/// <summary>
        /// permet de calculer le prix total a chaque changement (add ou remove) dans la liste des plat selectionner MARCHE PAS 
        /// </summary>
        public void LesPlatsOC_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && e.Action == NotifyCollectionChangedAction.Remove)
            {
                TotalPrixCommande = 0;
                foreach (Plat unPlat in LesPlats) TotalPrixCommande += unPlat.Prix;
            }
        }*/

        /// <summary>
        /// permet de passer a la page suivante
        /// </summary>
        private void ActionPageRestaurant() => App.Current.MainPage = new CommandeVue(new List<Plat>(LesPlats), LeRestaurant, TotalPrixCommande);
        #endregion
    }
}