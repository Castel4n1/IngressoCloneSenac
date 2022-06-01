using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostAtorDTO
    {
        public string Nome { get; private set; }
        public string Bio { get; private set; }
        public string FotoPerfilURL { get; private set; }
    }
}
