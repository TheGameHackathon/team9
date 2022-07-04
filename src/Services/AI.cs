using System;
using System.Collections.Generic;
using thegame.Models;

namespace thegame.Services;

public class AI
{

    /*public GameDto MakeStep(GameDto gameDto, string newColor)
    {
        string chooseColor = PreProcess(gameDto);
        return;
    }*/

    private string PreProcess(GameDto gameDto)
    {
        Dictionary<string, int> counter = new Dictionary<string, int>();
        DSU dsu = new DSU();
        //GameChanger gameChanger = new GameChanger();
        CellDto startPos = null;
        foreach (var cell in gameDto.Cells)
        {
            if (cell.Pos.X == 0 && cell.Pos.Y == 0)
            {
	            startPos = cell;
            }
        }

        var firstComponent = new HashSet<CellDto>(); 
        dsu.GetComponent(gameDto, startPos, firstComponent);
        HashSet<CellDto> used = new HashSet<CellDto>(firstComponent);

        foreach (var start in firstComponent)
        {
            counter[start.Type] += dsu.GetComponent(gameDto, start, used);
        }

        int maxVal = -1;
        string resultColor = null;
        foreach (var data in counter)
        {
            if (maxVal < data.Value)
            {
                maxVal = data.Value;
                resultColor = data.Key;
            }
        }

        return resultColor;
    }
}

public class DSU
{
    public int GetComponent(GameDto gameDto, CellDto startPos, HashSet<CellDto> used)
        {
            //HashSet<CellDto> used = new HashSet<CellDto>();
            Queue<CellDto> queue = new Queue<CellDto>();
            queue.Enqueue(startPos);
            int elementsCount = 0;
            while (queue.Count != 0)
            {
                var currentCell = queue.Dequeue();
                used.Add(currentCell);
                elementsCount++;
                var sides = GetSides(currentCell, gameDto);
                foreach (var toE in sides)
                {
                    if (!used.Contains(toE))
                        queue.Enqueue(toE);
                }
            }

            return elementsCount - 1;
        }
        
        public List<CellDto> GetSides(CellDto cell, GameDto gameDto)
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
}