using PPE4_3.Vues;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PPE4_3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new IdentificationVue();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
