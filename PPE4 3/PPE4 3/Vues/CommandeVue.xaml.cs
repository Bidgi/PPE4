using PPE4.VueModeles;
using PPE4_3.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PPE4_3.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommandeVue : ContentPage
    {
        public CommandeVue(List<Plat> lesPlats, Restaurant leRestaurant, float prixtt)
        {
            CommandeVueModele vuesModeles;
            InitializeComponent();
            BindingContext = vuesModeles = new CommandeVueModele(lesPlats, leRestaurant, prixtt);
        }
    }
}