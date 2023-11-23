using MediaToutPhone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Text.Json;
using RestSharp.Serializers;
using Xamarin.Forms.Shapes;
using System.Net.Http;

namespace MediaToutPhone.Services
{
    public class MediaApi
    {
        public static async Task<List<Ressources>> SearchAsync(string url_api)
        {
            // Créer un client HTTP
            using (var httpClient = new HttpClient())
            {
                // Définir l'URL de votre API
                var apiUrl = url_api;

                // Envoyer la demande GET
                var response = await httpClient.GetStringAsync(apiUrl);

                // Utiliser System.Text.Json pour désérialiser le JSON
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                // Convertir la réponse JSON en une liste d'objets Ressources
                var listeRessources = JsonSerializer.Deserialize<List<Ressources>>(response, options);

                return listeRessources;
            }
        }
    }
}

