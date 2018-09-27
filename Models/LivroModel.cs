using System;
using System.Collections.Generic;

namespace LivrariaAPI.Models
{
    public class LivroModel
    {
        public int Isbn { get;set;  }
        public string Titulo { get;set;  }
        public EditoraModel Editora { get;set;  }
        public DateTime AnoLancamento { get;set; }
        public Decimal Valor { get; set; }

        public List<AutorModel> ListaAutores { get;set; }

        public LivroModel()
        {
            ListaAutores = new List<AutorModel>();
        }
    }
}
