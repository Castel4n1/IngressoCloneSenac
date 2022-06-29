﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models.ViewModels.ResponseDTO
{
    public class GetAtoresDTO
    {

        [Display(Name = "Nome")] //DataAnnotations
        public string Nome { get; set; }
        
        [Display(Name = "Biografia")]
        public string Bio { get; set; }

        [Display(Name = "Foto")]
        public string FotoPerfilURL { get; set; }

        public List<string> NomeFilmes { get; set; }
        public List<string> FotoURLFilmes { get; set; }
    }
}
