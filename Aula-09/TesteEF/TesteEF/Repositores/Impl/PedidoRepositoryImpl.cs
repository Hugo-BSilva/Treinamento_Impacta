using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEF.Repositores.Impl
{
    class PedidoRepositoryImpl
    {
        public void Salvar(Pedido pedido)
        {
            _context.Pedido.Add(pedido);
            _context.Pedido.SaveChanges()
        }
    }
}
