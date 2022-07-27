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
    public class FilmeController : Controller
    {
        private IngressoDbContext _context;

        public FilmeController(IngressoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Filmes);
        }

        public IActionResult Detalhes(int id)
        {

            return View(_context.Filmes.Find(id));
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(PostFilmeDTO filmeDto)
        {

            Filme filme = new Filme
                (
                    filmeDto.Titulo,
                    filmeDto.Descricao,
                    filmeDto.Preco,
                    filmeDto.ImageURL,
                    _context.Produtores
                        .FirstOrDefault(x => x.Id == filmeDto.ProdutorId).Id
                );

            _context.Add(filme);
            _context.SaveChanges();

            //Incluir Relacionamentos
            foreach (var atorId in filmeDto.AtoresId)
            {

                var novaCategoria = new FilmeCategoria(atorId, filme.Id);
                _context.FilmesCategorias.Add(novaCategoria);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int id)
        {
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);
            
                if (result == null)
                return View("NotFound");

            return View(result);
        }
        [HttpPost]
        public IActionResult Atualizar(int id, PostFilmeDTO filmeDto)
        {
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);
            if (!ModelState.IsValid)
                return View(result);

            result.AlterarDados(filmeDto.Titulo, filmeDto.Descricao, filmeDto.ImageURL, filmeDto.Preco);

            _context.Update(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Deletar(int id)
        {
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View("NotFound");

            return View(result);
        }
        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);

            _context.Remove(result);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }
    }
}
