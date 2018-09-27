using System;
using System.Collections.Generic;
using System.Linq;
using LivrariaAPI.TypeValues;

namespace LivrariaAPI.Models
{
    public class CarrinhoModel
    {
        #region [ Propriedades ]

        public int IdCarrinho {get;set;}
        public List<LivroModel> Itens {get;set;}

        #endregion

        #region [ Métodos ]
        public CarrinhoModel()
        {
            IdCarrinho = 1;
        }

        public void AddItem(LivroModel item)
        {
            Itens.Add(item);
        }

        /// Cria um pedido e realiza a persistencia do mesmo na base de dados
        public PedidoModel ConfirmarPedido()
        {
            PedidoModel pedido = new PedidoModel();
            pedido.ValorTotal = Itens.Sum(o => o.Valor);

            pedido.AddRangeItemPedido(Itens);
            pedido.DataPedido = DateTime.Now;
            pedido.Status = StatusPedido.Confirmado;

            return pedido;
        }
        #endregion
    }
}