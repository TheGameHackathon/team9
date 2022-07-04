using Microsoft.AspNetCore.Mvc;
using thegame.Models;
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
    public IActionResult Index([FromBody] StartGameDto startGameDto)
    {
        var size = 10;
        switch (startGameDto.difficultyLevel)
        {  
            case 1:
                size = 10;
                break;
            case 2:
                size = 16;
                break;
            case 3:
                size = 22;
                break;
        }
        var field = generator.Generate(size, size, 4);
        var game = repository.Insert(field);
        return Ok(game);
    }
}