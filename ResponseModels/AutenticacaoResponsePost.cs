using System;
using LivrariaAPI.Models;

namespace LivrariaAPI.ResponseModels
{
    public class AutenticacaoResponsePost
    {
        public AutenticacaoModel Autenticacao {get;set;}
        public int IsValid {get;set;}
    }
}
