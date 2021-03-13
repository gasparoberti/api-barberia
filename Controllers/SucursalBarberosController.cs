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
    public class SucursalBarberosController : ControllerBase
    {
        private readonly barberia_bmContext _context;

        public SucursalBarberosController(barberia_bmContext context)
        {
            _context = context;
        }

        //// GET: api/SucursalBarberos
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<SucursalBarbero>>> GetSucursalBarberos()
        //{
        //    return await _context.SucursalBarberos.ToListAsync();
        //}

        //// GET: api/SucursalBarberos/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<SucursalBarbero>> GetSucursalBarbero(int id)
        //{
        //    var sucursalBarbero = await _context.SucursalBarberos.FindAsync(id);

        //    if (sucursalBarbero == null)
        //    {
        //        return NotFound();
        //    }

        //    return sucursalBarbero;
        //}
        
        // GET: api/SucursalBarberos/2
        [HttpGet("{barbero_id:int}")]
        public async Task<ActionResult<SucursalBarbero>> GetSucursalBarbero(int barbero_id)
        {
            var sucursalBarbero = await _context.SucursalBarberos.FindAsync(barbero_id);

            if (sucursalBarbero == null)
            {
                return NotFound();
            }

            return sucursalBarbero;
        }

        //// PUT: api/SucursalBarberos/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSucursalBarbero(int id, SucursalBarbero sucursalBarbero)
        //{
        //    if (id != sucursalBarbero.SucursalBarberoId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(sucursalBarbero).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SucursalBarberoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/SucursalBarberos
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<SucursalBarbero>> PostSucursalBarbero(SucursalBarbero sucursalBarbero)
        //{
        //    _context.SucursalBarberos.Add(sucursalBarbero);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetSucursalBarbero", new { id = sucursalBarbero.SucursalBarberoId }, sucursalBarbero);
        //}

        //// DELETE: api/SucursalBarberos/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteSucursalBarbero(int id)
        //{
        //    var sucursalBarbero = await _context.SucursalBarberos.FindAsync(id);
        //    if (sucursalBarbero == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.SucursalBarberos.Remove(sucursalBarbero);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool SucursalBarberoExists(int id)
        //{
        //    return _context.SucursalBarberos.Any(e => e.SucursalBarberoId == id);
        //}
    }
}
