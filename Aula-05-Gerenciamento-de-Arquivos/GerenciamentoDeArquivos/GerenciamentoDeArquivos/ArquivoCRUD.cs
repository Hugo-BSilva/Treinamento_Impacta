using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GerenciamentoDeArquivos
{
    class ArquivoCRUD
    {
        private string CaminhoPadrao = @"C:\teste\";
        private string Nome { get; set; }
        private string CaminhoCompleto;

        
        public ArquivoCRUD(string nome)
        {
            Nome = nome;
            CaminhoCompleto = CaminhoPadrao + Nome;
        }
        
        public void DeletarArquivo()
        {
            
            //var caminhoDoArquivo = @"C:\teste\teste.txt";
            if (File.Exists(CaminhoCompleto))
            {
                File.Delete(CaminhoCompleto);
                if (!File.Exists(CaminhoCompleto))
                {
                    Console.WriteLine($"Arquivo {Nome} deletado com sucesso!");
                }
                else
                {
                    Console.WriteLine($"Arquivo {Nome} não pode ser deletado !");
                }
            }
            else
            {
                Console.WriteLine($"Arquivo {Nome} nao existe na pasta de gerenciamento");
            }
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

        public void ListarArquivo()
        {
            if (File.Exists(CaminhoCompleto))
            {
                using (StreamReader sr = File.OpenText(CaminhoCompleto))
                {
                    string linha;
                    int index = 1;

                    while ((linha = sr.ReadLine()) != null)
                    {
                        Console.WriteLine($"Linha: {index++} - conteudo: {linha}");
                    }

                    Console.WriteLine($"Arquivo {Nome} Lido com sucesso");
                }
            }
            else
            {
                Console.WriteLine($"Arquivo {Nome} nao existe na pasta de gerenciamento");
            }
        }


        private void EfetuarCapturaLinhasParaArquivo(List<string> jaExistente)
        {
            string linha;
            string concluiuProcesamento;
            bool pararProcessamento = false;
            List<string> linhas;

            if (jaExistente != null && jaExistente.Count > 0)
            {
                linhas = jaExistente;
            }
            else
            {
                linhas = new List<string>();
            }

            do
            {
                Console.WriteLine("Favor informe a linha a ser incluida no arquivo (termine a digitação com enter para a proxima instrução)!");
                linha = Console.ReadLine();

                if (!string.IsNullOrEmpty(linha) || !string.IsNullOrWhiteSpace(linha))
                {
                    Console.WriteLine("Concluiu o preenchimento do arquivo? (S/N)");
                    concluiuProcesamento = Console.ReadLine();
                    if (concluiuProcesamento.Trim().ToUpper() == "S" || concluiuProcesamento.Trim().ToUpper() == "Sim")
                    {
                        pararProcessamento = true;
                    }

                    linhas.Add(linha);
                }
                using (StreamWriter sw = File.CreateText(CaminhoCompleto))
                {
                    foreach (var l in linhas)
                    {
                        sw.WriteLine(l);
                    }
                }
            } while (pararProcessamento == false);
        }
    }
}
// Criar e preencher um arquivo caso o arquivo teste.txt não exista
//Abre uma conexão com o arquivo
//                using (StreamWriter sw = File.CreateText(caminhoDoArquivo))
//                {
//                    sw.WriteLine("Meu primeiro txt em C#");
//                    sw.WriteLine("Primeira linha");
//                    sw.WriteLine("última linha");
//                }
//// Ler o arquivo gerado e imprimir no console
//using (StreamReader sr = File.OpenText(caminhoDoArquivo))
//        {
//            string line;
//            while ((line = sr.ReadLine()) != null)
//            {
//                Console.WriteLine(line);

