using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPE4_3.Modeles
{
    class Utilitaire
    {
        public static async Task GetAllAsync<T>(string paramUrl)
        {
            var client = new RestClient(string.Concat(Constantes.BaseApiAddress, paramUrl));
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            try
            {
                IRestResponse response = client.Execute(request);
                JsonConvert.DeserializeObject<List<T>>(response.Content);
            }
            catch { }
        }
    }
}