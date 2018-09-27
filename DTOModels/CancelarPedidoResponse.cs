using System;
using System.Collections.Generic;
using LivrariaAPI.Models;

namespace LivrariaAPI.DTOModels
{
    public class CancelarPedidoResponse : ResponseGet
    {
        public CancelarPedidoResponse()
            : base()
        {
            Limit = 0;
            Offset = 0;
        }
    }
}