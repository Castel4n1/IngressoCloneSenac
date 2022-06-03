using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostCategoriaDTO
    {
        [Required(ErrorMessage ="Requer uma Categoria Obrigatória!")]
        public string Nome { get;  set; }

    }
}
