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
    public class PagamentosController : Controller
    {
        [HttpPost]
        public async Task Post([FromBody] PedidoModel pedido)
        {
            // Consumir API de transacao de pagamento
        } 
    }
}