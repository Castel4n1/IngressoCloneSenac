using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostAtorDTO
    {
        //VALIADOÇÕES COM DATA-ANNOTATIONS

        [Required(ErrorMessage = "Nome do Ator é Obrigatório!")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Nome do ator deve ter no máximo 50 Caracteres e no minimo 3")]
        public string Nome { get; set; }

        
        public string Bio { get; set; }

        [Required(ErrorMessage ="Imagem Obrigatória")]
        public string FotoPerfilURL { get; set; }
    }
}
