using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using HalterAbfrageAPI.Models;

namespace HalterAbfrageAPI.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Person> Personen { get; set; }
        public DbSet<Fahrzeug> Fahrzeuge { get; set; }

        public MyDbContext(DbContextOptions options) : base(options) { }

    }
}
