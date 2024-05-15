using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppCelulares.Entidades;

namespace AppCelulares.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CelularesController : ControllerBase
    {
        private readonly DbContext _context;

        public CelularesController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Celulares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Celular>>> GetCelular()
        {
            return await _context.Celulares.ToListAsync();
        }

        // GET: api/Celulares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Celular>> GetCelular(int id)
        {
            var celular = await _context.Celulares.FindAsync(id);

            if (celular == null)
            {
                return NotFound();
            }

            return celular;
        }

        // PUT: api/Celulares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCelular(int id, Celular celular)
        {
            if (id != celular.Id)
            {
                return BadRequest();
            }

            _context.Entry(celular).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CelularExists(id))
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

        // POST: api/Celulares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Celular>> PostCelular(Celular celular)
        {
            _context.Celulares.Add(celular);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCelular", new { id = celular.Id }, celular);
        }

        // DELETE: api/Celulares/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCelular(int id)
        {
            var celular = await _context.Celulares.FindAsync(id);
            if (celular == null)
            {
                return NotFound();
            }

            _context.Celulares.Remove(celular);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CelularExists(int id)
        {
            return _context.Celulares.Any(e => e.Id == id);
        }
    }
}
