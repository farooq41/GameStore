using System.Collections.Generic;
using System.Linq;
using GameStoreData;
using GameStoreModel;

namespace GameStoreWeb.Services
{
    public class GameService : IGameService
    {
        private GameContext _context;
        public GameService(GameContext context)
        {
            _context = context;
        }
        public IEnumerable<Game> GetAllGames(bool mostPopular)
        {
            if (mostPopular)
            {
                return _context.Games.OrderByDescending(game => game.Rating);
            }
            return _context.Games.OrderBy(game => game.Rating); ;
        }

        public Game GetGameInfo(int id)
        {
            return _context.Games.FirstOrDefault(game => game.Id == id);
        }

        public int UpdateGameDetails(Game game)
        {
            _context.Games.Update(game);
            _context.SaveChanges();
            return game.Id;
        }
    }
}
