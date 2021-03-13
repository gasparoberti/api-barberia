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

        // GET: api/Turnos/2021-03-13
        [HttpGet]
        [Route("{fecha:datetime}")]
        public async Task<ActionResult<IEnumerable<Turno>>> GetTurnoPorFecha(DateTime fecha)
        {
            return await _context.Turnos.Where(t => t.Fecha.Date == fecha.Date).AsNoTracking().ToListAsync();
        }
    }
}
