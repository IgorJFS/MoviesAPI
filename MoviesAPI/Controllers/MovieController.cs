using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using static System.Net.WebRequestMethods;

namespace MoviesAPI.Controllers;


[ApiController]
[Route("[controller]")]

public class MovieController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;
    [HttpPost]
    public void AdicionaFilme([FromBody]Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Duracao);
    }

    [HttpGet]
    public IEnumerable<Filme> LerFilmes()
    {
        return filmes;
    }
    [HttpGet("{id}")]
    public Filme? RecuperaFilmePorId(int id)
    {
        return filmes.FirstOrDefault(filme => filme.Id == id);
    }
}
