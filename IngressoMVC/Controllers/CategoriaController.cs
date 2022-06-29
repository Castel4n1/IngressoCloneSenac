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

        public IActionResult Index() => View(_context.Categorias);

        public IActionResult Detalhes(int id) => View(_context.Categorias.Find(id));

        public IActionResult Criar() => View();

        [HttpPost]
        public IActionResult Criar(PostCategoriaDTO categoriaDto)
        {
            if (!ModelState.IsValid) return View(categoriaDto);

            Categoria categoria = new Categoria(categoriaDto.Nome);
            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int? id)
        {
            if (id == null) 
                return View();

            var result = _context.Categorias.FirstOrDefault(c => c.Id == id);

            if(result == null)
                return View();

            return View(result);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostCategoriaDTO categoriaDto)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);

            categoria.AtualizaCategoria(categoriaDto.Nome);

            _context.Categorias.Update(categoria);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);

            if (categoria == null)
                return View();

            return View(categoria);
        }
        [HttpPost]
        public IActionResult ConfirmarDeletar(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);

            if (categoria == null)
                return View();

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
