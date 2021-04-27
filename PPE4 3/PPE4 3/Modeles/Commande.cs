using System;
using System.Collections.Generic;
using System.Text;

namespace PPE4_3.Modeles
{
    public class Commande
    {
        #region Attributs
        public static List<Commande> CollClasse = new List<Commande>();
        private int _id;
        private DateTime _dateCommand;
        private bool _emporter;
        private List<Plat> _lesPlat;
        private Utilisateur _leUser;
        #endregion

        #region Constructeur
        public Commande(int id, DateTime dateCommand, bool emporter, List<Plat> lesPlat, Utilisateur user)
        {
            Id = id;
            DateCommand = dateCommand;
            Emporter = emporter;
            LesPlat = lesPlat;
            LeUser = null;
            if (!CollClasse.Exists(x => x.Id == id)) CollClasse.Add(this);
        }
        #endregion

        #region Getters-Setters
        public int Id { get => _id; set => _id = value; }
        public DateTime DateCommand { get => _dateCommand; set => _dateCommand = value; }
        public bool Emporter { get => _emporter; set => _emporter = value; }
        internal List<Plat> LesPlat { get => _lesPlat; set => _lesPlat = value; }
        internal Utilisateur LeUser { get => _leUser; set => _leUser = value; }
        #endregion

        #region Méthodes
        #endregion
    }
}
