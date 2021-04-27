using System;
using System.Collections.Generic;
using System.Text;

namespace PPE4_3.Modeles
{
    public class TypeCuisine
    {
        #region Attributs
        public static List<TypeCuisine> CollClasse = new List<TypeCuisine>();
        private int _id;
        private string _libelle;
        private string _image;
        private List<Restaurant> _lesrestaurants;
        #endregion

        #region Constructeur
        public TypeCuisine(int id, string libelle, List<Restaurant> restaurants, string image)
        {
            Id = id;
            Libelle = libelle;
            LesRestaurants = new List<Restaurant>();
            Image = image;
            if (!CollClasse.Exists(x => x.Id == id)) CollClasse.Add(this);
        }
        #endregion

        #region Getters-Setters
        public int Id { get => _id; set => _id = value; }
        public string Libelle { get => _libelle; set => _libelle = value; }
        public string Image { get => _image; set => _image = value; }
        internal List<Restaurant> LesRestaurants { get => _lesrestaurants; set => _lesrestaurants = value; }
        #endregion

        #region Méthodes
        #endregion
    }
}
