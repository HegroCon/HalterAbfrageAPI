using HalterAbfrageAPI.Data;
using HalterAbfrageAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HalterAbfrageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
                .Include(e => e.Stadt)
                .ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Person>>> GetPersonById(int id)
        {
            var person = await _context.Personen
                .Include(e => e.Stadt)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        [HttpGet("{Nachname}/{Geburtstag}")]
        public async Task<ActionResult<List<Person>>> GetPersonByNameAndBirthday(string nachname, DateTime geburtstag)
        {
            var person = await _context.Personen
                .Include(e => e.Stadt)
                .FirstOrDefaultAsync(e => e.Name == nachname && e.Birthday == geburtstag);
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> CreatePerson(Person person)
        {
            if (!await _context.Stadt.AnyAsync(p => p.Plz == person.StadtId))
                return BadRequest("Invalid Stadt");

            person.Stadt = null;

            _context.Personen.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person);
        }

        [HttpPut]
        public async Task<ActionResult<Person>> UpdatePerson(Person person)
        {
            if (!await _context.Stadt.AnyAsync(p => p.Plz == person.StadtId))
                return BadRequest("Invalid Stadt");

            person.Stadt = null;

            if (await _context.Personen.ContainsAsync(person))
            {
                _context.Personen.Update(person);
                await _context.SaveChangesAsync();
                return Ok(person);
            }
            return BadRequest("Person nicht gefunden");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson(int id)
        {
            var e = await _context.Personen.FindAsync(id);

            if (e == null)
                return BadRequest("Person nicht gefunden");

            _context.Personen.Remove(e);
            await _context.SaveChangesAsync();

            return Ok("Person entfernt");
        }
    }
}
