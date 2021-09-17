using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeProdutos.Models
{
    class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DATAVALIDADE { get; set; }
        public decimal VALOR { get; set; }
    }
}
