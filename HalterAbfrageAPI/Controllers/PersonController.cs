using HalterAbfrageAPI.Data;
using HalterAbfrageAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HalterAbfrageAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly MyDbContext _context;
        
        public PersonController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPersonen()
        {
            return Ok(await _context.Personen
                .ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Person>>> GetPersonById(int id)
        {
            var person = await _context.Personen
                .FirstOrDefaultAsync(p => p.Id == id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }
        
       // [HttpPost]
       // public async Task<ActionResult<Person>> CreatePerson(Person person)
       // {
       //     if (!await _context.Personen.AnyAsync(p => p.Id == person.Id))
       //         return BadRequest("Invalid Person");
       //
       //     _context.Personen.Add(person);
       //     await _context.SaveChangesAsync();
       //
       //     return CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person);
       // }
       // [HttpPut]
       // public async Task<ActionResult<Person>> UpdatePerson(Person person)
       // {
       //     if (!await _context.Personen.AnyAsync(p => p.Id == person.Id))
       //         return BadRequest("Invalid Person");
       //
       //     if (await _context.Personen.ContainsAsync(person))
       //     {
       //         _context.Personen.Update(person);
       //         await _context.SaveChangesAsync();
       //         return Ok(person);
       //     }
       //     return BadRequest("Person nicht gefunden");
       // }
       // [HttpDelete("{id}")]
       // public async Task<ActionResult<Fahrzeug>> DeletePerson(int id)
       // {
       //     var p = await _context.Personen.FindAsync(id);
       //
       //     if (p == null)
       //         return BadRequest("Person nicht gefunden");
       //
       //     _context.Personen.Remove(p);
       //     await _context.SaveChangesAsync();
       //
       //     return Ok("Person entfernt");
       // }
    }
}