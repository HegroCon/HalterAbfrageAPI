using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using HalterAbfrageAPI.Models;
using System.Runtime.CompilerServices;

namespace HalterAbfrageAPI.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Person> Personen { get; set; }
        public DbSet<Fahrzeug> Fahrzeuge { get; set; }
        public DbSet<Stadt> Stadt { get; set; }


        //public MyDbContext(string connectionString) : base(connectionString) { }

        public MyDbContext(DbContextOptions options) : base(options) { }
        public MyDbContext() { }



    }
}
