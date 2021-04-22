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
            //Database.EnsureCreated() // ver 2.1
            //Database.EnsureCreated
            //Database.Migrate();
        }

        //public DbSet<className> yourTableName { get; set; }
        public DbSet<Samurai> Samurais { get; set; }
    }
}
