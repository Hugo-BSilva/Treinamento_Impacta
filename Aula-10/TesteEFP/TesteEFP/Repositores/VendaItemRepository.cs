using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEFP.Models;

namespace TesteEFP.Repositores
{
    interface VendaItemRepository
    {
        void Salvar(VendaItem item);
    }
}
