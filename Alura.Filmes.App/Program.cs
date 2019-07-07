using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();

                //var ator = new Ator();
                //ator.PrimeiroNome = "Christian";
                //ator.UltimoNome = "Bale";
                //contexto.Entry(ator).Property("last_update").CurrentValue = DateTime.Now;

                //contexto.Atores.Add(ator);
                //contexto.SaveChanges();

                //var ator = contexto.Atores.First();
                //Console.WriteLine(ator);
                //Console.WriteLine(contexto.Entry(ator).Property("last_update").CurrentValue);

                //var atores = contexto.Atores
                //    .OrderByDescending(a => EF.Property<DateTime>(a, "last_update"))
                //    .Take(10);

                //foreach (var ator in atores)
                //{
                //    Console.WriteLine(ator + " - " + contexto.Entry(ator).Property("last_update").CurrentValue);
                //}

                //var filme = contexto.Filmes
                //    .Include(f => f.Atores)
                //    .ThenInclude(fa => fa.Ator)
                //    .First();
                //Console.WriteLine(filme);
                //Console.WriteLine("Elenco:");

                //foreach (var ator in filme.Atores)
                //{
                //    Console.WriteLine(ator.Ator);
                //}

                //var categoria = contexto.Categorias
                //        .Include(f => f.Filmes)
                //        .ThenInclude(fa => fa.Filme)
                //        .First();
                //Console.WriteLine(categoria);
                //Console.WriteLine("Filmes:");

                //foreach (var filme in categoria.Filmes)
                //{
                //    Console.WriteLine(filme.Filme);
                //}

                //var idiomas = contexto.Idiomas.Include(i => i.FilmesFalados);

                //foreach (var idioma in idiomas)
                //{
                //    Console.WriteLine(idioma);

                //    foreach (var filme in idioma.FilmesFalados)
                //    {
                //        Console.WriteLine(filme);
                //    }
                //    Console.WriteLine("\n");
                //}

                //var ator1 = new Ator { PrimeiroNome = "Emma", UltimoNome = "Watson" };
                //var ator2 = new Ator { PrimeiroNome = "Emma", UltimoNome = "Watson" };
                //contexto.Atores.AddRange(ator1, ator2);
                //contexto.SaveChanges();

                //var emmaWatson = contexto.Atores
                //    .Where(a => a.PrimeiroNome == "Emma" && a.UltimoNome == "Watson");
                //Console.WriteLine($"Total de atores encontrados: {emmaWatson.Count()}.");

                //var filme = new Filme();
                //var idioma = new Idioma { Nome = "English" };
                //filme.Titulo = "Senhor dos Aneis";
                //filme.Duracao = 120;
                //filme.AnoLancamento = "2000";
                //filme.Classificacao = ClassificacaoIndicativa.MaioresQue14;
                //filme.IdiomaFalado = idioma;

                //contexto.Filmes.Add(filme);
                //contexto.SaveChanges();

                //var filmeInserido = contexto.Filmes.First(a => a.Titulo == "Senhor dos Aneis");
                //Console.WriteLine(filmeInserido.Classificacao);

                //Console.WriteLine("Clientes:");
                //foreach (var cliente in contexto.Clientes)
                //{
                //    Console.WriteLine(cliente);
                //}

                //Console.WriteLine("\nFuncionários");
                //foreach (var func in contexto.Funcionarios)
                //{
                //    Console.WriteLine(func);
                //}

                //var sql = @"select b.*
                //            from actor b
                //            inner join top5_most_starred_actors filmes on filmes.actor_id = b.actor_id";

                //var atoresMaisAtuantes = contexto.Atores.FromSql(sql).Include(a => a.Filmografia);

                //foreach (var ator in atoresMaisAtuantes)
                //{
                //    Console.WriteLine($"O ator {ator.PrimeiroNome} {ator.UltimoNome} atuou em {ator.Filmografia.Count} filmes");
                //}

                var categ = "Action";

                var paramCateg = new SqlParameter("category_name", categ);
                var paramTotal = new SqlParameter
                {
                    ParameterName = "@total_actors",
                    Size = 4,
                    Direction = System.Data.ParameterDirection.Output
                };

                contexto.Database
                    .ExecuteSqlCommand("total_actors_from_given_category @category_name, @total_actors OUT", paramCateg, paramTotal);

                Console.WriteLine($"O total de atores na categoria {categ} é de {paramTotal.Value}.");

                var sql = "INSERT INTO language (name) VALUES ('Teste 1'), ('Teste 2'), ('Teste 3')";
                var registros = contexto.Database.ExecuteSqlCommand(sql);
                Console.WriteLine($"O total de registros afetados é {registros}.");

                var deleteSql = "DELETE FROM language WHERE name LIKE 'Teste%'";
                registros = contexto.Database.ExecuteSqlCommand(deleteSql);
                Console.WriteLine($"O total de registros afetados é {registros}.");
            }
        }
    }
}