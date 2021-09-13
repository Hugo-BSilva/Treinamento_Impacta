using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01
{
    class Arquivo
    {
        private string CaminhoPadrao = @"C:\teste\";
        private string Nome { get; set; }
        private string CaminhoCompleto;


        public Arquivo(string nome)
        {
            Nome = nome;
            CaminhoCompleto = CaminhoPadrao + Nome;
        }
        public void CriarArquivo()
        {
            if (!File.Exists(CaminhoCompleto))
            {
                //File.Delete(CaminhoCompleto);
                EfetuarCapturaLinhasParaArquivo(null);
                Console.WriteLine($"Arquivo {Nome} criado com sucesso");
            }
            else
            {
                Console.WriteLine($"Arquivo {Nome} ja existente !");
            }
        }

        public void AtualizarArquivo()
        {
            if (File.Exists(CaminhoCompleto))
            {
                List<string> jaExistentes = new List<string>();
                using (StreamReader sr = File.OpenText(CaminhoCompleto))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        jaExistentes.Add(linha);
                    }
                    EfetuarCapturaLinhasParaArquivo(jaExistentes);
                    Console.WriteLine($"Arquivo {Nome} Lido e atualizado com sucesso");
                }
            }
            else
            {
                Console.WriteLine($"Arquivo {Nome} nao existe na pasta de gerenciamento");
            }
        }

        public void ArquivoCSV()
        {
            if (File.Exists(CaminhoCompleto))
            {
                if (!Nome.Contains(".csv"))
                {
                    Console.WriteLine("O arquivo selecionado não é do tipo csv, favor tente novamente");
                    return;
                }
                else
                {
                    List<string> jaExistentes = new List<string>();
                    var reader = new StreamReader(File.OpenRead(CaminhoCompleto));

                    using (StreamReader sr = File.OpenText(CaminhoCompleto))
                    {
                        string linha;
                        while ((linha = sr.ReadLine()) != null)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(';');

                            jaExistentes.Add(line);
                            foreach (var item in jaExistentes)
                            {
                                Console.WriteLine($"ARQUIVO: {Nome} \n" + item.Replace(';', ' '));
                            }
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine($"Arquivo {Nome} nao existe na pasta de gerenciamento");
            }
        }

        private void EfetuarCapturaLinhasParaArquivo(List<string> jaExistentes)
        {
            List<string> linhas = new List<string>();

            if (jaExistentes != null && jaExistentes.Count > 0)
            {

            }
            else
            {
                linhas = new List<string>();
            }
            string linha;
            string concluiuProcessamento;
            bool pararProcessamento = false;

            do
            {
                Console.WriteLine("Favor informe a linha a ser incluida no arquivo");
                linha = Console.ReadLine();
                if (!string.IsNullOrEmpty(linha) && !string.IsNullOrWhiteSpace(linha))
                {
                    Console.WriteLine("Concluiu o preenchimento do arquivo? (S - Sim e N - Nao)");
                    concluiuProcessamento = Console.ReadLine();

                    if (concluiuProcessamento.Trim().ToUpper() == "S" || concluiuProcessamento.Trim().ToUpper() == "SIM")
                    {
                        pararProcessamento = true;
                    }
                }
            } while (pararProcessamento == false);

            using (StreamWriter sw = File.CreateText(CaminhoCompleto))
            {
                foreach (var item in linhas)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine($"Arquivo {Nome} criado e preenchido com sucesso");
        }
    }

    
}
