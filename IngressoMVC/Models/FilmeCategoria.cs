using IngressoMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models
{
    public class FilmeCategoria : IEntidade
    {
        public FilmeCategoria(int filmeId, int categoriaId)
        {
            FilmeId = filmeId;
            CategoriaId = categoriaId;
        }

        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }

        //RELACIONAMENTOS
        [Key]
        public int FilmeId { get; set; }
        public Filme Filme{ get; set; }

        [Key]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
