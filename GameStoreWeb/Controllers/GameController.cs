using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStoreModel;
using GameStoreWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }
        // GET: api/Game
        [HttpGet]
        public IEnumerable<Game> Get(bool mostPopular)
        {
            return _gameService.GetAllGames(false);
        }

        // GET: api/Game/5
        [HttpGet("{id}", Name = "Get")]
        public Game Get(int id)
        {
            return _gameService.GetGameInfo(id);
        }

        // POST: api/Game
        //[HttpPost]
        //public void Post([FromBody] Game value)
        //{
        //}

        // PUT: api/Game/5
        [HttpPut("{id}")]
        public int Put([FromBody] Game value)
        {
            return _gameService.UpdateGameDetails(value);
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
