using MaosAObra02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEF.Repositores
{
    interface ProdutoRepository
    {
        List<Produto> ObterProdutos();
    }
}
