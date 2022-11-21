using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AM.Infrastructure
{
    public class AMContext: DbContext
    {

        public  DbSet<Plane> Planes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Traveller> Travellers { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=AirportManagementDB;Integrated Security=true;
              MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            //2éme méthode
            // modelBuilder.Entity<Plane>().ToTable("MyPlanes");
            //modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());

            //configurer l'héritage TPT(table par type)
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");

            //configurer la table proteuse de données "ticket"
            modelBuilder.Entity<Ticket>().HasKey(t => new { t.PassengerFK,t.FlightFK });

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
        //    // Pre-convention model configuration goes here
        //    configurationBuilder
        //        .Properties<string>()
        //        .HaveMaxLength(50);
        //configurationBuilder
        //    .Properties<decimal>()
        //        .HavePrecision(8,3);
              configurationBuilder
              .Properties<DateTime>()
                  .HaveColumnType("date");
        }



    }
}
