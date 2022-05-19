using IngressoMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models
{
    public class FilmeCategoria : IEntidade
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }

        //RELACIONAMENTOS
        public int FilmeId { get; set; }
        public Filme Filme{ get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
