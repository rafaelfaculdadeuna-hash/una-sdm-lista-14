using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CacauShowApi324119278.Data;
using CacauShowApi324119278.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CacauShowApi324119278.Controllers
{
    [ApiController]
    [Route("api/intelligence/estoque-regional")]
    public class ChocolateIntelligenceController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ChocolateIntelligenceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("estoque-regional")]
        public IActionResult Get()
        {
            Thread.Sleep(2000);
            
            var tdped = _context.Pedidos
            .Join(_context.Franquias,
            pedido => pedido.UnidadeId,
            franquia => franquia.Id,
            (pedido,franquia)=> new
            {
                franquia.Cidade,
                pedido.Quantidade
            })
            .GroupBy(x => x.Cidade)
            .Select(g => new
            {Cidade = g.Key,
            TotalItens = g.Sum(x=> x.Quantidade)
            })
            .ToList();
            return Ok(tdped);
        }
    }
}