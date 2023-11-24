using MediaToutPhone.Models;
using MediaToutPhone.Services;
using MediaToutPhone.ViewModels;
using MediaToutPhone.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MediaToutPhone.Views;


namespace MediaToutPhone.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;


        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
            btnSearch.Clicked +=  btnSearchClicked;
        }

        private void btnSearchClicked(object sender, EventArgs e)
        {
            btnSearch.Text = "nice";
            gg(entrySearch.Text);
        }

        private async Task gg(string textToSearch)
        {
            // Réinitialiser le contenu en créant un nouveau StackLayout vide
            var emptyContainerLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
            };

            svRessources.Content = emptyContainerLayout;
            var containerLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
            };

            try
            {
                // Appel de la méthode SearchAsync pour récupérer la liste de ressources
                List<Ressources> listeRessources = await MediaApi.SearchAsync("http://mediatout.florianjaunet.fr/api/catalogue/all");
                string rechercheRessource = textToSearch;
                string titreRessource = "";

                bool okOrNot;
                //verif de la recherche
                
                
                foreach (var ressource in listeRessources)

                {
                    titreRessource = $"{ressource.titre}";
                    okOrNot = true;
                    for (int j = 0; j < rechercheRessource.Length; j++)
                        {
                        if(!titreRessource.Contains(rechercheRessource[j])) { okOrNot = false;}
                        }
                    if (okOrNot)
                    {
                        //affichage des donnees
                        var ressourceLayout = new StackLayout
                        {
                            Orientation = StackOrientation.Vertical,
                            Padding = new Thickness(20),
                            Spacing = 5,
                            Margin = new Thickness(20),
                            BackgroundColor = Color.FromHex("#FFa6d8f5"),

                        };
                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += (sender, e) =>
                        {
                            // Le code que vous souhaitez exécuter lors du clic va ici
                            // Par exemple, vous pouvez ouvrir une nouvelle page, afficher un message, etc.
                            Console.WriteLine("StackLayout cliqué !");
                        };
                        var image = new Image
                        {
                            Source = ImageSource.FromUri(new Uri("http://mediatout.florianjaunet.fr/public/assets/" + ressource.image)), // Utilise l'URL de l'image
                            Aspect = Aspect.AspectFit,
                            HeightRequest = 100,
                        };

                        var titleLabel = new Label
                        {
                            Text = $"{ressource.titre}",
                            FontSize = 16,
                            TextColor = Color.Black,
                        };

                        ressourceLayout.Children.Add(titleLabel);
                        ressourceLayout.Children.Add(image);
                        ressourceLayout.GestureRecognizers.Add(tapGestureRecognizer);


                        containerLayout.Children.Add(ressourceLayout);
                    }

                }
                svRessources.Content = containerLayout;
            }
            catch (Exception ex)
            {
                // Gérer les erreurs appropriées
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                infoDebug.Text = ($"Une erreur s'est produite : {ex.Message}");
            }
            
        }





        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}