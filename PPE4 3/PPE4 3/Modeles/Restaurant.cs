using System;
using System.Collections.Generic;
using System.Text;

namespace PPE4_3.Modeles
{
    public class Restaurant
    {
        #region Attributs
        public static List<Restaurant> CollClasse = new List<Restaurant>();
        private int _id;
        private string _nom;
        private string _adresse;
        private string _codePostal;
        private string _ville;
        private string _telephone;
        private string _mail;
        private string _image;
        private string _adressefull;
        private string _typeCuisinefull;
        private List<TypeCuisine> _lesTypesCuisines;
        private List<Plat> _lesPlats;
        private List<Menu> _lesMenus;
        #endregion

        #region Constructeurs
        public Restaurant(int id, string nom, string adresse, string codePostal, string ville, string telephone, string mail, string image, List<TypeCuisine> lesTypesCuisines, List<Plat> lesPlats)
        {
            _id = id;
            _nom = nom;
            _adresse = adresse;
            _codePostal = codePostal;
            _ville = ville;
            _telephone = telephone;
            _mail = mail;
            _adressefull = string.Concat(ville, " - ", adresse);
            _lesTypesCuisines = lesTypesCuisines;
            _lesPlats = lesPlats;
            _image = image;
            _typeCuisinefull = TypeCuisineFull(lesTypesCuisines);
            this.SetListeTypeCuisine();
            this.SetListePlat();
            if (!CollClasse.Exists(x => x.Id == id)) CollClasse.Add(this);
        }
        #endregion

        #region Getters Setters
        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Adresse { get => _adresse; set => _adresse = value; }
        public string CodePostal { get => _codePostal; set => _codePostal = value; }
        public string Ville { get => _ville; set => _ville = value; }
        public string Telephone { get => _telephone; set => _telephone = value; }
        public string Mail { get => _mail; set => _mail = value; }
        public List<TypeCuisine> LesTypesCuisines { get => _lesTypesCuisines; set => _lesTypesCuisines = value; }
        public List<Plat> LesPlats { get => _lesPlats; set => _lesPlats = value; }
        public List<Menu> LesMenus { get => _lesMenus; set => _lesMenus = value; }
        public string Image { get => _image; set => _image = value; }
        public string Adressefull { get => _adressefull; set => _adressefull = value; }
        public string TypeCuisinefull { get => _typeCuisinefull; set => _typeCuisinefull = value; }
        #endregion

        #region Methodes
        private void SetListeTypeCuisine()
        {
            foreach (TypeCuisine unTypeCuisine in this.LesTypesCuisines) unTypeCuisine.LesRestaurants.Add(this);
        }
        private void SetListePlat()
        {
            foreach (Plat unPlat in this._lesPlats) unPlat.LeRestaurant = this;
        }
        private string TypeCuisineFull(List<TypeCuisine> lesTypeCuisines)
        {
            string vs = string.Empty;
            for (int i = 0; i < lesTypeCuisines.Count; i++)
            {
                if(i != lesTypeCuisines.Count - 1) vs += string.Concat(lesTypeCuisines[i].Libelle, " - ");
                else vs += lesTypeCuisines[i].Libelle;
            }
            return vs;
        }
        public void AddMenu(Menu leMenu)
        {
            this.LesMenus.Add(leMenu);
        }
        #endregion
    }
}
