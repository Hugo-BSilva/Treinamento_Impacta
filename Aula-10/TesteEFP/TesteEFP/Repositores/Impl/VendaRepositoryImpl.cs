using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEFP.Models;

namespace TesteEFP.Repositores
{
    class VendaRepositoryImpl : VendaRepository
    {
        private TesteEFPDBContext _context;

        public VendaRepositoryImpl(TesteEFPDBContext context)
        {
            _context = context;
        }

        public void Salvar(Venda venda)
        {
            // Adiciona a venda primeiro e depois salva as alterações no banco
            _context.Venda.Add(venda);
            _context.SaveChanges();
        }
    }
}
