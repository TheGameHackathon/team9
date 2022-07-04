using System;
using System.Collections.Generic;
using thegame.Models;

namespace thegame.Services;

public class GameChanger : IGameChanger
{
    private GameDto BFS(GameDto gameDto, string newColor)
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
        used.Add(start);
        while (queue.Count != 0)
        {
            var currentCell = queue.Dequeue();
            //used.Add(currentCell);
            var sides = GetSides(currentCell, gameDto);
            foreach (var toE in sides)
            {
                if (!used.Contains(toE))
                {
                    queue.Enqueue(toE);
                    used.Add(toE);
                }
            }

            currentCell.Type = newColor;
        }
        return gameDto;
    }
    
    private List<CellDto> GetSides(CellDto cell, GameDto gameDto)
    {
        List<CellDto> sides = new List<CellDto>();

        foreach (var nCell in gameDto.Cells)
        {
            if ((Math.Abs(nCell.Pos.X - cell.Pos.X) == 1 && Math.Abs(nCell.Pos.Y - cell.Pos.Y) == 0
                 || Math.Abs(nCell.Pos.X - cell.Pos.X) == 0 && Math.Abs(nCell.Pos.Y - cell.Pos.Y) == 1)
                && nCell.Type == cell.Type)
            {
                sides.Add(nCell);
            }
        }

        return sides;
    }
    public GameDto ChangeState(GameDto oldState, UserInputDto userInput, string newColor = null)
    {
        //string newColor = null;
        if (newColor == null)
        {
            foreach (var cell in oldState.Cells)
            {
                if (cell.Pos.X == userInput.ClickedPos.X && cell.Pos.Y == userInput.ClickedPos.Y)
                    newColor = cell.Type;
            }
        }

        return BFS(oldState,newColor);
    }
}