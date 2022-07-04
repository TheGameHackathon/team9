using System;
using System.Collections.Generic;
using System.Linq;
using thegame.Models;

namespace thegame.Services;

public class GamesRepository : IGameRepository
{
    private static GameDto floodFillCells;

    public static GameDto FloodFillGameDto() => floodFillCells;


    public GameDto FindById(Guid id)
    {
        return floodFillCells;
    }

    public void SaveGame(GameDto game)
    {
        floodFillCells = game;
    }
}