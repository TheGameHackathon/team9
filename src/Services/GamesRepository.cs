using System;
using System.Collections.Generic;
using System.Linq;
using thegame.Models;

namespace thegame.Services;

public class GamesRepository : IGameRepository
{

    private readonly Dictionary<Guid, GameDto> games;

    public GamesRepository()
    {
        games = new Dictionary<Guid, GameDto>();
    }
    
    public GameDto Insert(GameDto game)
    {
        if (game.Id != Guid.Empty)
            throw new InvalidOperationException();

        var id = Guid.NewGuid();
        var gameEntity = Clone(id, game);
        games[id] = gameEntity;
        return Clone(id, gameEntity);
    }

    public GameDto Update(GameDto game)
    {
        if (!games.ContainsKey(game.Id))
            throw new InvalidOperationException();
        games[game.Id] = game;
        return game;
    }

    public GameDto FindById(Guid id)
    {
        return games.TryGetValue(id, out GameDto game) ? Clone(id, game) : null;
    }

    private GameDto Clone(Guid id, GameDto game)
    {
        return new GameDto(game.Cells, game.MonitorKeyboard, game.MonitorMouseClicks, game.Width, game.Height, 
            id, game.IsFinished, game.Score);
    }
}