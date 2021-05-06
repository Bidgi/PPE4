using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PPE4_3.Modeles
{
    public class Utilitaire
    {
        /// <summary>
        /// permet de cree les objet de la class spécifier T
        /// </summary>
        public static async Task GetAllAsync<T>(string paramUrl)
        {
            try
            {
                IRestResponse response = await new RestClient(string.Concat(Constantes.BaseApiAddress, paramUrl)).ExecuteAsync(new RestRequest(Method.GET).AddHeader("cache-control", "no-cache"));
                JsonConvert.DeserializeObject<List<T>>(response.Content);
            }
            catch (Exception ex)
            { 
            
            }
        }

        /*public async Task<bool> PostUtilisateur(string Param1, string Param2)
        {
            try
            {
                JObject oJsonObject = new JObject();
                oJsonObject.Add("Nom", Param1);
                oJsonObject.Add("Mdp", Param2);
                var client = new HttpClient();
                var Content = new StringContent(oJsonObject.ToString());

                var response = await client.PostAsync(Constantes.BaseApiAddress + "api/PostUtilisateur", Content);
                var content = await response.Content.ReadAsStringAsync();
                if (content.Contains("pasok"))
                {

                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                return false;
            }
        }*/

        /// <summary>
        /// permet de poster la commande dans la base de donnée
        /// </summary>
        public async Task<bool> PostCommande(List<Plat> lesPlats, bool emporter, Utilisateur utilisateur)
        {
            try
            {
                List<int> Plats = new List<int>();
                foreach (Plat unPlat in lesPlats) Plats.Add(unPlat.Id);
                JObject oJsonObject = new JObject
                {
                    { "DateCommande", DateTime.Now.ToString("yyyy'-'MM'-'dd") },
                    { "Emporter", emporter },
                    { "IdUtilisateur", utilisateur.Id },
                    { "Plats", JArray.FromObject(Plats) }
                };
                var client = new HttpClient();
                var Content = new StringContent(oJsonObject.ToString());
                var response = await client.PostAsync(Constantes.BaseApiAddress + "api/PostCommande", Content);
                var content = await response.Content.ReadAsStringAsync();
                if (content.Contains("ok")) return true;
                else return false;
            }
            catch { return false; }
        } 
    }
}