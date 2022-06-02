using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.RequestDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Controllers
{
    public class CategoriaController : Controller
    {
        private IngressoDbContext _context;

        public CategoriaController(IngressoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Categorias);
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(PostCategoriaDTO categoriaDto)
        {
            Categoria categoria = new Categoria(categoriaDto.Nome);
            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int id)
        {
            return View();
        }
        public IActionResult Deletar(int id)
        {
            return View();
        }
    }
}
