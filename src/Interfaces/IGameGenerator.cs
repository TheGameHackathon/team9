using thegame.Models;

namespace thegame.Services;

public interface IGameGenerator
{
    public GameDto Generate(int width, int height, int colorCount);
}