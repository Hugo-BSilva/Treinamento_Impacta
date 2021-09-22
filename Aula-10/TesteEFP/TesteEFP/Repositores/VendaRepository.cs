using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEFP.Dtos;
using TesteEFP.Models;

namespace TesteEFP.Repositores
{
    interface VendaRepository
    {
        void Salvar(Venda venda);
        void Atualizar(Venda venda);
        List<VendaPorUsuarioDto> ObterVendaPorUsuarioDTO();
    }
}
