using System;
using thegame.Models;

namespace thegame.Services;

public interface IGamesRepository
{
    public GameDto Insert(GameDto game);
    public GameDto FindById(Guid id);
}