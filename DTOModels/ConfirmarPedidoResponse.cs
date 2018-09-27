using System;
using System.Collections.Generic;
using LivrariaAPI.Models;

namespace LivrariaAPI.DTOModels
{
    public class ConfirmarPedidoResponse : ResponseGet
    {
        public PedidoModel Pedido { get; set; }

        public ConfirmarPedidoResponse()
            : base()
        {
            Limit = 0;
            Offset = 0;
        }
    }
}