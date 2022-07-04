using System;
using thegame.Models;

namespace thegame.Services;

public interface IGameRepository
{
    public GameDto FindById(Guid id);
    public void SaveGame(GameDto game);
}