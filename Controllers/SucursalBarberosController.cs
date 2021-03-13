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
    }
}
