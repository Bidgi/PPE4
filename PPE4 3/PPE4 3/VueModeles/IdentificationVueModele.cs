using PPE4.Vues;
using PPE4_3.Modeles;
using PPE4_3.Vues;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PPE4_3.VueModeles
{
    class IdentificationVueModele : BaseVueModele
    {
        #region Attributs
        private string _nom;
        private string _mdp;
        private bool _switchBool;
        private string _pass;
        #endregion

        #region Constructeurs
        /// <summary>
        /// permet de definire le nom et le mdp si l'utilisateur les a précédemment enregistré
        /// </summary>
        public IdentificationVueModele()
        {
            GetListe();
            CommandeButtonLogIn = new Command(ActionPage);
            if (App.Current.Properties.ContainsKey("NOM")) Nom = App.Current.Properties["NOM"].ToString();
            if (App.Current.Properties.ContainsKey("MDP")) Mdp = App.Current.Properties["MDP"].ToString();
            if (App.Current.Properties.ContainsKey("SwitchBool")) SwitchBool = Convert.ToBoolean(App.Current.Properties["SwitchBool"].ToString());
        }
        #endregion

        #region Getters setters
        public ICommand CommandeButtonLogIn { get; }
        public bool SwitchBool
        {
            get => _switchBool;
            set
            {
                if (_switchBool != value)
                {
                    _switchBool = value;
                    OnPropertyChanged(nameof(SwitchBool));
                }
            }
        }
        public string Nom
        {
            get => _nom;
            set
            {
                if (_nom != value)
                {
                    _nom = value;
                    OnPropertyChanged(nameof(Nom));
                }
            }
        }
        public string Mdp
        {
            get => _mdp;
            set
            {
                if (_mdp != value)
                {
                    _mdp = value;
                    OnPropertyChanged(nameof(Mdp));
                }
            }
        }
        public string Pass { get => _pass; set => _pass = value; }
        #endregion


        #region Methodes
        /// <summary>
        /// permte de charger les differents classe
        /// </summary>
        private async Task GetListe()
        {
            IsBusy = true;
            await Utilitaire.GetAllAsync<Utilisateur>("api/utilisateurs");
            await Utilitaire.GetAllAsync<Restaurant>("api/restaurants");
            await Utilitaire.GetAllAsync<Modeles.Menu>("api/menus");
            IsBusy = false;
            ReverseIsBusy = true;
        }

        /// <summary>
        /// permet d'enregistre ou non les information utilisateur
        /// et de savoir si l'utilisateur a bien entrer les bonnes identifiant
        /// puit de passer a la page suivante
        /// </summary>
        private void ActionPage()
        {
            Utilisateur unUser = Utilisateur.CollClasse.FindAll(x => x.Nom == Nom).Find(x => x.Mdp == Mdp);
            if (unUser != null)
            {
                Constantes.LUtilisateur = unUser;
                if (!App.Current.Properties.ContainsKey("NOM")) App.Current.Properties.Add("NOM", Nom);
                if (!App.Current.Properties.ContainsKey("MDP")) App.Current.Properties.Add("MDP", Mdp);
                if (!App.Current.Properties.ContainsKey("SwitchBool")) App.Current.Properties.Add("SwitchBool", SwitchBool);
                if (SwitchBool)
                {
                    App.Current.Properties["NOM"] = Nom;
                    App.Current.Properties["MDP"] = Mdp;
                    App.Current.Properties["SwitchBool"] = SwitchBool;
                }
                else
                {
                    App.Current.Properties["NOM"] = string.Empty;
                    App.Current.Properties["MDP"] = string.Empty;
                    App.Current.Properties["SwitchBool"] = false;
                }
                App.Current.SavePropertiesAsync();
                App.Current.MainPage = new ListeRestaurantVue();
            }
            else App.Current.MainPage.DisplayAlert("Alerte", "Votre nom ou votre mot de passe est incorrect, veuillez réessayer.", "Réessayer");
        }
        #endregion
    }
}
