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
    public class PedidosController : Controller
    {
        #region Carrinho

        private CarrinhoModel carrinho {get;set;}

        [HttpPut("/Carrinho")]
        public bool Put(LivroModel item)
        {
            if (carrinho == null)
            {
                carrinho = new CarrinhoModel();
            }
            carrinho.AddItem(item);
            
            return true;
        }

/*        [HttpGet("/Carrinho/{idCarrinho}")]
        public CarrinhoModel GetCarrinho(int idCarrinho)
        {
            return carrinho;
        }*/
        [HttpGet("/Carrinho/{idCarrinho}")]
        public string GetCarrinho(int idCarrinho)
        {
            return "teste";
        }

        #endregion

        [HttpPut("/ConfirmarPedido/Carrinho/{idCarrinho}")]
        public ConfirmarPedidoResponse ConfirmarPedido(int idCarrinho)
        {
            ConfirmarPedidoResponse result = new ConfirmarPedidoResponse();

            // Pedido Gravado na base de dados
            result.Pedido = carrinho.ConfirmarPedido();
            
            if (result.Pedido != null)
                result.StatusCode = 200;
            else
                result.StatusCode = 204;

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

                EditoraModel editoraMock = new EditoraModel()
                {
                    IdEditora = 1,
                    Nome = "Abril"
                };

                AutorModel autorMock = new AutorModel()
                {
                    IdAutor = 1,
                    Nome = "Homero",
                    SobreNome = string.Empty
                };

                LivroModel livroMock = new LivroModel()
                {
                    Isbn = 654321,
                    Editora = editoraMock,
                    AnoLancamento = DateTime.Now,
                    Titulo = "Odisseia"
                };
                livroMock.ListaAutores.Add(autorMock);

                pedido.AddItemPedido(livroMock);
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

                EditoraModel editoraMock = new EditoraModel()
                {
                    IdEditora = 1,
                    Nome = "Abril"
                };

                AutorModel autorMock = new AutorModel()
                {
                    IdAutor = 1,
                    Nome = "Homero",
                    SobreNome = string.Empty
                };

                LivroModel livroMock = new LivroModel()
                {
                    Isbn = 654321,
                    Editora = editoraMock,
                    AnoLancamento = DateTime.Now,
                    Titulo = "Odisseia",
                    Valor = 49                    
                };
                livroMock.ListaAutores.Add(autorMock);
                
                pedido.AddItemPedido(livroMock);
                result.Pedidos.Add(pedido);
                result.StatusCode = 200;
            }
            else
                result.StatusCode = 204;
            return result;
        }

        [HttpPut("/cancelar/{idPedido}")]
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
