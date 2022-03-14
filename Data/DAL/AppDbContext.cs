using Core.Entity.AdminPanelEntityes;
using Core.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Cargos> Cargos { get; set; }
      public DbSet<TurkishStorage> TurkishStorages { get; set; }
        public DbSet<DeclaredCargos> DeclaredCargos { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Shops> Shops{ get; set; }
        public DbSet<Flights> Flights{ get; set; }
    }
}
