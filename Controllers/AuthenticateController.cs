using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LivrariaAPI.Models;
using LivrariaAPI.DTOModels;

namespace LivrariaAPI.Controllers
{
    [Route("LivrariaAPI/v1/[controller]")]
    public class AuthenticateController : Controller
    {
        [HttpPost]
        public AuthenticateGet Post(string email, string pass)
        {
            // TODO: consumir api
            AuthenticateGet result = new AuthenticateGet();
            LoginModel login = null;

            string tokenResult = ConsumirAdapter(email, pass);

            if (string.IsNullOrEmpty(tokenResult))
                result.StatusCode = 204;
            else
            {
                login = new LoginModel(tokenResult);
                result.Login = login;
                result.StatusCode = 200;
            }
            return result;
        }

        private string ConsumirAdapter(string email, string pass)
        {
            if (email == "keppel" && pass == "123456")
                return Guid.NewGuid().ToString();
            else
                return string.Empty;
        }
    }
}
