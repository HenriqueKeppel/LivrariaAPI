using System;

namespace LivrariaAPI.ResponseModels
{
    public class AutenticacaoResponsePost
    {
        public string Token {get;set;}
        public DateTime DataCriacao {get;set;}
        public string Login {get;set;}
        public int IdUsuario {get;set;}
    }
}