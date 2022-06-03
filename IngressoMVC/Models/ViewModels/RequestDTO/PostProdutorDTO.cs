using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostProdutorDTO
    {   
        [Required(ErrorMessage ="É Obrigatório o nome do Produtor!")]
        [StringLength(maximumLength:50, MinimumLength =3, ErrorMessage ="Maximo 50 Caracteres, Minimo 3.")]
        public string Nome { get; set; }
        public string Bio { get; set; }
        [Required(ErrorMessage ="Obrigatório imagem no formato JPG")]
        public string FotoPerfilURL { get; set; }
    }
}
