using BetCore.Providers;
using BetCoreModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetCore.Data
{
    public class BetCoreDbContext : DbContext
    {
        public BetCoreDbContext(DbContextOptions<BetCoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(x => x.Mail).IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var fact = new LoggerFactory();
            fact.AddProvider(new SQLLoggerProvider());
            optionsBuilder.UseLoggerFactory(fact);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<BetCoreModels.Models.Match> Match { get; set; }

        public DbSet<BetCoreModels.Models.Serie> Serie { get; set; }
    }
}
