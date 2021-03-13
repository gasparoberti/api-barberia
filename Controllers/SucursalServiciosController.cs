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
        
        // GET: api/SucursalServicios/1
        [HttpGet]
        [Route("{sucursal_id:int}")]
        public async Task<ActionResult<IEnumerable<SucursalServicio>>> GetSucursalServicios(int sucursal_id)
        {
            return await _context.SucursalServicios.Where(s => s.SucursalId == sucursal_id).AsNoTracking().ToListAsync();
        }
    }
}
