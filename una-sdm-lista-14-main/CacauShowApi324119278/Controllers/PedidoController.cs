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
    public class PedidoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PedidoController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Pedidos.ToList());
        }
        [HttpPost]
        public IActionResult Post(Pedido pedido)
        {
            var uni = _context.Franquias
            .FirstOrDefault(f => f.Id == pedido.UnidadeId);
            if (uni == null)
            {
                return NotFound("Unidade não encontrada.");
            }
            var total = _context.Pedidos
            .Where(p => p.UnidadeId == pedido.UnidadeId)
            .Sum(p => p.Quantidade);

            if (total + pedido.Quantidade > uni.CapacidadeEstoque)
            {
                return BadRequest("Capacidade logística da loja excedida. Não é possível receber mais produtos.");
            }
            var prod = _context.Produtos
            .FirstOrDefault(p => p.Id == pedido.ProdutoId);
            if (prod == null)
            {
                return NotFound("Produto não encontrado.");
            }
            if (prod.Tipo == "Sazonal")
            {
                pedido.ValorTotal += 15;
                Console.WriteLine(" Produto sazonal detectado: Adicionando embalagem de presente premium!");
            }

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = pedido.Id }, pedido);
        }

    }
}