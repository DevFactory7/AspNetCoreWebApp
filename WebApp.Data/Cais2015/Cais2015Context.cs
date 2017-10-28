using Microsoft.EntityFrameworkCore;
using System;
using WebApp.Data.Cais2015.Models;

namespace WebApp.Data.Cais2015
{
    public class Cais2015Context : DbContext
    {
        public Cais2015Context(DbContextOptions options) : base(options) { }

        public DbSet<BMainMenu> BMainMenus { get; set; }

    }
}
