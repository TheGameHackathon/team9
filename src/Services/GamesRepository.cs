using System;
using System.Collections.Generic;
using thegame.Models;

namespace thegame.Services;

public class GamesRepository
{
    public void BFS(GameDto gameDto, string newColor)
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
        }
        
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

}