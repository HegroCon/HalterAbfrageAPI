using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using HalterAbfrageAPI.Models;

namespace HalterAbfrageAPI.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Person> Personen { get; set; }
        public DbSet<Fahrzeug> Fahrzeuge { get; set; }

        public MyDbContext(string connectionString) : base(connectionString) { }
        public MyDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>()
                .HasRequired(e => e.Stadt)
                .WithMany(c => c.Personen);

            modelBuilder.Entity<Fahrzeug>()
                .HasRequired(e => e.Person)
                .WithMany(c => c.fahrzeuge);

            base.OnModelCreating(modelBuilder);
        }

    }
}
