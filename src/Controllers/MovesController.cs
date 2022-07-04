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
    public GameDto BFS(GameDto gameDto, string newColor)
    {
        CellDto start = null;
        HashSet<CellDto> used = new HashSet<CellDto>();
        foreach (var point in gameDto.Cells)
        {
            if (point.Pos.X == 0 && point.Pos.Y == 0)
            {
                start = point;
                break;
            }
        }
        Queue<CellDto> queue = new Queue<CellDto>();
        queue.Enqueue(start);

        while (queue.Count != 0)
        {
            var currentCell = queue.Dequeue();
            used.Add(currentCell);
            var sides = GetSides(currentCell, gameDto);
            foreach (var toE in sides)
            {
                if (!used.Contains(toE))
                    queue.Enqueue(toE);
            }

            currentCell.Type = newColor;
        }
        return gameDto;
    }

    public List<CellDto> GetSides(CellDto cell, GameDto gameDto)
    {
        List<CellDto> sides = new List<CellDto>();

        foreach (var nCell in gameDto.Cells)
        {
            if (Math.Abs(nCell.Pos.X - cell.Pos.X + nCell.Pos.Y - cell.Pos.Y) == 1
                && nCell.Type == cell.Type)
            {
                sides.Add(nCell);
            }
        }

        return sides;
    }

    public GameDto ChangeState(GameDto oldState, UserInputDto userInput)
    {
        string newColor = null;
        foreach (var cell in oldState.Cells)
        {
            if (cell.Pos.X == userInput.ClickedPos.X && cell.Pos.Y == userInput.ClickedPos.Y)
                newColor = cell.Type;
        }
        return BFS(oldState,newColor);
    }
    
    [HttpPost]
    public IActionResult Moves(Guid gameId, [FromBody]UserInputDto userInput)
    {
        /*var game = TestData.AGameDto(userInput.ClickedPos ?? new VectorDto {X = 1, Y = 1});
        if (userInput.ClickedPos != null)
            game.Cells.First(c => c.Type == "color4").Pos = userInput.ClickedPos;
        return Ok(game);*/

        var game = GamesRepository.FloodFillGameDto();
        var newGame = ChangeState(game, userInput);

        newGame.Score++;
        return Ok(newGame);
    }
}