using IngressoMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models
{
    public class Categoria : IEntidade
    {
        public Categoria(int id, string nome)
        {
            DataCadastro = DateTime.Now;
            DataAlteracao = DataCadastro;
            Nome = nome;
        }

        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string Nome { get; set; }

        public List<FilmeCategoria> FilmesCategorias { get; set; }
    }
}
