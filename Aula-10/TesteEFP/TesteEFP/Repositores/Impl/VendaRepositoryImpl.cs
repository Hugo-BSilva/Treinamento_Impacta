using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEFP.Models;
using Microsoft.EntityFrameworkCore;
using TesteEFP.Dtos;

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

        public void Atualizar(Venda venda)
        {
            //_context.Venda.Update(venda);
            // PASSA O STATUS DA VENDA SE ELA FOI MODIFICADA
            _context.Entry(venda).State = EntityState.Modified; // ????
            _context.SaveChanges();
            _context.Entry(venda).State = EntityState.Detached; // ????
        }

        public List<VendaPorUsuarioDto> ObterVendasPorUsuario()
        {
            return _context.Usuario.Include(e => e.Vendas).Select(e => new VendaPorUsuarioDto()
            {
                Nome = e.Nome_Usuario,
                QtdDeVendas = e.Vendas.Count(),
                ValorTotalVendas = e.Vendas.Sum(e => e.Valor_Total),
                Vendas = e.Vendas
            }).ToList();
        }
    }
}
