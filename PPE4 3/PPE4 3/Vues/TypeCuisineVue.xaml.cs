﻿using PPE4_3.VueModeles;
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
    public partial class TypeCuisineVue : ContentPage
    {
        public TypeCuisineVue()
        {
            TypeCuisineVueModele vuesModeles;
            InitializeComponent();
            BindingContext = vuesModeles = new TypeCuisineVueModele();
        }
    }
}