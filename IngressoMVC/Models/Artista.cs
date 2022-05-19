using IngressoMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models
{
    public class Artista : IEntidade
    {
        public Artista(string nome, string bio, string fotoPerfilURL)
        {
            DataCadastro = DateTime.Now;
            DataAlteracao = DataCadastro;
            Nome = nome;
            Bio = bio;
            FotoPerfilURL = fotoPerfilURL;
        }

        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }

        public string Nome { get; private set; }
        public string Bio { get; private set; }
        public string FotoPerfilURL { get;  private set; }
    }
}
