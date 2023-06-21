using HalterAbfrageAPI.Data;
using HalterAbfrageAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HalterAbfrageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadtController : ControllerBase
    {
        private readonly MyDbContext _context;

        public StadtController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Stadt>>> GetStaedte()
        {
            return Ok(await _context.Stadt
                .ToListAsync());
        }

        [HttpGet("{plz}")]
        public async Task<ActionResult<List<Stadt>>> GetStadtByPlz(string plz)
        {
            var stadt = await _context.Stadt
                .FirstOrDefaultAsync(e => e.Plz == plz);
            if (stadt == null)
                return NotFound();
            return Ok(stadt);
        }

        [HttpPost]
        public async Task<ActionResult<Stadt>> CreateStadt(Stadt stadt)
        {
            _context.Stadt.Add(stadt);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStadtByPlz), new { plz = stadt.Plz }, stadt);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStadt(Stadt stadt)
        {
            if (await _context.Stadt.ContainsAsync(stadt))
            {
                _context.Stadt.Update(stadt);
                await _context.SaveChangesAsync();
                return Ok(stadt);
            }
            return BadRequest("Person nicht gefunden");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStadt(string plz)
        {
            var e = await _context.Stadt.FindAsync(plz);

            if (e == null)
                return BadRequest("Stadt nicht gefunden");

            _context.Stadt.Remove(e);
            await _context.SaveChangesAsync();

            return Ok("Stadt entfernt");
        }
    }
}
