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
        public List<PedidoItem> Itens {get;set;}

        #endregion

        #region [ Métodos ]
        public CarrinhoModel()
        {
            IdCarrinho = 1;
            Itens = new List<PedidoItem>();
        }

        public CarrinhoModel(int idCarrinho)
        {
            IdCarrinho = idCarrinho;
            Itens = new List<PedidoItem>();
        }

        public void AddItem(PedidoItem item)
        {
            Itens.Add(item);
        }

        /// Cria um pedido e realiza a persistencia do mesmo na base de dados
        
        #endregion
    }
}