using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ninja2021.Models
{
    /// <summary>
    /// Database "connection " and all the tables virtuel
    /// </summary>
    public class DatabaseContext : DbContext
    {
        // det kan vi lige tale om senere DI
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        //public DbSet<className> yourTableName { get; set; }
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Battle> Battles { get; set; }
        // public DbSet<SamuraisInBattle> SamuraisInBattle { get; set; } behøves vi det?? skal vi have fundet ud af :)

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraisInBattle>().HasKey(relation => new
            {
                relation.samuraiId,
                relation.battleId
            });
        }
    }
}
