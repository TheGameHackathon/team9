using thegame.Models;

namespace thegame.Services;

public interface IAI
{
    public GameDto MakeStep(GameDto gameDto, IGameChanger gameChanger);
}