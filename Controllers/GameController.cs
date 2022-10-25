using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace eSport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {

        //The repository (Here a simulated CRUD database)
        IGameRepository gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }


        [HttpGet]
        [Route("/api/v1/games")]
        [Produces("application/json")]
        public IEnumerable<Game> GetAllGames()
        {
            //Get all available games
            var allGames = gameRepository.ReadAllGames();

            return allGames;
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("/api/v1/games")]
        public IActionResult AddGame([FromBody] Game game)
        {

            //Create a new game
            var createdGame = gameRepository.CreateGame(game);

            return Ok(createdGame);

        }

        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("/api/v1/games/{id}")]
        public IActionResult EditGame([FromBody]Game game,[FromRoute] int id)
        {

            try
            {
                game.id = id;
                var newGameData = gameRepository.UpdateGame(game);

                return Ok(newGameData);
            }
            catch(GameNotFoundException gameNotFound)
            {
                return BadRequest(gameNotFound.Message);
            }     
        }


        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("/api/v1/games/{id}/gametypes")]
        public IActionResult AddGameType([FromRoute] int id,[FromBody] GameType gameType)
        {

            try
            {
                //Create a GameType associated with the Game and return it
                var createdGameType = gameRepository.CreateGameType(id,gameType);

                return Ok(createdGameType);
            }
            catch (GameNotFoundException gamenotfound)
            {
                return BadRequest(gamenotfound.Message);
            }
            catch (GameTypeAlreadyExistsException gameTypeAlreadyExists)
            {
                return BadRequest(gameTypeAlreadyExists.Message);
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("/api/v1/games/{id}/gametypes")]
        public IActionResult GetGameTypes([FromRoute] int id)
        {
            try
            {
                //Get the gametypes associated with game (id)
                var allGames = gameRepository.ReadGameTypes(id);

                return Ok(allGames);
            }
            catch(GameNotFoundException gameNotFound)
            {
                return BadRequest(gameNotFound.Message);
            }

        }

        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("/api/v1/games/{id}/gametypes")]
        public IActionResult EditGameTypes([FromRoute] int id, [FromBody] GameType gameType)
        {
            try
            {
                if (gameType.outcomeOdds.Count == 0) return BadRequest("Odds were not set");
                
                var updatedGameType = gameRepository.UpdateGameType(id,gameType);

                return Ok(updatedGameType);
            }
            catch (GameNotFoundException gameNotFound)
            {
                return BadRequest(gameNotFound.Message);
            }
            catch(GameTypeNotFoundException gameTypeNotFound)
            {
                return BadRequest(gameTypeNotFound.Message);
            }

        }
    }
}
