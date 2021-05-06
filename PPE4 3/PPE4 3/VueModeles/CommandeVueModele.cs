using PPE4_3;
using PPE4_3.Modeles;
using PPE4_3.VueModeles;
using PPE4_3.Vues;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PPE4.VueModeles
{
    class CommandeVueModele : BaseVueModele
    {
        #region Attributs
        private Restaurant _leRestaurant;
        private List<Plat> _lesPlats;
        private bool _emporter;
        private float _totalPrixCommande;
        private readonly Utilitaire utilitaire = new Utilitaire();
        #endregion

        #region Constructeurs
        public CommandeVueModele(List<Plat> lesPlats, Restaurant leRestaurant, float prixtt)
        {
            IsBusy = false;
            ReverseIsBusy = true;
            LeRestaurant = leRestaurant;
            LesPlats = lesPlats;
            TotalPrixCommande = prixtt;
            CommandeButtonCommande = new Command(ActionButtonPageCommande);
        }
        #endregion

        #region Getters setters
        public ICommand CommandeButtonCommande { get; }
        public Restaurant LeRestaurant { get => _leRestaurant; set => _leRestaurant = value; }
        public List<Plat> LesPlats { get => _lesPlats; set => _lesPlats = value; }
        public float TotalPrixCommande { get => _totalPrixCommande; set => _totalPrixCommande = value; }
        public bool Emporter
        {
            get => _emporter;
            set
            {
                if (_emporter != value)
                {
                    _emporter = value;
                    OnPropertyChanged(nameof(Emporter));
                }
            }
        }
        #endregion

        #region Methodes
        /// <summary>
        /// permet de valider ou non la commande
        /// </summary>
        public void ActionButtonPageCommande()
        {
            IsBusy = true;
            ActionPageCommande();
        }

        public async Task ActionPageCommande()
        {
            ReverseIsBusy = false;
            bool result = await utilitaire.PostCommande(LesPlats, Emporter, Constantes.LUtilisateur);
            IsBusy = false;
            if (result)
            {
                App.Current.MainPage.DisplayAlert("Félisitation", "Votre commande a bien été prise en compte.", "OK");
                App.Current.MainPage = new TypeCuisineVue();
            }
            else App.Current.MainPage.DisplayAlert("Alerte", "Votre commande n'a pas pue été prise en compte. Veuille vérifié votre connection internet ou réessayer plus tard.", "OK");
        }
        #endregion
    }
}
