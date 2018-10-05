using LivrariaAPI.Models;
using System;

namespace LivrariaAPI.RequestModels
{
    public class LoggerPagamentoRequestPost
    {
        public int NumeroPedido {get;set;}
        public DateTime DataPagamento {get;set;}
        public int IdUsuario {get;set;}
        public decimal ValorPedido {get;set;}
        public int QtdParcelas {get;set;}
    }
}