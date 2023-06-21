using HalterAbfrageAPI.Data;
using HalterAbfrageAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HalterAbfrageAPI
{
    public class HalterAbfrageService : IHalterAbfrageService
    {
        private MyDbContext _context;

        public HalterAbfrageService(MyDbContext context)
        {
            _context = context;
        }
        //GetPersonByKennzeichen
        //GetPersonById
        //GetFahrzeugById
        public async Task<Fahrzeug> GetFahrzeugByKennzeichen(string kennzeichen)
        {
            var fahrzeug = await _context.Fahrzeuge
                .Include(e => e.Person)
                .Include(p => p.Person.Stadt)
                .FirstOrDefaultAsync(e => e.Kennzeichen == kennzeichen);
            
            return fahrzeug;
        }
    }
}
