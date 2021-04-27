using System;
using System.Collections.Generic;
using System.Text;

namespace PPE4_3.Modeles
{
    public class Utilisateur
    {
        #region Attributs
        public static List<Utilisateur> CollClasse = new List<Utilisateur>();
        private int _id;
        private string _nom;
        private string _prenom;
        private string _mdp;
        private string _image;
        private List<Commande> _lesCommande;
        #endregion

        #region Constructeur
        public Utilisateur(int id, string nom, string prenom, string mdp, string limage, List<Commande> lescommandes)
        {
            LesCommande = lescommandes;
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Mdp = mdp;
            Image = limage;
            lescommandes.ForEach(delegate (Commande commande) { commande.LeUser = this; });
            if (!CollClasse.Exists(x => x.Id == id)) CollClasse.Add(this);
        }
        #endregion

        #region Getters-Setters
        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public string Mdp { get => _mdp; set => _mdp = value; }
        public string Image { get => _image; set => _image = value; }
        public List<Commande> LesCommande { get => _lesCommande; set => _lesCommande = value; }
        #endregion

        #region Méthodes
        #endregion
    }
}
