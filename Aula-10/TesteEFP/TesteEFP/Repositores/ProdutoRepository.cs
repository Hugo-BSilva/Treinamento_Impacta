using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEFP.Models;

namespace TesteEFP.Repositores
{
    interface ProdutoRepository
    {
        List<Produto> ObterProdutos();
        Produto SelecionarProdutoPorID(int idProduto);
    }
}
