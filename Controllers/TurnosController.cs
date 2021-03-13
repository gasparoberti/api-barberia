using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_barberia.Data;
using api_barberia.Models;

namespace api_barberia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        private readonly barberia_bmContext _context;

        public TurnosController(barberia_bmContext context)
        {
            _context = context;
        }

        // GET: api/Turnos
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Turno>>> GetTurnos()
        //{
        //    return await _context.Turnos.ToListAsync();
        //}

        // GET: api/Turnos/2021-03-13
        [HttpGet]
        [Route("{fecha:datetime}")]
        public async Task<ActionResult<IEnumerable<Turno>>> GetTurnoPorFecha(DateTime fecha)
        {
            return await _context.Turnos.Where(t => t.Fecha.Date == fecha.Date).AsNoTracking().ToListAsync();
        }

        // GET: api/Turnos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Turno>> GetTurno(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);

            if (turno == null)
            {
                return NotFound();
            }

            return turno;
        }

        // PUT: api/Turnos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurno(int id, Turno turno)
        {
            if (id != turno.TurnoId)
            {
                return BadRequest();
            }

            _context.Entry(turno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurnoExists(id))
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

        // POST: api/Turnos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Turno>> PostTurno(Turno turno)
        {
            _context.Turnos.Add(turno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTurno", new { id = turno.TurnoId }, turno);
        }

        // DELETE: api/Turnos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurno(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null)
            {
                return NotFound();
            }

            _context.Turnos.Remove(turno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TurnoExists(int id)
        {
            return _context.Turnos.Any(e => e.TurnoId == id);
        }
    }
}
