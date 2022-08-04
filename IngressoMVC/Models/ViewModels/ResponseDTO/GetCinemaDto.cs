using System.ComponentModel.DataAnnotations;

namespace IngressoMVC.Models.ViewModels.ResponseDTO
{
    public class GetCinemaDto
    {
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "LogoURL")]
        public string LogoURL { get; set; }



    }
}

