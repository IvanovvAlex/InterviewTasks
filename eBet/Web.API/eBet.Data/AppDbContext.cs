using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.RegularExpressions;
using eBet.Data.Entities;

namespace eBet.Data
{
    public class AppDbContext : DbContext
    {
        private string connectionString;

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public AppDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<Sport> Sports { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<MatchEvent> Matches { get; set; }
        public DbSet<Bet> Bets { get; set; }

        public DbSet<Odd> Odds { get; set; }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=.;Database=eBetDB;Integrated Security=True;TrustServerCertificate=true;");
        //    }
        //}
    }
}

