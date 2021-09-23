using System;
using System.Collections.Generic;
using System.Linq;
using TesteEFP.Models;
using TesteEFP.Repositores;

namespace TesteEFP
{
    class Program
    {
        private static ProdutoRepository _produtoRepository;
        private static VendaItemRepository _vendaItemRepository;
        private static VendaRepository _vendaRepository;
        private static UsuarioRepository _usuarioRepository;

        static void Main(string[] args)
        {
            try
            {
                bool looping = false;
                string verificarCondicao;
                do
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
                        // PASSA A VARIÁVEL COMO PARÂMETRO PARA QUE A Impl TENHA ACESSO DIRETO A TABELA DO BD
                        _produtoRepository = new ProdutoRepositoryImpl(context);
                        _vendaItemRepository = new VendaItemRepositoryImpl(context);
                        _vendaRepository = new VendaRepositoryImpl(context);
                        _usuarioRepository = new UsuarioRepositoryImpl(context);

                        switch (opcao)
                        {
                            case 1:
                                var produtos = _produtoRepository.ObterProdutos();
                                ExibirProdutos(produtos);
                                break;
                            case 2:
                                SolicitarProdutosEUsuario();
                                break;
                            case 3:
                                ObterVendasPorUsuario();
                                break;
                            case 4:
                                ObterItensPorProduto();
                                break;
                            default:
                                break;
                        }
                    }
                    
                    Console.WriteLine("DESEJA FAZER UMA NOVA OPERAÇÃO? (SIM-S / NAO-N)");
                    verificarCondicao = Console.ReadLine();

                    if ((string.IsNullOrEmpty(verificarCondicao) == null || string.IsNullOrWhiteSpace(verificarCondicao)) &&
                        verificarCondicao.Trim().ToUpper() == "SIM" && verificarCondicao.Trim().ToUpper() == "S")
                    {
                        looping = true;
                        Console.Clear();
                    }
                    else
                    {
                        looping = false;
                        Console.Clear();
                    }
                } while (looping == false);
                Console.WriteLine("------------- FLUXO FINALIZADO, VOLTE SEMPRE -------------");
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

        private static void ObterVendasPorUsuario()
        {
            var resultado = _vendaRepository.ObterVendasPorUsuario();
            foreach (var dto in resultado)
            {
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine($"Usuario: {dto.Nome} vendeu {dto.QtdDeVendas} vendas no valor total de R$" +
                    $" {dto.ValorTotalVendas}");
                foreach (var venda in dto.Vendas)
                {
                    Console.WriteLine($"Venda: {venda.Id} valor R$ {venda.Valor_Total}");
                }
            }
            Console.WriteLine("----------------------------------------------------------------------------------");
        }

        // EXIBE A LISTA DE PRODUTOS
        private static void ExibirProdutos(List<Produto> produtos)
        {
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("ID_PRODUTO | NOME_PRODUTO | PRECO_PRODUTO | DATA_VALIDADE | TIPO_PRODUTO");
            foreach (var prod in produtos)
            {
                Console.WriteLine($"{prod.Id_Produto} | {prod.Nome_Produto} | {prod.Preco_Produto} | " +
                    $"{prod.Data_Validade} | {prod.Tipo_Produto}");
            }
            Console.WriteLine("----------------------------------------------------------------------------------");
        }

        //SOLICITA OS PRODUTOS COM O USUÁRIO
        private static void SolicitarProdutosEUsuario()
        {
            // INICIA A FUNÇÃO
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("> COMPRA INICIADA <");

            var idUsuario = CapturarInformacoesInt("Id do Usuario", null, null);
            var usuario = _usuarioRepository.SelecionarUsuarioID(idUsuario);

            // VERIFICA SE O USUÁRIO PASSADO EXISTE NA TABELA
            if (usuario == null)
            {
                Console.WriteLine("Usuario nao encontrado !");
                return;
            }

            bool looping = true;
            int idProduto;
            int qtdItem;
            Produto produto;
            Venda venda = null;
            VendaItem vendaItem;
            do
            {
                idProduto = CapturarInformacoesInt("Id do produto", null, null);
                produto = _produtoRepository.SelecionarProdutoPorID(idProduto);

                // VERIFICA SE O PRODUTO EXISTE NA TABELA
                if (produto == null)
                {
                    Console.WriteLine("Produto não encontrado !");
                    return;
                }

                // VERIFICA SE A QUANTIDADE DE PRODUTOS PASSADA É VÁLIDA, VALOR MINIMO É 1 E MAXIMO 100
                qtdItem = CapturarInformacoesInt("Quantidade de itens vendidos", 1, 100);
                if (qtdItem == null)
                {
                    Console.WriteLine("Quantidade invalida!");
                    return;
                }

                // VERIFICA SE A VENDA EXISTE, CASO NÃO, ELA SERÁ CRIADA
                if (venda == null)
                {
                    venda = new Venda();
                    venda.Id_Usuario = idUsuario;
                    _vendaRepository.Salvar(venda);
                }

                // POPULA A CLASSE VENDA ITEM COM AS INFORMAÇÕES PASSADAS
                vendaItem = new VendaItem()
                {
                    Id_Produto = idProduto,
                    Quantidade = qtdItem,
                    Id_Venda = venda.Id
                };

                _vendaItemRepository.Salvar(vendaItem);
                venda.Valor_Total += produto.Preco_Produto * qtdItem;

                // VERIFICA COM O USUARIO SE A COMPRA FOI CONCLUIDA, CASO NÃO O LOOPING SERÁ ENCERRADO
                Console.WriteLine("Compra concluida? (S - Sim / N - Nao)");
                var vendaConcluida = Console.ReadLine();
                if (vendaConcluida.Trim().ToUpper() == "S" || vendaConcluida.Trim().ToUpper() == "SIM")
                {
                    looping = false;
                }
                else
                {
                    looping = true;
                }

                _vendaRepository.Atualizar(venda);

                Console.WriteLine("COMPRA CONCLUÍDA !!");
                Console.WriteLine("----------------------------------------------------------------------------------");
            } while (looping == false);
        }


        // MÉTODO PERSONALIZADO PARA CAPTURAR QUALQUER TIPO DE INFORMAÇÃO E REALIZAR UMA TRATATIVA
        private static int CapturarInformacoesInt(string tipoDeInfo, int? valorMinimo, int? valorMaximo)
        {
            var mensagem = $"Informe qual o {tipoDeInfo}";

            if (valorMinimo != null || valorMaximo != null)
            {
                mensagem += $"({valorMinimo} a {valorMaximo})";
            }
            else
            {
                mensagem += ":";
            }

            // MOSTRA A MENSAGEM NA TELA, PEDINDO PARA O USUARIO INSERIR UMA INFORMAÇÃO
            Console.WriteLine(mensagem);
            var infoSTR = Console.ReadLine();

            // FAZ UMA TRATATIVA CASO O USUÁRIO ESQUEÇA DE PREENCHER
            if (string.IsNullOrEmpty(infoSTR) || string.IsNullOrWhiteSpace(infoSTR))
            {
                Console.WriteLine($"{tipoDeInfo} e obrigatorio");
                return 0;
            }

            int info;
            try
            {
                // VERIFICA SE O VALOR INFORMADO É MENOR QUE O VALOR MINIMO PASSADO POR PARÂMETRO
                // OU MAIOR QUE O VALOR MÁXIMO PASSADO POR PARÂMETRO
                info = int.Parse(infoSTR);
                if ((valorMinimo != null && info < valorMinimo) ||
                    (valorMaximo != null && info > valorMaximo))
                {
                    throw new Exception();
                }
                return info;
            }
            catch (Exception)
            {
                Console.WriteLine($"{tipoDeInfo} nao e valido");
                return 0;
            }
        }        

        private static void ObterItensPorProduto()
        {
            var resultado = _produtoRepository.ObterItensPorProduto();
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("ID_PRODUTO | NOME_PRODUTO | PRECO_PRODUTO | DATA_VALIDADE | TIPO_PRODUTO | " +
                "ITENS_VENDIDOS_POR_PRODUTO");
            foreach (var item in resultado)
            {
                Console.WriteLine($"{item.Id_Produto} | {item.Nome_Produto} | {item.Preco_Produto} " +
                    $"| {item.Data_Validade} | {item.Tipo_Produto} | " +
                    $"{item.ItensDoProdutoVendido.Sum(e => e.Quantidade)}");
                foreach (var dto in item.ItensDoProdutoVendido)
                {
                    Console.WriteLine($"Item: {dto.Id} quantidade: {dto.Quantidade}");
                }
            }
        }
    }
}
