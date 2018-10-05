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
        public static async Task<bool> RegistrarLogTransacao(LoggerPagamentoRequestModel logger)
        {
            string url = "http://localhost:5001/LoggerApi/v1/Logger";        
            var uri = new Uri(url);
            HttpClient cliente = new HttpClient();

            var data = JsonConvert.SerializeObject(logger);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            //HttpResponseMessage response = cliente.PostAsync(uri, content);
            HttpResponseMessage response = await cliente.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
    }
}