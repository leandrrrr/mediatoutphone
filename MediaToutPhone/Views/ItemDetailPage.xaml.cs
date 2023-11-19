using MediaToutPhone.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MediaToutPhone.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}