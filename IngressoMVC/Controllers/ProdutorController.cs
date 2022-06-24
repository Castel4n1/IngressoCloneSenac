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
    public class ProdutorController : Controller
    {
        private IngressoDbContext _context;

        public ProdutorController(IngressoDbContext context)
        {
            _context = context;
        }

        //comunicação com o banco de dados


        public IActionResult Index()
        {
            return View(_context.Produtores);
        }

       
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(PostProdutorDTO produtorDto)
        {
            if (!ModelState.IsValid || !produtorDto.FotoPerfilURL.EndsWith(".jpg"))
            {
                return View(produtorDto);
            }

            Produtor produtor = new Produtor(produtorDto.Nome, produtorDto.Bio, produtorDto.FotoPerfilURL);
            _context.Produtores.Add(produtor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int id)
        {
            //Buscar o ator no banco
            var result = _context.Produtores.FirstOrDefault(p => p.Id == id);
            //Validação
            if (result == null) 
                return View();
            //Passar o ator para View
            return View(result);
        }
        [HttpPost]
        public IActionResult ConfirmarAtualizar(int id, PostProdutorDTO produtorDto)
        {
            var result = _context.Produtores.FirstOrDefault(p => p.Id == id);

            result.AtualizarDados(produtorDto.Nome, produtorDto.Bio, produtorDto.FotoPerfilURL);
            _context.Produtores.Update(result);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Deletar(int id)
        {
            //Buscar o ator no banco
            var result = _context.Produtores.FirstOrDefault(p => p.Id == id);
            //validação
            if (result == null) return View();
            //passar o ator para view
            return View(result);
        }
        [HttpPost]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Produtores.FirstOrDefault(p => p.Id == id);
            _context.Produtores.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
