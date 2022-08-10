using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.RequestDTO;
using IngressoMVC.Models.ViewModels.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var resultado = _context.Atores
                .Include(af => af.AtoresFilmes)
                .ThenInclude(f => f.Filme)
                .FirstOrDefault(ator => ator.Id == id);

            if (resultado == null)
                return View("NotFound");

            #region
            //Metodo Didático
            /*
             * public iactionresult Detalhes(int id)
             * {
             * 
             * var resultado = _context.Atores
             *      .Include(af => af.AtoresFilmes)
             *      .ThenInclude(f => f.Filme)
             *      .FirstOrDefault(ator => ator.Id == id);
             *      
             * GetAtoresDTO atorDTO = new GetAtoresDTO()
             * {
             *      Nome = resultado.Nome,
             *      Bio = resultado.Bio
             *      FotoPerfilURL = resultado.FotoPerfilURL,
             *      FotoURLFilmes = resultado.AtoresFilmes
             *              .Select(af => af.Filme.ImageURL).ToList()
             *      NomesFilmes = resultado.AtoresFilmes
             *              .Select(af => af.Filme.Titulo).ToList()          
             * };
             * 
             *      return View(atorDTO)
             * }
             */
            #endregion
            //passar um AtorGetDTO
            return View(resultado);
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
            Ator ator = new Ator(
                atorDto.Nome, 
                atorDto.Bio, 
                atorDto.FotoPerfilURL );

            //Gravar esse ator no banco de dados
            _context.Atores.Add(ator);

            //Salvar as mudanças
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #region
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
        #endregion
        public IActionResult Atualizar(int? id){

            // "?" serve para deixar o parametro opcional
            if(id == null) 
                return View();      

            var result = _context.Atores.FirstOrDefault(a => a.Id == id);

            if (result == null)
                return View("NotFound");

            //passa o ator na view
            return View(result);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostAtorDTO atorDto)
        {
            //busca ator no banco
            var result = _context.Atores.FirstOrDefault(a => a.Id == id);
            //atualiza no banco
            result.AtualizarDados(atorDto.Nome, atorDto.Bio, atorDto.FotoPerfilURL);

            //atualizar atores no banco
            _context.Atores.Update(result);
            //salva mudanças
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Deletar(int id){
            //Buscar o ator no banco
            var result = _context.Atores.FirstOrDefault(a => a.Id == id);
           
            //validação
            if (result == null)  return View("NotFound"); 
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
