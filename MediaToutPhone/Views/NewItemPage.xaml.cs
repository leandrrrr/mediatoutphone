using MediaToutPhone.Models;
using MediaToutPhone.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MediaToutPhone.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage(int idRessource)
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}