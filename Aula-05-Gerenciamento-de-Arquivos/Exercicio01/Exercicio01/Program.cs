using System;
using System.Collections.Generic;
using System.IO;

namespace Exercicio01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Favor informe o nome do arquivo a ser gerenciado(ex. nome.txt/teste.csv)");
                var nome = Console.ReadLine();

                if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome) ||
                    nome.Length < 5 || (!nome.Contains(".txt") && !nome.Contains(".csv")))
                {
                    Console.WriteLine("Nome inválido, favor refazer a operação.");
                    return;
                }

                Console.WriteLine("Favor informe a operação a realizar: (1- Criar  2- Atualizar) ");
                var operacaoTxt = Console.ReadLine();
                int operacao = int.Parse(operacaoTxt);

                var arquivo = new Arquivo(nome);
                switch (operacao)
                {
                    case 1:
                        arquivo.CriarArquivo();
                        break;
                    case 2:
                        arquivo.AtualizarArquivo();
                        break;
                    case 3:
                        arquivo.ArquivoCSV();
                        break;
                    default:
                        throw new ArgumentException("Valor informado nao e um dos numeros disponiveis, favor refaca a operacao");
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Numero informado nulo, favor refaca a operacao");
            }
            catch (FormatException)
            {
                Console.WriteLine("Numero informado nao e um inteiro, favor refaca a operacao");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Numero informado maior que um inteiro, favor refaca a operacao");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        
    }
}
