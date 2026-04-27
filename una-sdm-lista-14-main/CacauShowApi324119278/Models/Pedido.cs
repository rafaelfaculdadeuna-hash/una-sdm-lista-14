using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacauShowApi324119278.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int UnidadeId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal  { get; set; }
    }
}