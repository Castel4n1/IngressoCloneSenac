using IngressoMVC.Data;
using IngressoMVC.Models;
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
