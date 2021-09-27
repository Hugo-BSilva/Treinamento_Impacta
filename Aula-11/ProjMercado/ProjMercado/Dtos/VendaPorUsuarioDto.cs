using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjMercado.Models;

namespace ProjMercado.Dtos
{
    class VendaPorUsuarioDto
    {
        public string Nome { get; set; }
        public int QtdDeVendas { get; set; }
        public decimal ValorTotalVendas { get; set; }
        public ICollection<Venda> Vendas { get; set; }
    }
}
