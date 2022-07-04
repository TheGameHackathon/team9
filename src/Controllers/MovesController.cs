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
    private IGameChanger gameChanger;

    public MovesController(IGameChanger gameChanger)
    {
        this.gameChanger = gameChanger;
    }

    [HttpPost]
    public IActionResult Moves(Guid gameId, [FromBody]UserInputDto userInput)
    {
        /*var game = TestData.AGameDto(userInput.ClickedPos ?? new VectorDto {X = 1, Y = 1});
        if (userInput.ClickedPos != null)
            game.Cells.First(c => c.Type == "color4").Pos = userInput.ClickedPos;
        return Ok(game);*/

        var game = GamesRepository.FloodFillGameDto();
        var newGame = gameChanger.ChangeState(game, userInput);

        newGame.Score++;

        var color = newGame.Cells.First().Type;

        newGame.IsFinished = newGame.Cells.All(cell => cell.Type == color);

        return Ok(newGame);
    }
}