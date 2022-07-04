using Microsoft.AspNetCore.Mvc;
using thegame.Services;

namespace thegame.Controllers;

[Route("api/games")]
public class GamesController : Controller
{
    private readonly IGameGenerator generator;
    private readonly IGameRepository repository;
    public GamesController(IGameGenerator generator, IGameRepository repository)
    {
        this.generator = generator;
        this.repository = repository;
    }
    
    [HttpPost]
    public IActionResult Index()
    {
        var field = generator.Generate(10, 10, 4);
        repository.SaveGame(field);
        return Ok(field);
    }
}