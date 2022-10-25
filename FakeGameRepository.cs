using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eSport
{
    public class FakeGameRepository : IGameRepository
    {
        //The fake database

        //Game id
        //private Dictionary<int, Game> gameTable = new Dictionary<int, Game>();
        private List<Game> gameTable = new List<Game>();

        //Game id as key, List of gametypes associated with game
        private Dictionary<int, List<GameType>> gameTypeTable = new Dictionary<int, List<GameType>>();

        public FakeGameRepository()
        {

            //Create some initial data
            Game g1 = new Game()
            {
                homeTeam = "Furious4",
                awayTeam = "FreeDinner",
                description = "Furious4 vs FreeDinner",
                venue = "The Cellar",
                startDate = DateTime.Now.AddDays(14).AddHours(6)
            };

            Game g2 = new Game()
            {
                homeTeam = "MeetTheMighty",
                awayTeam = "FreekFrogz",
                description = "MeetTheMighty vs FreekFrogz",
                venue = "Open Space",
                startDate = DateTime.Now.AddDays(4).AddHours(5)
            };

            CreateGame(g1);
            CreateGame(g2);

        }

        public Game CreateGame(Game game)
        {
            //Handle if the game is already in the DB?
            
            //Get the next Id of the new Game
            int nextId = (gameTable.Count == 0) ? 0 : (gameTable.Select( g => g.id).Max() + 1);  
            game.id = nextId;
            gameTable.Add(game);
  
            return game;
        }

        public GameType CreateGameType(int gameId, GameType gameType)
        {

            //See if the gameID exists
            var gameToEdit = gameTable.Find(g => g.id == gameId);

            if(gameToEdit != null)
            {
                List<GameType> gameTypes;

                //Are there any GameTypes associated with this gameId?
                //If yes add one more else create the List structure to hold the GameType
                if (gameTypeTable.TryGetValue(gameId,out gameTypes))
                {

                    //Does the GameType already exist?
                    var gamesExist = gameTypes.Find(x => x.description == gameType.description);
                    if(gamesExist == null)
                    {
                        gameTypes.Add(gameType);
                    }
                    else
                    {
                        throw new GameTypeAlreadyExistsException($"The GameType \"{gameType.description}\" already exists.");
                    }
                    
                }
                else
                {
                    gameTypes = new List<GameType>();
                    gameTypes.Add(gameType);

                    gameTypeTable.Add(gameId, gameTypes);
                }

                return gameType;
            }
            else
            {
                throw new GameNotFoundException($"The game with id={gameId} was not found.");
            }
        }


        public IEnumerable<Game> ReadAllGames()
        {
            return gameTable;
        }

        public Game ReadGame(int gameId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GameType> ReadGameTypes(int gameId)
        {

            //Does the game exist?
            var game = gameTable.Find(g => g.id == gameId);
            if(game != null)
            {

                //Try to get all GameTypes associated with Game
                List<GameType> gameTypes;

                if (gameTypeTable.TryGetValue(gameId, out gameTypes))
                {
                    return gameTypes;
                }
                else
                {
                    return new List<GameType>();
                }
   
            }
            else
            {
                throw new GameNotFoundException($"The game with id={gameId} was not found.");
            }
        }

        public Game UpdateGame(Game game)
        {

            //Does the game exist?
            var gameToEdit = gameTable.Find(g => g.id == game.id);

            if (gameToEdit != null)
            {

                //Edit the values if they are set
                gameToEdit.description = game.description ?? gameToEdit.description;
                gameToEdit.venue = game.venue ?? gameToEdit.venue;

                //The if new date is not the default/not set
                if (game.startDate != default(DateTime)) gameToEdit.startDate = game.startDate;

                return gameToEdit;

            }
            else
            {
                throw new GameNotFoundException($"The game with id={game.id} was not found.");
            }
            
        }

        public GameType UpdateGameType(int gameId, GameType gameType)
        {

            //Does the game exist?
            var gameToEdit = gameTable.Find(g => g.id == gameId);

            if (gameToEdit != null)
            {

                List<GameType> gameTypes;
                
                //Does the Game have any GameTypes at all? 
                if(gameTypeTable.TryGetValue(gameId,out gameTypes))
                {

                    //Try to find the gametype to edit by description
                    var idGameType = gameTypes.Find(x => x.description==gameType.description);

                    if(idGameType != null)
                    {
                        //Update the odds
                        idGameType.outcomeOdds = gameType.outcomeOdds;

                        return idGameType;
                    }
                    else
                    {
                        throw new GameTypeNotFoundException($"The GameType \"{gameType.description}\" was not found.");
                    }                  
                }
                else
                {
                    throw new GameTypeNotFoundException($"No GameTypes are associated with Game id{gameId}");
                }
            }
            else
            {
                throw new GameNotFoundException($"The game with id={gameId} was not found.");
            }
        }
    }
}
