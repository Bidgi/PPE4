using System;
using System.Collections.Generic;
using System.Text;

namespace PPE4_3.Modeles
{
    public class Plat
    {
        #region Attributs
        public static List<Plat> CollClasse = new List<Plat>();
        private int _id;
        private string _libelle;
        private float _prix;
        private string _image;
        private Categorie _laCategorie;
        private Restaurant _leRestaurants;
        #endregion

        #region Constructeur
        public Plat(int id, string libelle, float prix, Categorie laCategorie, Restaurant leRestaurants, string limage)
        {
            Id = id;
            Libelle = libelle;
            Prix = prix;
            LaCategorie = laCategorie;
            LeRestaurant = leRestaurants;
            Image = limage;
            if (!CollClasse.Exists(x => x.Id == id)) CollClasse.Add(this);
        }
        #endregion

        #region Getters-Setters
        public int Id { get => _id; set => _id = value; }
        public string Libelle { get => _libelle; set => _libelle = value; }
        public float Prix { get => _prix; set => _prix = value; }
        internal Categorie LaCategorie { get => _laCategorie; set => _laCategorie = value; }
        internal Restaurant LeRestaurant { get => _leRestaurants; set => _leRestaurants = value; }
        public string Image { get => _image; set => _image = value; }
        #endregion

        #region Méthodes
        #endregion
    }
}
