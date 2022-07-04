using System;
using System.Collections.Generic;
using thegame.Models;

namespace thegame.Services;

public class GameGenerator : IGameGenerator
{
    public GameDto Generate(int width, int height, int colorCount)
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

        return new GameDto
            (
                cells.ToArray(),
                true,
                true,
                width, 
                height,
                Guid.Empty,
                false, 
                0
            );
    }
}