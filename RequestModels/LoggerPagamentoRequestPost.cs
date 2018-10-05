using LivrariaAPI.Models;
using System;

namespace LivrariaAPI.RequestModels
{
    public class LoggerPagamentoRequestModel
    {
        CartaoCreditoModel Cartao {get;set;}
        UsuarioModel Usuario {get;set;}
        public int NumeroPedido {get;set;}
    }
}