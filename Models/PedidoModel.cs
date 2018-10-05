using System;
using System.Collections.Generic;
using LivrariaAPI.TypeValues;
using System.Linq;

namespace LivrariaAPI.Models
{   
    public class PedidoModel
    {
        public int NumeroPedido {get; set;}
        public Decimal ValorTotal {get; set;}
        public List<PedidoItem> ItensPedido {get; set;}
        public StatusPedido Status {get;set;}
        public DateTime DataPedido  {get;set;}
        public UsuarioModel Usuario{get;set;}
        public CartaoCreditoModel CartaoCredito {get;set;}
        
        public PedidoModel()
        {
            // TODO: gerar numero de pedido
            NumeroPedido = 1;
            ItensPedido = new List<PedidoItem>();
        }

        public void AddRangeItemPedido(List<PedidoItem> itens)
        {
            ItensPedido = itens;
            CalculaValorTotal();
        }

        public void AddItemPedido(PedidoItem item)
        {
            ItensPedido.Add(item);
            ValorTotal += item.Valor;
        }

        public void RemoveItemPedido(PedidoItem item)
        {
            ItensPedido.Remove(item);
            ValorTotal -= item.Valor;
        }        

        private void CalculaValorTotal()
        {
            ValorTotal = ItensPedido.Sum(o => o.Valor);
        }
    }
}