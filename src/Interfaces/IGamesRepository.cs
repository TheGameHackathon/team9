using System;
using thegame.Models;

namespace thegame.Services;

public interface IGameRepository
{
    public GameDto FindById(Guid id);
    public GameDto Insert(GameDto game);
    public GameDto Update(GameDto game);
}