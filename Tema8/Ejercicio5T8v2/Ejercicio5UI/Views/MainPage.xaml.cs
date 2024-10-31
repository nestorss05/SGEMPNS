﻿using Ejercicio5Ent;
using Ejercicio5DAL;
using System.Collections.ObjectModel;

namespace Ejercicio5UI.Views
{
    public partial class MainPage : ContentPage
    {

        /// <summary>
        /// Llama a la lista de personas
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            PersonaView.ItemsSource = Ejercicio5DAL.clsListadosDAL.getListadoCompletoPersonas();
        }
    }

}
