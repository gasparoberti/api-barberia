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
    public class SucursalServiciosController : ControllerBase
    {
        private readonly barberia_bmContext _context;

        public SucursalServiciosController(barberia_bmContext context)
        {
            _context = context;
        }

        //// GET: api/SucursalServicios
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<SucursalServicio>>> GetSucursalServicios()
        //{
        //    return await _context.SucursalServicios.ToListAsync();
        //}
        
        // GET: api/SucursalServicios/1
        [HttpGet]
        [Route("{sucursal_id:int}")]
        public async Task<ActionResult<IEnumerable<SucursalServicio>>> GetSucursalServicios(int sucursal_id)
        {
            return await _context.SucursalServicios.Where(s => s.SucursalId == sucursal_id).AsNoTracking().ToListAsync();
        }

        //// GET: api/SucursalServicios/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<SucursalServicio>> GetSucursalServicio(int id)
        //{
        //    var sucursalServicio = await _context.SucursalServicios.FindAsync(id);

        //    if (sucursalServicio == null)
        //    {
        //        return NotFound();
        //    }

        //    return sucursalServicio;
        //}

        //// PUT: api/SucursalServicios/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSucursalServicio(int id, SucursalServicio sucursalServicio)
        //{
        //    if (id != sucursalServicio.SucursalServicioId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(sucursalServicio).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SucursalServicioExists(id))
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

        //// POST: api/SucursalServicios
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<SucursalServicio>> PostSucursalServicio(SucursalServicio sucursalServicio)
        //{
        //    _context.SucursalServicios.Add(sucursalServicio);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetSucursalServicio", new { id = sucursalServicio.SucursalServicioId }, sucursalServicio);
        //}

        //// DELETE: api/SucursalServicios/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteSucursalServicio(int id)
        //{
        //    var sucursalServicio = await _context.SucursalServicios.FindAsync(id);
        //    if (sucursalServicio == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.SucursalServicios.Remove(sucursalServicio);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool SucursalServicioExists(int id)
        //{
        //    return _context.SucursalServicios.Any(e => e.SucursalServicioId == id);
        //}
    }
}
