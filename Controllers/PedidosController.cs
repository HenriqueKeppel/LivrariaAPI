using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LivrariaAPI.Models;
using LivrariaAPI.DTOModels;
using LivrariaAPI.TypeValues;

namespace LivrariaAPI.Controllers
{
    [Route("LivrariaAPI/v1/[controller]")]
    public class PedidosController : Controller
    {
        [HttpPost("confirmar")]
        public ConfirmarPedidoResponse ConfirmarPedido([FromBody]CarrinhoModel carrinho)
        {
            ConfirmarPedidoResponse result = new ConfirmarPedidoResponse();
            PedidoModel pedido = new PedidoModel();
            
            // Adiciona itens do carrinho no pedido
            pedido.AddRangeItemPedido(carrinho.Itens);

            pedido.DataPedido = DateTime.Now;
            pedido.Status = StatusPedido.Confirmado;

            result.StatusCode = 200;
            result.Pedido = pedido;

            return result;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(200)]
        public PedidosGet Get([FromQuery]DateTime dataPedido, int status)
        {
            PedidosGet result = new PedidosGet();

            if (dataPedido.ToString("yyyy-ii-dd") == "2018-09-26")
            {
                PedidoModel pedido = new PedidoModel();

                PedidoItem item = new PedidoItem() 
                {
                    Isbn = 123456,
                    Valor = 59,
                    Titulo = "Odisseia"
                };

                pedido.AddItemPedido(item);
                result.Pedidos.Add(pedido);
                result.StatusCode = 200;
            }
            else
                result.StatusCode = 204;
            return result;
        }

        // GET api/values/5
        [HttpGet("{idPedido}")]
        public PedidosGet Get(int idPedido)
        {
            PedidosGet result = new PedidosGet();

            if (idPedido == 1)
            {
                PedidoModel pedido = new PedidoModel();                

                PedidoItem item = new PedidoItem() 
                {
                    Isbn = 123456,
                    Valor = 59,
                    Titulo = "Odisseia"
                };
                
                pedido.AddItemPedido(item);
                result.Pedidos.Add(pedido);
                result.StatusCode = 200;
            }
            else
                result.StatusCode = 204;
            return result;
        }

        [HttpPut("{idPedido}/Cancelar")]
        public ResponseGet CancelarPedido(int idPedido)
        {
            ResponseGet result = new ResponseGet();

            // Obter pedido para cancelamento
            if (idPedido == 1)
                result.StatusCode = 200;
            else
                result.StatusCode = 204;
            return result;
        }
    }
}
