using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEFP.Models;

namespace TesteEFP.Repositores
{
    class ProdutoRepositoryImpl : ProdutoRepository
    {
        private TesteEFPDBContext _context;

        public ProdutoRepositoryImpl(TesteEFPDBContext context)
        {
            _context = context;
        }
        public List<Produto> ObterProdutos()
        {
            // Retorna apenas os produtos que não estão vencidos(vencimento antes da data atual(de hoje))
            return _context.Produto.Where(produto => produto.Data_Validade > DateTime.Now).ToList();
        }

        public Produto SelecionarProdutoPorID(int idProduto)
        {
            // Trás o primeiro produto que encontrar o id passado
            return _context.Produto.FirstOrDefault(produto => produto.Id_Produto == idProduto);
        }
    }
}
