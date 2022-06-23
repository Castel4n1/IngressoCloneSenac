using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.RequestDTO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IngressoMVC.Controllers
{
    public class AtoresController : Controller
    {
        private IngressoDbContext _context;

        public AtoresController(IngressoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Atores);
        }

        public IActionResult Detalhes(int id)
        {            
            return View(_context.Atores.Find(id));
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(PostAtorDTO atorDto)
        {

            //Validar os dados
            if (!ModelState.IsValid || !atorDto.FotoPerfilURL.EndsWith(".jpg")) {
                return View(atorDto);
            }
            //Instanciar um novo ator que recebe os dados
            Ator ator = new Ator(atorDto.Nome, atorDto.Bio, atorDto.FotoPerfilURL);

            //Gravar esse ator no banco de dados
            _context.Atores.Add(ator);

            //Salvar as mudanças
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        //[HttpPost]
        //public IActionResult Criar([Bind("Nome,Bio,FotoPerfilURL")] Ator ator)
        //{


        //    //Receber dados e instânciar = [Bind("Nome,Bio,FotoPerfilURL")] Ator ator)

        //    //Validar os dados

        //    //Gravar esse ator no banco de dados
        //    _context.Atores.Add(ator);

        //    //Salvar as mudanças
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult Atualizar(int id){
            return View();
        }

        
        public IActionResult Deletar(int id){
            //Buscar o ator no banco
            var result = _context.Atores.FirstOrDefault(a => a.Id == id);
            //validação
            if (result == null) { return View(); }
            //passar o ator para view
            return View(result);
        }

        [HttpPost, ActionName("ConfirmarDeletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Atores.FirstOrDefault(a => a.Id == id);
            _context.Atores.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



    }
}
