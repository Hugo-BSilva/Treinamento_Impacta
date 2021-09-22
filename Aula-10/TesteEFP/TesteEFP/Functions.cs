using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEFP.Models;
using TesteEFP.Repositores;

namespace TesteEFP
{
    class Functions
    {
        private static UsuarioRepository _usuarioRepository;
        private static ProdutoRepository _produtoRepository;
        private static VendaRepository _vendaRepository;
        private static VendaItemRepository _vendaItemRepository;

        // EXIBE A LISTA DE PRODUTOS
        public void ExibirProdutos(List<Produto> produtos)
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
        public void SolicitarProdutosEUsuario()
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
        public static int CapturarInformacoesInt(string tipoDeInfo, int? valorMinimo, int? valorMaximo)
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

        public void ObterVendasPorUsuario()
        {
            var resultado = _vendaRepository.ObterVendaPorUsuarioDTO();
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
        }
    }
}
