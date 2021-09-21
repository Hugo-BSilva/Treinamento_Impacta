using System;
using TesteEFP.Repositores;

namespace TesteEFP
{
    class Program
    {
        private static UsuarioRepository _usuarioRepository;
        private static ProdutoRepository _produtoRepository;
        private static VendaRepository _vendaRepository;
        private static VendaItemRepository _vendaItemRepository;

        static void Main(string[] args)
        {
            try
            {
                // MENU PARA FAZER OPERAÇÃO NO BANCO
                Console.Write("Escolha uma das opções que deseja realizar no banco: " +
                    "\n 1- LISTAR PRODUTOS" +
                    "\n 2- CRIAR UMA VENDA" +
                    "\n 3- OBTER VENDAS POR USUARIO" +
                    "\n 4- TOTAL DE ITENS VENDIDOS DO PRODUTO \n Resposta: ");
                var opSTR = Console.ReadLine();
                var opcao = int.Parse(opSTR);

                // VARIÁVEL VAI INSTANCIAR A CLASSE DBContext QUE POSSUI ACESSO DIRETO AO BANCO DE DADOS
                using (var context = new TesteEFPDBContext())
                {
                    var funcoes = new Functions();
                    // PASSA A VARIÁVEL COMO PARÂMETRO PARA QUE A Impl TENHA ACESSO DIRETO A TABELA DO BD
                    _produtoRepository = new ProdutoRepositoryImpl(context);
                    _usuarioRepository = new UsuarioRepositoryImpl(context);
                    _vendaRepository = new VendaRepositoryImpl(context);
                    _vendaItemRepository = new VendaItemRepositoryImpl(context);

                    switch (opcao)
                    {
                        case 1:
                            var produtos = _produtoRepository.ObterProdutos();
                            funcoes.ExibirProdutos(produtos);
                            break;
                        case 2:
                            SolicitarProdutosEUsuario();
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
            catch (ArgumentException e)
            {
                // QUANDO O USUÁRIO DIGITA UM NUMERO INVÁLIDO DAS OPÇÕES
                Console.WriteLine("OOPS... Voce informou um numero invalido, favor tentar novamente!");
            }
            catch (FormatException e)
            {
                Console.WriteLine("OOPS... O formato do numero e invalido, favor tentar novamente!");
            }
            catch(Exception e)
            {
                Console.WriteLine("OOPS... Ocorreu um erro ao processar dados via EF: " + e.Message);
            }
        }
    }
}
