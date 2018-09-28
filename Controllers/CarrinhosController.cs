using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LivrariaAPI.Models;
using LivrariaAPI.DTOModels;

namespace LivrariaAPI.Controllers
{
    [Route("LivrariaAPI/v1/[controller]")]
    public class CarrinhosController : Controller
    {
        [HttpPost]
        public CarrinhoGet Post(int idCarrinho,[FromBody] PedidoItem item)
        {
            CarrinhoGet result = new CarrinhoGet();
            CarrinhoModel carrinho = null;

            // Obter carrinho com o id enviado ou criar um novo carrinho
            if (idCarrinho == 0)
                carrinho = new CarrinhoModel();
            else
                carrinho = new CarrinhoModel(idCarrinho);

            carrinho.AddItem(item);

            result.Itens.Add(carrinho);
            result.StatusCode = 200;

            return result;
        }

        [HttpGet("{idCarrinho}")]
        public CarrinhoGet Get(int idCarrinho)
        {
            CarrinhoGet result = new CarrinhoGet();

            if (idCarrinho == 1)
            {
                CarrinhoModel carrinho = new CarrinhoModel();

                carrinho.IdCarrinho = 1;

                PedidoItem item = new PedidoItem() 
                {
                    Isbn = 123456,
                    Valor = 59,
                    Titulo = "Odisseia"
                };

                carrinho.Itens.Add(item);

                result.Itens.Add(carrinho);
                result.StatusCode = 200;
            }
            return result;
        }
    }
}