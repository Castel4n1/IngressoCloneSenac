using System.ComponentModel.DataAnnotations;

namespace IngressoMVC.Models.ViewModels.ResponseDTO
{
    public class GetFilmeDto
    {
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }

    }
}
