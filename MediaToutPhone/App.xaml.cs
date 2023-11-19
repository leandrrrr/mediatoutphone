using MediaToutPhone.Services;
using MediaToutPhone.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestSharp;

namespace MediaToutPhone
{
    public partial class App : Application
    {
        const string API_URL = "http://mediatout.florianjaunet.fr/api/catalogue/all";

        public static RestClient ClientApi;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            ClientApi = new RestClient(API_URL);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
