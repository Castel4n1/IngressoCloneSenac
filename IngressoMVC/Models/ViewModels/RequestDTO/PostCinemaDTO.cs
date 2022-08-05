using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostCinemaDTO
    {
        [Required(ErrorMessage ="É Necessário Utilizar um nome")]
        [StringLength(maximumLength:50, MinimumLength =3, ErrorMessage ="Max 50, Min 3 Caracteres.")]
        public string Nome { get;  set; }

        public string Descricao { get;  set; }

        [Required(ErrorMessage ="Obrigatório Logo")]
        public string LogoURL { get;  set; }
    }
}
