using System;

namespace LivrariaAPI.Models
{
    public class LoginModel
    {
        public string Token {get;}

        public LoginModel(string token)
        {
            this.Token = token;
        }
    }
}