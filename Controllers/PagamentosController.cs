using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LivrariaAPI.Models;
using LivrariaAPI.DTOModels;
using LivrariaAPI.Services;
using LivrariaAPI.RequestModels;

namespace LivrariaAPI.Controllers
{
    [Route("LivrariaAPI/v1/[controller]")]
    public class PagamentosController : Controller
    {
        [HttpPost]
        public async Task Post([FromBody] PedidoModel pedido)
        {
            // Consumir a api de logger
            LoggerPagamentoRequestPost log = new LoggerPagamentoRequestPost
            {
                NumeroPedido = pedido.NumeroPedido,
                DataPagamento = DateTime.Now,
                IdUsuario = pedido.Usuario.IdUsuario,
                ValorPedido = pedido.ValorTotal,
                QtdParcelas = pedido.QtdParcelas
            };

            var gravouLog = LoggerService.RegistrarLogTransacao(log);
            // Consumir API de transacao de pagamento

        } 
    }
}