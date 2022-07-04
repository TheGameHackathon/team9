using thegame.Models;

namespace thegame.Services;

public interface IGameChanger
{
    public GameDto ChangeState(GameDto oldState, UserInputDto userInput);
}