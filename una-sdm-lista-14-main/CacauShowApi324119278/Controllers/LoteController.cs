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
    public class LoteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoteController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Lotes.ToList());
        }
        [HttpPost]
        public IActionResult Post(LoteProducao lote)
        {
            if (!_context.Produtos.Any(p => p.Id == lote.ProdutoId))
            {
                if (lote.DataFabricacao > DateTime.Now)
                {
                    return Conflict("Lote inválido: Data de fabricação não pode ser maior que a data atual.");
                }
                else
                {
                    _context.Lotes.Add(lote);
                    _context.SaveChanges();
                    return CreatedAtAction(nameof(Get), new { id = lote.Id }, lote);
                }
            }
            else { return BadRequest("O produto não existe"); }
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> Patch(int id, string newStatus)
        {
            var lote = await _context.Lotes.FindAsync(id);
            if (lote == null)
            {
                return NotFound("Lote não encontrado.");
            }
            if (lote.Status == "Descartado" && (newStatus == "Qualidade Aprovada" || newStatus == "Distribuído"))
            {
                {
                    return BadRequest("Um lote descartado não pode ser alterado para Qualidade Aprovada ou Distribuído.");
                }
            }
            lote.Status = newStatus;
            _context.SaveChanges();
            return Ok(lote);
        }
    }
}