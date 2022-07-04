using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers;

[Route("api/games/{gameId}/moves")]
public class MovesController : Controller
{
    private readonly IGameChanger gameChanger;
    private readonly IGameRepository gameRepository;
    
    public MovesController(IGameChanger gameChanger, IGameRepository gameRepository)
    {
        this.gameChanger = gameChanger;
        this.gameRepository = gameRepository;
    }

    [HttpPost]
    public IActionResult Moves(Guid gameId, [FromBody]UserInputDto userInput)
    {
        /*var game = TestData.AGameDto(userInput.ClickedPos ?? new VectorDto {X = 1, Y = 1});
        if (userInput.ClickedPos != null)
            game.Cells.First(c => c.Type == "color4").Pos = userInput.ClickedPos;
        return Ok(game);*/

        var game = gameRepository.FindById(gameId);
        if (game == null)
            return NotFound();
        var newGame = gameChanger.ChangeState(game, userInput);

        newGame.Score++;

        var color = newGame.Cells.First().Type;

        newGame.IsFinished = newGame.Cells.All(cell => cell.Type == color);
        gameRepository.Update(newGame);

        return Ok(newGame);
    }
}