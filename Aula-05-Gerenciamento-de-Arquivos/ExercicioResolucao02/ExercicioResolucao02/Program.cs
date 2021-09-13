using System;
using System.IO;
using System.Text;

namespace ExercicioResolucao02
{
    class Program
    {
        static string DiretorioPadrao = @"C:\teste\";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Inicio do Processamento");
                if (Directory.Exists(DiretorioPadrao))
                {
                    var files = Directory.GetFiles(DiretorioPadrao);

                    foreach (var arquivo in files)
                    {
                        if (arquivo.Contains(".csv"))
                        {
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("Iniciando leitura do arquivo: " + arquivo);
                            using (StreamReader sr = new StreamReader(File.OpenRead(arquivo), Encoding.UTF8))
                            {
                                int numlinha = 1;
                                string linha;
                                string[] produtoLinha;
                                Produto produto;

                                string nome;
                                DateTime dataDeValidade;
                                string valorSRT;
                                double valor;
                                string marca;


                                while ((linha = sr.ReadLine()) != null)
                                {
                                    produtoLinha = linha.Split(";");
                                    if (produtoLinha.Length == 4
                                        && !string.IsNullOrEmpty(produtoLinha[1])
                                        && !string.IsNullOrWhiteSpace(produtoLinha[1])
                                        && !string.IsNullOrEmpty(produtoLinha[2])
                                        && !string.IsNullOrWhiteSpace(produtoLinha[2]))
                                    {
                                        nome = produtoLinha[0];
                                        dataDeValidade = DateTime.Parse(produtoLinha[1]);
                                        valorSRT = produtoLinha[2].Replace("R$ ", "");
                                        valor = double.Parse(valorSRT.Trim());
                                        marca = produtoLinha[3];

                                        produto = new Produto(nome, dataDeValidade, valor, marca);

                                        Console.WriteLine("Leitura da linha: " + numlinha + $"- Nome: {produto.Nome}" +
                                            $" - Data de Validade: {produto.DataDeValidade}" +
                                            $"- Marca: {produto.Marca}");
                                    }
                                }
                            }

                            Console.WriteLine("Concluindo leitura do arquivo: " + arquivo);
                            Console.WriteLine("----------------------------------");
                        }
                    }
                    Console.WriteLine("Fim do Processamento");
                }
                Console.WriteLine("Não existem arquivos .csv no diretorio: " + DiretorioPadrao);
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível ler arquivos .csv: " + e.Message);
            }
        }
    }
}
