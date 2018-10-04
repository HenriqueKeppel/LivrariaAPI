using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LivrariaAPI.Models;
using LivrariaAPI.DTOModels;
using LivrariaAPI.Services;

namespace LivrariaAPI.Controllers
{
    [Route("LivrariaAPI/v1/[controller]")]
    public class LivrosController : Controller
    {
        // GET api/values
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<LivrosGet> Get([FromQuery]int limit, int offset, string titulo, int idEditora, DateTime anoLancamento)
        {
            // Loga que iniciou o processo de get
            await LoggerService.RegistrarLog("Get: LivrariaAPI/v1/Livros");

            LivrosGet result = new LivrosGet(limit, offset);

            AutorModel autorMock = new AutorModel()
            {
                IdAutor = 1,
                Nome = "Homero",
                SobreNome = string.Empty
            };

            EditoraModel editoraMock = new EditoraModel()
            {
                IdEditora = 1,
                Nome = "Abril"
            };

            LivroModel livroMock1 = new LivroModel()
            {
                Isbn = 123456,
                AnoLancamento = DateTime.Now,
                Editora = editoraMock,
                Titulo = "Iliada"
            };

            LivroModel livroMock = new LivroModel()
            {
                Isbn = 654321,
                Editora = editoraMock,
                AnoLancamento = DateTime.Now,
                Titulo = "Odisseia"
            };

            livroMock1.ListaAutores.Add(autorMock);
            livroMock.ListaAutores.Add(autorMock);

            if (string.IsNullOrEmpty(titulo))
            {
                result.Livros.Add(livroMock);
                result.Livros.Add(livroMock1);
            }
            else if (titulo == "Iliada")
                result.Livros.Add(livroMock1);
            else if (titulo == "Odisseia")
                result.Livros.Add(livroMock);

            if (result.Livros.Count == 0)
                result.StatusCode = 204;
            else
                result.StatusCode = 200;

            return result;
        }

        // GET api/values/5
        [HttpGet("{isbn}")]
        [ProducesResponseType(200)]
        public LivrosGet Get(int isbn)
        {
            LivrosGet result = new LivrosGet();

            EditoraModel editoraMock = new EditoraModel()
            {
                IdEditora = 1,
                Nome = "Abril"
            };

            LivroModel livroMock = new LivroModel()
            {
                Isbn = 654321,
                Editora = editoraMock,
                AnoLancamento = DateTime.Now,
                Titulo = "Odisseia"
            };

            AutorModel autorMock = new AutorModel()
            {
                IdAutor = 1,
                Nome = "Homero",
                SobreNome = string.Empty
            };

            livroMock.ListaAutores.Add(autorMock);

            if (isbn == 654321)
                result.Livros.Add(livroMock);;

            if (result.Livros.Count == 0)
                result.StatusCode = 204;
            else
                result.StatusCode = 200;

            return result;
        }

        // GET api/values/5
        [HttpGet("{isbn}/Autores")]
        [ProducesResponseType(200)]
        public AutoresGet GetAutores(int isbn)
        {
            AutoresGet result = new AutoresGet();

            if (isbn == 654321 || isbn == 123456)
            {
                AutorModel autorMock = new AutorModel()
                {
                    IdAutor = 1,
                    Nome = "Homero",
                    SobreNome = string.Empty
                };

                result.Autores.Add(autorMock);
            }

            if (result.Autores.Count == 0)
                result.StatusCode = 204;
            else
                result.StatusCode = 200;

            return result;
        }

        [HttpGet("{isbn}/Comentarios/")]
        public ComentariosGet ComentarioGet(int isbn,[FromQuery] int limit, int offset)
        {
            ComentariosGet result = new ComentariosGet(limit, offset);

            if (isbn == 123456)
            {
                ComentarioModel comentario = new ComentarioModel()
                {
                    IdComentario = 1,
                    IdLivro = 123456,
                    Usuario = "Henrique",
                    Texto = "É um livro muito bom, porem de leitura complexa.",
                    Nota = 9
                };

                result.Comentarios.Add(comentario);
            }

            if (result.Comentarios.Count == 0)
                result.StatusCode = 204;
            else
                result.StatusCode = 200;

            return result;
        }

        [HttpPost("{isbn}/Comentario")]
        [ProducesResponseType(200)]
        public int ComentarioPost(ComentarioModel comentario)
        {
            if (comentario != null)
                return 200;
            return 204;
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(202)]
        public int Post(LivrosPost livrosPost)
        {
            int linhasAfetadas = 0;

            foreach (LivroModel livro in livrosPost.Livros)
            {
                linhasAfetadas++;
            }

            return linhasAfetadas;
        }

        // PUT api/values/5
        [HttpPut("{isbn}")]
        [ProducesResponseType(202)]
        public string Put(int isbn, [FromBody]string value)
        {
            return "Isbn: 4, Titulo: teste, IdEditora: 4";
        }

        // DELETE api/values/5
        [HttpDelete("{Isbn}")]
        [ProducesResponseType(200)]
        public void Delete(int id)
        {
        }
    }
}
