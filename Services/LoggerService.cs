using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LivrariaAPI.Models;
using LivrariaAPI.RequestModels;
using Newtonsoft.Json;

namespace LivrariaAPI.Services
{
    public static class LoggerService
    {
        private const string urlBase = "http://localhost:5001/LoggerApi/v1/Logger";
        public static async Task<bool> RegistrarLogTransacao(LoggerPagamentoRequestPost request)
        {
            bool retorno = false;
            var uri = new Uri(string.Format("{0}/Pagamento", urlBase));

            using (var cliente = new HttpClient())
            {
                var data = JsonConvert.SerializeObject(request);
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await cliente.PostAsync(uri, content);

                retorno = response.IsSuccessStatusCode;
            }
            return retorno;
        }
    }
}