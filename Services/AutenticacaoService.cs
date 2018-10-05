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
        private const string urlBase = "http://localhost:5002/AutenticacaoApi/v1/";

        public static async Task<UsuarioModel> Autenticar(string email, string pass)
        {
            var uri = new Uri(string.Format("{0}/Autenticacao", urlBase));
            HttpClient cliente = new HttpClient();
            UsuarioModel usuarioAutenticado = null;

            AutenticacaoRequestPost request = new AutenticacaoRequestPost
            {
                Email = email,
                Pass = pass
            };

            var data = JsonConvert.SerializeObject(request);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await cliente.PostAsync(uri, content);
            
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                AutenticacaoResponsePost retorno = JsonConvert.DeserializeObject<AutenticacaoResponsePost>(responseString);
                
                usuarioAutenticado = new UsuarioModel
                {
                    IdUsuario = retorno.IdUsuario,
                    Login = retorno.Login,
                    Token = retorno.Token    
                };
            }
            return usuarioAutenticado;
        }

        public static async Task<UsuarioModel> AutenticarV2(string email, string pass)
        {
            var uri = new Uri(string.Format("{0}/Autenticacao", urlBase));
            UsuarioModel usuarioAutenticado = null;

            using (var cliente = new HttpClient())
            {
                AutenticacaoRequestPost request = new AutenticacaoRequestPost
                {
                    Email = email,
                    Pass = pass
                };

                var data = JsonConvert.SerializeObject(request);
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await cliente.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    AutenticacaoResponsePost retorno = JsonConvert.DeserializeObject<AutenticacaoResponsePost>(responseString);

                    usuarioAutenticado = new UsuarioModel
                    {
                        IdUsuario = retorno.IdUsuario,
                        Login = retorno.Login,
                        Token = retorno.Token    
                    };
                }
            }
            return usuarioAutenticado;
        }
    }
}