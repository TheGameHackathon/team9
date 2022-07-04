using System;
using thegame.Models;

namespace thegame.Services;

public interface IGameRepository
{
    public GameDto FindById(Guid id);
}