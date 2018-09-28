using System;
using System.Collections.Generic;
using LivrariaAPI.Models;

namespace LivrariaAPI.DTOModels
{
    public class CarrinhoGet : ResponseGet
    {
        public List<CarrinhoModel> Itens { get; set; }

        public CarrinhoGet(int limit = 0, int offset = 0)
            : base()
        {
            Limit = limit;
            Offset = offset;
            Itens = new List<CarrinhoModel>();
        }
    }
}