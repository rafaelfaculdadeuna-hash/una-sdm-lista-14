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
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Produtos.ToList());
        }

        [HttpPost]
        public IActionResult Post(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChangesAsync();
            return Ok(produto);
        }
    }
}