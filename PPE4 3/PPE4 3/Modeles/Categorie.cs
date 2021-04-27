using System;
using System.Collections.Generic;
using System.Text;

namespace PPE4_3.Modeles
{
    public class Categorie
    {
        #region Attributs
        public static List<Categorie> CollClasse = new List<Categorie>();
        private int _id;
        private string _libelle;
        private string _image;
        #endregion

        #region Constructeur
        public Categorie(int id, string libelle, string limage)
        {
            Id = id;
            Libelle = libelle;
            Image = limage;
            if (!CollClasse.Exists(x => x.Id == id)) CollClasse.Add(this);
        }
        #endregion

        #region Getters-Setters
        public int Id { get => _id; set => _id = value; }
        public string Libelle { get => _libelle; set => _libelle = value; }
        public string Image { get => _image; set => _image = value; }
        #endregion

        #region Méthodes
        #endregion
    }
}
