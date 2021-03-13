﻿using System;
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
    public class BarberosController : ControllerBase
    {
        private readonly barberia_bmContext _context;

        public BarberosController(barberia_bmContext context)
        {
            _context = context;
        }

        // GET: api/Barberos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Barbero>>> GetBarberos()
        {
            return await _context.Barberos.ToListAsync();
        }

        //// GET: api/Barberos/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Barbero>> GetBarbero(int id)
        //{
        //    var barbero = await _context.Barberos.FindAsync(id);

        //    if (barbero == null)
        //    {
        //        return NotFound();
        //    }

        //    return barbero;
        //}

        //// PUT: api/Barberos/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBarbero(int id, Barbero barbero)
        //{
        //    if (id != barbero.BarberoId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(barbero).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BarberoExists(id))
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

        //// POST: api/Barberos
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Barbero>> PostBarbero(Barbero barbero)
        //{
        //    _context.Barberos.Add(barbero);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetBarbero", new { id = barbero.BarberoId }, barbero);
        //}

        //// DELETE: api/Barberos/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBarbero(int id)
        //{
        //    var barbero = await _context.Barberos.FindAsync(id);
        //    if (barbero == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Barberos.Remove(barbero);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool BarberoExists(int id)
        //{
        //    return _context.Barberos.Any(e => e.BarberoId == id);
        //}
    }
}
