using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStoreModel;

namespace GameStoreWeb.Services
{
    public interface IGameService
    {
        IEnumerable<Game> GetAllGames(bool mostPopular);
        Game GetGameInfo(int id);

        int UpdateGameDetails(Game game);


    }
}
