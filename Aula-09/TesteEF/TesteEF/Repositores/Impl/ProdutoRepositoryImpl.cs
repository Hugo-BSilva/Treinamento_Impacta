using MaosAObra02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEF.Repositores.Impl
{
    class ProdutoRepositoryImpl : ProdutoRepository
    {
        private TesteEFDBContext _context;

        public ProdutoRepositoryImpl(TesteEFDBContext context)
        {
            _context = context;
        }

        public List<Produto> ObterProdutos()
        {
            //Acessa database.Nome da tabela. Função que será executada
            //Trás apenas os produtos onde a data de validade é maior que o dia atual
            return _context.Produto.Where(produto => produto.Data_Validade > DateTime.Now).ToList();
        }
    }
}
