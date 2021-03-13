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
    }
}
