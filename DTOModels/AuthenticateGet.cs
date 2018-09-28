using System;
using LivrariaAPI.Models;

namespace LivrariaAPI.DTOModels
{
    public class AuthenticateGet : ResponseGet
    {
        public LoginModel Login { get; set; }

        public AuthenticateGet()
            : base()
        {
        }
    }
}