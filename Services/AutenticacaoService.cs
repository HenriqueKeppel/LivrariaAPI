using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LivrariaAPI.Models;
using LivrariaAPI.RequestModels;
using LivrariaAPI.ResponseModels;
using Newtonsoft.Json;

namespace LivrariaAPI.Services
{
    public static class AutenticacaoService
    {
        public static async Task<AutenticacaoResponsePost> Autenticao(string email, string pass)
        {
            string url = "http://localhost:5002/AutenticacaoApi/v1/Autenticacao";        
            var uri = new Uri(url);
            HttpClient cliente = new HttpClient();
            AutenticacaoRequestPost request = new AutenticacaoRequestPost
            {
                Email = email,
                Pass = pass
            };

            var data = JsonConvert.SerializeObject(request);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            //HttpResponseMessage response = cliente.PostAsync(uri, content);
            HttpResponseMessage response = await cliente.PostAsync(uri, content);

            AutenticacaoResponsePost retorno = new AutenticacaoResponsePost();
            return retorno;
            /* 
            if (response.IsSuccessStatusCode)
            {
                var login = JsonConvert.DeserializeObject(response);
            }
            else
                return false;
            */
        }
    }
}