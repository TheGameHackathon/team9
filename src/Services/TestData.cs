using System;
using thegame.Models;

namespace thegame.Services;

public class TestData
{
    public static GameDto AGameDto(VectorDto movingObjectPosition)
    {
        var width = 16;
        var height = 16;
        var rnd = new Random();
        var cells = new CellDto[height * width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0;j < width; j++)
            {
                cells[width * i + j] = new CellDto(
                    "1", new VectorDto { X = i, Y = j }, $"color{rnd.Next(4)}", "", 0
                    );
            }
        }
        var testCells = new[]
        {
            new CellDto("1", new VectorDto {X = 2, Y = 4}, "color1", "", 0),
            new CellDto("2", new VectorDto {X = 5, Y = 4}, "color1", "", 0),
            new CellDto("3", new VectorDto {X = 3, Y = 1}, "color2", "", 20),
            new CellDto("4", new VectorDto {X = 1, Y = 0}, "color2", "", 20),
            new CellDto("5", movingObjectPosition, "color4", "☺", 10),
        };
        return new GameDto(cells, true, true, width, height, Guid.Empty, movingObjectPosition.X == 0, movingObjectPosition.Y);
    }
}