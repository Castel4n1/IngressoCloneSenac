using IngressoMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models
{
    public class Produtor : Artista
    {
        public Produtor(string nome, string bio, string fotoPerfilURL) : base(nome, bio, fotoPerfilURL)
        {
        }

        public List<Filme> Filmes { get; set; }
    }
}
