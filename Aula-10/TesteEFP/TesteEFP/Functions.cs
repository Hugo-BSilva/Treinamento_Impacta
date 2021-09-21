using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEFP.Models;

namespace TesteEFP
{
    class Functions
    {
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

        public void SolicitarProdutosEUsuario()
        {
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("> COMPRA INICIADA <");
            var idUsuario = CapturarInformacoesInt("Id do Usuario", null, null);
        }


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

    }
}
