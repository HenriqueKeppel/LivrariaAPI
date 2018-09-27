using System;
using System.Collections.Generic;
using LivrariaAPI.Models;

namespace LivrariaAPI.DTOModels
{
    public class PedidosGet : ResponseGet
    {
        public List<PedidoModel> Pedidos { get; set; }

        public PedidosGet(int limit = 0, int offset = 0)
            : base()
        {
            Limit = limit;
            Offset = offset;
            Pedidos = new List<PedidoModel>();
        }
    }
}