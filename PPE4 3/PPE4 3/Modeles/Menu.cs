using System;
using System.Collections.Generic;
using System.Text;

namespace PPE4_3.Modeles
{
    public class Menu
    {
        #region Attributs
        public static List<Menu> CollClasse = new List<Menu>();
        private int _id;
        private string _libelle;
        private string _image;
        private float _prisMenu;
        private Restaurant _leRestaurant;
        private List<Plat> _lesPlats;
        #endregion

        #region Constructeur
        public Menu(int id, string libelle, List<Plat> lesPlats, string image)
        {
            Id = id;
            Libelle = libelle;
            LesPlats = lesPlats;
            Image = image;
            PrisMenu = TotalPrix(LesPlats);
            LeRestaurant = this.LesPlats[0].LeRestaurant;
            SetRestaurant(lesPlats, this);
            if (!LeRestaurant.LesMenus.Exists(x => x.Id == id)) LeRestaurant.AddMenu(this);
            if (!CollClasse.Exists(x => x.Id == id)) CollClasse.Add(this);
        }
        #endregion

        #region Getters-Setters
        public int Id { get => _id; set => _id = value; }
        public string Libelle { get => _libelle; set => _libelle = value; }
        internal List<Plat> LesPlats { get => _lesPlats; set => _lesPlats = value; }
        public string Image { get => _image; set => _image = value; }
        public float PrisMenu { get => _prisMenu; set => _prisMenu = value; }
        public Restaurant LeRestaurant { get => _leRestaurant; set => _leRestaurant = value; }
        #endregion

        #region Méthodes
        public float TotalPrix(List<Plat> lesPlat)
        {
            float prix = 0;
            foreach (Plat unPlat in lesPlat) prix += unPlat.Prix;
            return prix;
        }
        public void SetRestaurant(List<Plat> lesPlat, Menu unMenu)
        {
            foreach (Restaurant unRestaurant in Restaurant.CollClasse) foreach (Plat unPlat in unRestaurant.LesPlats) if (lesPlat.Exists(x => x.Id == unPlat.Id)) unMenu.LeRestaurant = unRestaurant;
        }
        #endregion
    }
}
