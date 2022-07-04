using System;

namespace thegame.Models;

public class GameEntity
{
    public GameEntity(CellDto[,] cells, int width, int height, Guid id, bool isFinished, int score)
    {
        Cells = cells;
        Width = width;
        Height = height;
        
    }

    public CellDto[,] Cells { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public Guid Id { get; set; }
    public bool IsFinished { get; set; }
    public int Score { get; set; }
}