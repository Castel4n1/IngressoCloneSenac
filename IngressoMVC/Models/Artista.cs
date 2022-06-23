using IngressoMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models
{
    public abstract class Artista : IEntidade
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

        [Display(Name = "Nome")] //DataAnnotations
        public string Nome { get; private set; }
        [Display(Name = "Biografia")]
        public string Bio { get; private set; }
        [Display(Name = "Foto")]
        public string FotoPerfilURL { get;  private set; }

        public void AtualizarDados(string nome, string bio, string fotoPerfilURL)
        {
            Nome = nome;
            Bio = bio;
            FotoPerfilURL = fotoPerfilURL;
            DataAlteracao = DateTime.Now;
        }
    }
}
