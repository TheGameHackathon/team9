using System;
using System.Collections.Generic;
using thegame.Models;

namespace thegame.Services
{
    public class GamesRepository : IGamesRepository
    {
        private readonly Dictionary<Guid, GameDto> games = new Dictionary<Guid, GameDto>();

        public GameDto Insert(GameDto game)
        {
            if (game.Id != Guid.Empty)
                throw new InvalidOperationException();

            var id = Guid.NewGuid();
            var gameEntity = Clone(id, game);
            games[id] = gameEntity;
            return Clone(id, gameEntity);
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
}
