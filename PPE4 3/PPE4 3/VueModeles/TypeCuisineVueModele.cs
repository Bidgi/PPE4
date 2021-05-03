using PPE4_3.Modeles;
using PPE4_3.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PPE4_3.VueModeles
{
    class TypeCuisineVueModele : BaseVueModele
    {
        #region Attributs
        private ObservableCollection<TypeCuisine> _lesTypeCuisine;
        private TypeCuisine _leTypeCusine;
        #endregion

        #region Constructeurs
        public TypeCuisineVueModele()
        {
            LesTypeCuisine = new ObservableCollection<TypeCuisine>(TypeCuisine.CollClasse);
        }
        #endregion

        #region Getters setters
        public ICommand CommandeButtonTypeCusine { get; }
        public ObservableCollection<TypeCuisine> LesTypeCuisine
        {
            get => _lesTypeCuisine;
            set => SetProperty(ref _lesTypeCuisine, value);
        }
        public TypeCuisine LeTypeCusine
        {
            get => _leTypeCusine;
            set
            {
                SetProperty(ref _leTypeCusine, value);
                this.ActionTypeCusine();
            }
        }
        #endregion

        #region Methodes
        /// <summary>
        /// permet de passer a la page suivante
        /// </summary>
        private void ActionTypeCusine() => App.Current.MainPage = new ListeRestaurantVue(LeTypeCusine);
        #endregion
    }
}
