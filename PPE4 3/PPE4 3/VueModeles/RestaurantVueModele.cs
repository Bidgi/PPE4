using PPE4_3.Modeles;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPE4_3.VueModeles
{
    class RestaurantVueModele
    {
        #region
        private Restaurant _leRestaurant;
        #endregion

        #region
        public RestaurantVueModele(Restaurant leRestaurant)
        {
            LeRestaurant = leRestaurant;
        }
        #endregion

        #region
        public Restaurant LeRestaurant { get => _leRestaurant; set => _leRestaurant = value; }
        #endregion
    }
}
