using PPE4_3.Modeles;
using PPE4_3.Vues;
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
        private string _switchBool;
        private string _pass;
        #endregion

        #region Constructeurs
        public IdentificationVueModele()
        {
            GetListe();
            CommandeButtonLogIn = new Command(ActionPage);
        }
        #endregion

        #region Getters setters
        public ICommand CommandeButtonLogIn { get; }
        public string SwitchBool
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
        public async Task GetListe()
        {
            IsBusy = true;
            await Utilitaire.GetAllAsync<Utilisateur>("api/utilisateurs");
            await Utilitaire.GetAllAsync<Restaurant>("api/restaurants");
            IsBusy = false;
        }
        public void ActionPage()
        {
            if (Utilisateur.CollClasse.FindAll(x => x.Nom == Nom).Exists(x => x.Mdp == Mdp)) Device.BeginInvokeOnMainThread(() => { Application.Current.MainPage = new NavigationPage(new TypeCuisineVue()); });
        }
        #endregion
    }
}

//if (SwitchBool == "true") WriteTextAllAsync("Pass.txt", string.Concat(Nom, ",", Mdp, ",", "true"));
/*IsFileExistAsync("Pass.txt", folder);
if (File)
{
    ReadAllTextAsync("Pass.txt");
    if (Pass.Length != 0)
    {
        string[] pass = Pass.Split(',');
        Nom = pass[0];
        Mdp = pass[1];
        SwitchBool = pass[2];
    }
}
else folder.CreateFileAsync("Pass.txt", CreationCollisionOption.ReplaceExisting);*/