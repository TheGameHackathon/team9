using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers;

[Route("api/games/{gameId}/moves")]
public class MovesController : Controller
{
    private IGameChanger gameChanger;
    private IGameRepository gameRepository;

    public MovesController(IGameChanger gameChanger, IGameRepository gameRepository)
    {
        this.gameChanger = gameChanger;
        this.gameRepository = gameRepository;
    }
    
    [HttpPost]
    public IActionResult Moves(Guid gameId, [FromBody]UserInputDto userInput)
    {
        // var game = TestData.AGameDto(userInput.ClickedPos ?? new VectorDto {X = 1, Y = 1});
        // if (userInput.ClickedPos != null)
        //     game.Cells.First(c => c.Type == "color4").Pos = userInput.ClickedPos;
        // return Ok(game);

        var currentState = gameRepository.FindById(gameId);
        return Ok();
    }
}