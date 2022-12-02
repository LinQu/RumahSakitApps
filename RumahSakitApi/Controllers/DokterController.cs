using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RumahSakitApi.Models;
using RumahSakitWeb.Data;

namespace RumahSakitApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DokterController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public DokterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Dokter
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Dokter>>> GetDokter()
        {
            IEnumerable<Dokter> dokter = (IEnumerable<Dokter>)await _context.ParaDokter.ToListAsync();
            return Ok(dokter);
        }

        // GET: api/Dokter/5
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Dokter>> GetDokter(int id)
        {
            var dokter = await _context.ParaDokter.FindAsync(id);

            if (dokter == null)
            {
                return NotFound();
            }

            return dokter;
        }

        // PUT: api/Dokter/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutDokter(int id, Dokter dokter)
        {
            if (id != dokter.ID)
            {
                return BadRequest();
            }

            _context.Entry(dokter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DokterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dokter
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Create/")]
        public async Task<ActionResult<Dokter>> PostDokter(Dokter dokter)
        {

            _context.ParaDokter.Add(dokter);
            await _context.SaveChangesAsync();
            

            return CreatedAtAction("GetDokter", new { id = dokter.ID }, dokter);
        }

        // DELETE: api/Dokter/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteDokter(int id)
        {
            var dokter = await _context.ParaDokter.FindAsync(id);
            if (dokter == null)
            {
                return NotFound();
            }

            _context.ParaDokter.Remove(dokter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DokterExists(int id)
        {
            return _context.ParaDokter.Any(e => e.ID == id);

        }
    }
}
