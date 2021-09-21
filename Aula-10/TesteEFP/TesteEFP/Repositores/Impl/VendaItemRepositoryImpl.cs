using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEFP.Models;

namespace TesteEFP.Repositores
{
    class VendaItemRepositoryImpl : VendaItemRepository
    {
        private TesteEFPDBContext _context;

        public VendaItemRepositoryImpl(TesteEFPDBContext context)
        {
            _context = context;
        }
        public void Salvar(VendaItem item)
        {
            _context.VendaItem.Add(item);
            _context.SaveChanges();
        }
    }
}
