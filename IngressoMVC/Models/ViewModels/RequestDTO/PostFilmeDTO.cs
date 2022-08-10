using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostFilmeDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string ImageURL { get; set; }
        public DateTime DataLancamento { get; private set; }
        public DateTime DataEncerramento { get; private set; }

        #region Relacionamentos
        //RELACIONAMENTOS
        public string NomeProdutor { get; set; }

        public int ProdutorId { get; set; }
        public int CinemaId { get; set; }


        public List<int> AtoresId { get; set; }
        public List<int> CategoriasId { get; set; }


        #endregion

    }
}
