using GameStoreData;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using GameStoreModel;
using GameStoreWeb.Services;
using Microsoft.EntityFrameworkCore;

namespace GameStoreTests
{
    public class Tests
    {
        private Mock<GameContext> _mockGameContext;
        private Mock<DbSet<Game>> _mockDbSet;

        [SetUp]
        public void Setup()
        {
            var myGames = new List<Game>()
            {
                new Game()
                {
                    Id = 1,
                    Name = "Super Mario",
                    Description = "Mario should kill Thanos at each level to advance to the next.",
                    Rating = 4
                }, new Game()
                {
                    Id=2,
                    Name = "Counter Strike",
                    Description = "Choose either to be a terrorist or a counter Terrorist and fight against the other group by choosing any arena.",
                    Rating = 3
                }, new Game()
                {
                    Id=3,
                    Name = "FIFA 19",
                    Description = "Choose a team to play the amazing FIFA Football 2019.",
                    Rating = 5
                }
            };
            _mockGameContext = new Mock<GameContext>(new DbContextOptions<GameContext>());
            _mockDbSet = new Mock<DbSet<Game>>();
            _mockGameContext.Setup(m => m.Games).Returns(()=>_mockDbSet.Object);

            var queryable = myGames.AsQueryable();
            _mockDbSet.As<IQueryable<Game>>().Setup(m => m.Provider).Returns(queryable.Provider);
            _mockDbSet.As<IQueryable<Game>>().Setup(m => m.Expression).Returns(queryable.Expression);
            _mockDbSet.As<IQueryable<Game>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            _mockDbSet.As<IQueryable<Game>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            //_mockDbSet.As<IQueryable<Game>>().Setup(m => m.OrderByDescending()).Returns(() => queryable.GetEnumerator());
        }

        [Test]
        public void TheGetAllMethodMustReturnThreeRecords()
        {
            var sut = new GameService(_mockGameContext.Object);

            var result = sut.GetAllGames(true);

            Assert.AreEqual(result.Count(),3);
        }

        [Test]
        public void TheGetAllMethodMustReturnRatingsWithMostPopularFirst()
        {
            var sut = new GameService(_mockGameContext.Object);

            var result = sut.GetAllGames(true);

            Assert.AreEqual(result.FirstOrDefault().Name, "FIFA 19");
        }

        [Test]
        public void TheGetAllMethodMustReturnRatingsWithLeastPopularFirst()
        {
            var sut = new GameService(_mockGameContext.Object);

            var result = sut.GetAllGames(false);

            Assert.AreEqual(result.FirstOrDefault().Name, "Counter Strike");
        }

        [Test]
        public void TheGetGameMethodMustReturnGameDetails()
        {
            var sut = new GameService(_mockGameContext.Object);

            var result = sut.GetGameInfo(1);

            Assert.AreEqual(result.Name, "Super Mario");
        }

        [Test]
        public void UpdateGameMustSuccessfullyPass()
        {
            var sut = new GameService(_mockGameContext.Object);

            var result = sut.UpdateGameDetails(new Game(){
                Id = 1,
                Name = "Super Mario",
                Description = "Mario should kill Thanos at each level to advance to the next.",
                Rating = 4
            });
            Assert.AreEqual(result, 1);
        }
    }
}