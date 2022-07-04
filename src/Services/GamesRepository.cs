using System;
using System.Collections.Generic;
using System.Linq;
using thegame.Models;

namespace thegame.Services;

public class GamesRepository
{
    private static GameDto floodFillCells;

    public static GameDto FloodFillGameDto() => floodFillCells;

    public static GameDto NewFloodFillGameDto(int width, int height, int colorCount)
    {
        var random = new Random();

        var cells = new List<CellDto>();
        var id = 1;

        for (var i = 0; i < width; ++i)
        for (var j = 0; j < height; ++j)
        {
            cells.Add(
                new CellDto(id.ToString(),
                    new VectorDto { X = i, Y = j },
                    $"color{random.Next(colorCount) + 1}",
                    "",
                    0));
            id++;
        }

        floodFillCells = new GameDto(cells.ToArray(), true, true, width, height, Guid.Empty, false, 0);
        return floodFillCells;
    }
}