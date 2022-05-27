using IngressoMVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Data
{
    public class InicializadorDeDados
    {
        public static void Inicializar(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope
                    .ServiceProvider
                    .GetService<IngressoDbContext>();
                context.Database.EnsureCreated();

                if(!context.Cinemas.Any())
                {
                    context.Cinemas
                        .Add(new Cinema("Cinemark", "Texto desc...", "http://www.atoupeira.com.br/wp-content/uploads/2017/06/Cinemark-logo.jpg"));
                         context.SaveChanges();

                }
                if (!context.Atores.Any())
                {
                    context.Atores.AddRange(new List<Ator>()
                    {
                        new Ator("Robert Downey Jr.", "Bio desc...","https://www.themoviedb.org/t/p/w300_and_h450_bestv2/5qHNjhtjMD4YWH3UP0rm4tKwxCL.jpg"),
                        new Ator("Henry Cavill","Bio desc...","https://www.themoviedb.org/t/p/w300_and_h450_bestv2/hErUwonrQgY5Y7RfxOfv8Fq11MB.jpg"),
                        new Ator("Gal Gadot","Bio desc...","https://www.themoviedb.org/t/p/w300_and_h450_bestv2/plLfB60M5cJrnog8KvAKhI4UJuk.jpg")

                    });
                }

                if (!context.Produtores.Any())
                {
                    context.Produtores.AddRange(new List<Produtor>()
                    {
                        new Produtor("Martin Scorsese", "Bio desc...","https://www.themoviedb.org/person/1032-martin-scorsese?language=pt-BR#"),
                        new Produtor("Tim Burton","Bio desc...","https://www.themoviedb.org/person/510-tim-burton?language=pt-BR#"),
                        new Produtor("Produtor","Bio desc...","")
                    });
                    context.SaveChanges();
                }
                if (!context.Categorias.Any())
                {
                    context.Categorias.AddRange(new List<Categoria>()
                    {
                        new Categoria("Ação"),
                        new Categoria("Ficção"),
                        new Categoria("Aventura"),
                        new Categoria("Romance"),
                        new Categoria("Terror")
                    });
                    context.SaveChanges();
                }

                if (!context.Filmes.Any())
                {
                    context.Filmes.AddRange(new List<Filme>
                    { 
                        new Filme("Liga da Justiça","Descrição..", 100,"https://www.themoviedb.org/t/p/w300_and_h450_bestv2/geyu6rplpbp7OUeOfB2uRVf1LpG.jpg",1,1),   
                        new Filme("Sherlock Holmes: O Jogo de Sombras ","Descrição..",100,"https://www.themoviedb.org/movie/58574-sherlock-holmes-a-game-of-shadows?language=pt-BR#",1,2)
                    });
                    context.SaveChanges();
                }

                if(!context.FilmesCategorias.Any())
                {
                    context.FilmesCategorias.AddRange(new List<FilmeCategoria>()
                    { 
                        new FilmeCategoria(1, 1),
                        new FilmeCategoria(1, 2),
                        new FilmeCategoria(1, 3),
                        new FilmeCategoria(2, 2),
                        new FilmeCategoria(2, 4),
                        new FilmeCategoria(2, 5)
                    });
                    context.SaveChanges();
                }
                if(!context.AtoresFilmes.Any())
                {
                    context.AtoresFilmes.AddRange(new List<AtorFilme>()
                    {
                        new AtorFilme(1,2),
                        new AtorFilme(2,1),
                        new AtorFilme(3,2)
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
