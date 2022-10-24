using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eSport
{
    public interface IGameRepository
    {

        Game CreateGame(Game game);

        Game ReadGame(int gameId);

        Game UpdateGame(Game game);

        //bool DeleteGame(int gameId);

        IEnumerable<Game> ReadAllGames();

        IEnumerable<GameType> ReadGameTypes(int gameId);

        GameType CreateGameType(int gameId, GameType gameType);

        GameType UpdateGameType(int gameId, GameType gameType);

        //bool DeleteGameType(Game game, GameType gameType);

    }
}
