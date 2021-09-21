using System;
using TesteEF.Repositores;
using TesteEF.Repositores.Impl;

namespace TesteEF
{
    class Program
    {
        private static ProdutoRepository _produtoRespository;
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Informe a operação que deseja fazer no banco: \n 1-Listar Produtos \n 2-Criar venda" +
                    "\n 3-Obter venda por usuário \n 4-Total de itens vendidos do produto");
                var opcaoStr = Console.ReadLine();
                var opcao = int.Parse(opcaoStr);

                using (var context = new TesteEFDBContext())
                {
                    switch (opcao)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        default:
                            break;
                    }
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
