using IngressoMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models
{
    public class Ator : Artista
    {
        public Ator(string nome, string bio, string fotoPerfilURL) : base(nome, bio, fotoPerfilURL)
        {
        }

        public List<AtorFilme> AtoresFilmes { get; set; }

    }
}
