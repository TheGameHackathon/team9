using System.ComponentModel;

namespace thegame.Models;

public class StartGameDto
{
    [DefaultValue(1)]
    public int difficultyLevel { get; set; }
}