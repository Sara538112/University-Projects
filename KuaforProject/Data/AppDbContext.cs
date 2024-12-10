using b221210566_2_.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static b221210566_2_.Models.Manager;

namespace b221210566_2_.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration configuration;
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
           : base(options)
        {
            this.configuration = configuration;
        }
        public DbSet<HCutEmp> HCutE { get; set; }
        public DbSet<HCareEmp> HCareE { get; set; }
        public DbSet<HDyeEmp> HDyeE { get; set; }
        public DbSet<ManikurE> ManikurE { get; set; }
        public DbSet<PadikurE> PadikurE { get; set; }

        public DbSet<HCutSv> HCutS { get; set; }
        public DbSet<HCareSv> HCareS { get; set; }
        public DbSet<HDyeSv> HDyeS { get; set; }
        public DbSet<ManikurS> ManikurS { get; set; }
        public DbSet<PadikurS> PadikurS { get; set; }


        public DbSet<Manager.GeneralManager> GManager { get; set; }
        public DbSet<Manager.SalonManager> SManager { get; set; }
        public DbSet<Manager.FinancialManager> FManagers { get; set; }


        public DbSet<CustomerData> Customers { get; set; }

        public DbSet<SalonOperation.Appointments> Appointments { get; set; }
        public DbSet<SalonOperation.Scudle> Scudles { get; set; }

        public DbSet<Servises.HCut> HairCuts { get; set; }
        public DbSet<Servises.HCare> HairCare { get; set; }
        public DbSet<Servises.HDye> HairDye { get; set; }
        public DbSet<Servises.Manikur> Manicure { get; set; }
        public DbSet<Servises.Pedikur> Pedicure { get; set; }







        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servises.HCut>().HasNoKey();
            modelBuilder.Entity<Servises.HCare>().HasNoKey();
            modelBuilder.Entity<Servises.HDye>().HasNoKey();
            modelBuilder.Entity<Servises.Manikur>().HasNoKey();
            modelBuilder.Entity<Servises.Pedikur>().HasNoKey();

            base.OnModelCreating(modelBuilder);

        }

       


    }

}
