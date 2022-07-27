using IngressoMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models
{
    public class Categoria : IEntidade
    {
        public Categoria(string nome)
        {
            Nome = nome;
            DataCadastro = DateTime.Now;
            DataAlteracao = DataCadastro;
        }

        public int Id { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataAlteracao { get; private set; }
        public string Nome { get; private set; }

        public List<FilmeCategoria> FilmesCategorias { get; set; }

        public void AtualizaCategoria(string novoNome)
        {
            Nome = novoNome;
            DataAlteracao = DateTime.Now;
        }
    }
}
