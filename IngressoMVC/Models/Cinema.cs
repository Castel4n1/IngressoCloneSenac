using IngressoMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models
{
    public class Cinema : IEntidade
    {
        public Cinema(string nome, string descricao, string logoURL, List<Filme> filmes)
        {
            DataCadastro = DateTime.Now;
            DataAlteracao = DataCadastro;
            Nome = nome;
            Descricao = descricao;
            LogoURL = logoURL;
            Filmes = filmes;
        }

        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string LogoURL { get; set; }

        public List<Filme> Filmes { get; set; }
    }
}
