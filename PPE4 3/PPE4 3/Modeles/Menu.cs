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
        private float _tauxReduction;
        private string _image;
        private List<Plat> _lesPlat;
        #endregion

        #region Constructeur
        public Menu(int id, string libelle, float tauxReuction, List<Plat> lesPlat, string limage)
        {
            Id = id;
            Libelle = libelle;
            TauxReduction = tauxReuction;
            LesPlat = lesPlat;
            Image = limage;
            if (!CollClasse.Exists(x => x.Id == id)) CollClasse.Add(this);
        }
        #endregion

        #region Getters-Setters
        public int Id { get => _id; set => _id = value; }
        public string Libelle { get => _libelle; set => _libelle = value; }
        public float TauxReduction { get => _tauxReduction; set => _tauxReduction = value; }
        internal List<Plat> LesPlat { get => _lesPlat; set => _lesPlat = value; }
        public string Image { get => _image; set => _image = value; }
        #endregion

        #region Méthodes
        #endregion
    }
}
