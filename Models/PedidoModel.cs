using System;
using System.Collections.Generic;
using LivrariaAPI.TypeValues;

namespace LivrariaAPI.Models
{   
    public class PedidoModel
    {
        public int NumeroPedido {get; set;}
        public Decimal ValorTotal {get; set;}
        public List<LivroModel> ItensPedido {get; set;}
        public StatusPedido Status {get;set;}
        public DateTime DataPedido  {get;set;}

        public PedidoModel()
        {
            // TODO: gerar numero de pedido
            NumeroPedido = 1;
            ItensPedido = new List<LivroModel>();
        }

        public void AddRangeItemPedido(List<LivroModel> itens)
        {
            ItensPedido = itens;
        }

        public void AddItemPedido(LivroModel item)
        {
            ItensPedido.Add(item);
            ValorTotal += item.Valor;
        }

        public void RemoveItemPedido(LivroModel item)
        {
            ItensPedido.Remove(item);
            ValorTotal -= item.Valor;
        }
    }
}