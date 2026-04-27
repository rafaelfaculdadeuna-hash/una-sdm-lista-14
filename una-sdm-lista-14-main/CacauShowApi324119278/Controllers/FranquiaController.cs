using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CacauShowApi324119278.Data;
using CacauShowApi324119278.Models;
using Microsoft.AspNetCore.Mvc;

namespace CacauShowApi324119278.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FranquiaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FranquiaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Franquias.ToList());
        }

        [HttpPost]
        public IActionResult Post(Franquia franquia)
        {
            _context.Franquias.Add(franquia);
            _context.SaveChangesAsync();
            return Ok(franquia);
        }
    }
}