using System;
using GameStoreModel;
using Microsoft.EntityFrameworkCore;

namespace GameStoreData
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> optionsBuilder)
        :base(optionsBuilder)
        {
        }

        public virtual DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
