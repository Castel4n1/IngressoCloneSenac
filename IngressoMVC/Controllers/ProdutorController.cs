using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.RequestDTO;
using IngressoMVC.Models.ViewModels.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        public IActionResult Detalhes(int id)
        {
            var resultado = _context.Produtores.Include(p => p.Filmes).FirstOrDefault(p => p.Id == id);
            
            if (resultado == null)
                return View("NotFound");

            return View(resultado);
        }



        public IActionResult Criar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Criar(PostProdutorDTO produtorDto)
        {
            if (!ModelState.IsValid)
            {
                return View(produtorDto);
            }

            Produtor produtor = new Produtor(produtorDto.Nome, produtorDto.Bio, produtorDto.FotoPerfilURL);
            _context.Produtores.Add(produtor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int? id)
        {
            if (id == null)
                return View("NotFound");
            //Buscar o ator no banco
            var result = _context.Produtores.FirstOrDefault(p => p.Id == id);
            //Validação
            if (result == null) 
                return View("NotFound");
            //Passar o ator para View
            return View(result);
        }
        [HttpPost]
        public IActionResult Atualizar(int id, PostProdutorDTO produtorDto)
        {
            var result = _context.Produtores.FirstOrDefault(p => p.Id == id);

            if (!ModelState.IsValid)
                return View(result);

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
            if (result == null) return View("NotFound");
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
