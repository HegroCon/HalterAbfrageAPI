using HalterAbfrageAPI.Data;
using HalterAbfrageAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HalterAbfrageAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FahrzeugController : ControllerBase
    {
        private readonly MyDbContext _context;
        public FahrzeugController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Fahrzeug>>> GetFahrzeuge()
        {
            return Ok(await _context.Fahrzeuge
                .Include(e => e.Person)
                .ToListAsync());
        }

        [HttpGet("{kennzeichen}")]
        //public async Task<ActionResult<List<Fahrzeug>>> GetFahrzeug(string kennzeichen)
            public async Task<ActionResult<Fahrzeug>> GetFahrzeug(string kennzeichen)
        {
            var fahrzeug = await _context.Fahrzeuge
                .Include(e => e.Person)
                
                .FirstOrDefaultAsync(e => e.Kennzeichen == kennzeichen);
            if (fahrzeug == null)
                return NotFound();
            return Ok(fahrzeug);
        }
        
        [HttpPost]
        public async Task<ActionResult<Fahrzeug>> CreateFahrzeug(Fahrzeug fahrzeug)
        {
            if (!await _context.Personen.AnyAsync(p => p.Id == fahrzeug.Person.Id))
                return BadRequest("Invalid Person");

            fahrzeug.Person = null;

            _context.Fahrzeuge.Add(fahrzeug);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFahrzeug), new { kennzeichen = fahrzeug.Kennzeichen }, fahrzeug);
        }
        [HttpPut]
        public async Task<ActionResult<Fahrzeug>> UpdateEmployee(Fahrzeug fahrzeug)
        {
            if (!await _context.Personen.AnyAsync(p => p.Id == fahrzeug.Person.Id))
                return BadRequest("Invalid Person");

            fahrzeug.Person = null;

            if (await _context.Fahrzeuge.ContainsAsync(fahrzeug))
            {
                _context.Fahrzeuge.Update(fahrzeug);
                await _context.SaveChangesAsync();
                return Ok(fahrzeug);
            }
            return BadRequest("Fahrzeug nicht gefunden");
        }
        [HttpDelete("{kennzeichen}")]
        public async Task<ActionResult<Fahrzeug>> DeleteFahrzeug(string kennzeichen)
        {
            var e = await _context.Fahrzeuge.FindAsync(kennzeichen);

            if (e == null)
                return BadRequest("Fahrzeug nicht gefunden");

            _context.Fahrzeuge.Remove(e);
            await _context.SaveChangesAsync();

            return Ok("Fahrzeug entfernt");
        }
    }
}