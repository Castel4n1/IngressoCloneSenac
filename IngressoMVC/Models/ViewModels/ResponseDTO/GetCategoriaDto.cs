using System.ComponentModel.DataAnnotations;

namespace IngressoMVC.Models.ViewModels.ResponseDTO
{
    public class GetCategoriaDto
    {
        [Display(Name = "Nome")]
        public string Nome { get; set; }
    }
}
