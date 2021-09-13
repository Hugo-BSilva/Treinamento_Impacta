using System;
using System.Collections.Generic;
using System.IO;

namespace ExercicioRESOLUCAO
{
    
    class Program
    {
        static string Binding = "{{NOME_DO_ARQUIVO}}";
        static string CaminhoFinal = @"C:\teste\"+Binding+".txt";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Informe o nome do arquivo que vai ser criado(teste, arquivo01...): ");
                var nomeArquivo = Console.ReadLine();

                if (string.IsNullOrEmpty(nomeArquivo) || string.IsNullOrWhiteSpace(nomeArquivo))
                {
                    Console.WriteLine("Nome do arquivo invalido, tente novamente");
                }

                string linha;
                string conclusaoStr;
                bool conclusao = false;
                List<string> linhas = new List<string>();

                do
                {
                    Console.WriteLine("Informe o texto a ser inserido no arquivo: ");
                    linha = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(linha) || string.IsNullOrEmpty(linha))
                    {
                        Console.WriteLine("Concluiu a digitacao do arquivo? (S - SIM / N - NAO)");
                        conclusaoStr = Console.ReadLine();

                        if (conclusaoStr.Trim().ToUpper() == "S" || conclusaoStr.Trim().ToUpper() == "SIM")
                        {
                            conclusao = true;
                        }
                    }
                    
                } while (conclusao == false);

                if(linhas.Count > 0)
                {
                    var arquivoFinal = CaminhoFinal.Replace(Binding, nomeArquivo);

                    if (!File.Exists(arquivoFinal))
                    {
                        using (StreamWriter sw = File.CreateText(CaminhoFinal.Replace(Binding, nomeArquivo)))
                        {
                            foreach (var item in linhas)
                            {
                                sw.WriteLine(item);
                            }
                        }
                        Console.WriteLine($"Arquivo {nomeArquivo} criado com sucesso");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ops... Ocorreu um erro: " + e.Message);               
            }
        }
    }
}
