﻿using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.RequestDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Controllers
{
    public class CinemaController : Controller
    {
        private IngressoDbContext _context;

        public CinemaController(IngressoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Cinemas);
        }

        public IActionResult Detalhes(int id)
        {
            var cinema = _context.Cinemas
                .Include(c => c.Filmes)
                .FirstOrDefault(c => c.Id == id);

            if (cinema == null) return View("NotFound");

            return View(cinema);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(PostCinemaDTO cinemaDto)
        {
            if (!ModelState.IsValid) return View(cinemaDto);


            Cinema cinema = new Cinema(cinemaDto.Nome, cinemaDto.Descricao, cinemaDto.LogoURL);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int id)
        {
            var result = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id); //BUSCA NO BANCO DE DADOS

            if (result == null)
            {
                return View("NotFound");
            }

            return View(result);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostCinemaDTO cinemaDTO)
        {
            var result = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            //ATUALIZAR OS DADOS DO RESULTADO COM OS DA DTO
            result.AtualizarDados(cinemaDTO.Nome, cinemaDTO.Descricao, cinemaDTO.LogoURL);

            _context.Cinemas.Update(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int id)
        {

            var result = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id); //BUSCA NO BANCO DE DADOS

            if (result == null)
            {
                return View ("NotFound");
            }

            _context.SaveChanges();

            return View(result);
        }

        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar (int id)
        {
            var result = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if(result == null)
            {
                return View("Not Found");
            }

            _context.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
