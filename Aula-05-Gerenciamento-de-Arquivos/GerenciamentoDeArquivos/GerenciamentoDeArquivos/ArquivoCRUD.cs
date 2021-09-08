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
        }

        public void DeletarArqquivo()
        {
            //var caminhoDoArquivo = @"C:\teste\teste.txt";
            if (!File.Exists(CaminhoCompleto))
            {
                File.Delete(CaminhoCompleto);
                if (!File.Exists(CaminhoCompleto))
                {
                    Console.WriteLine("");
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
                if (!File.Exists(CaminhoCompleto))
                {
                    EfetuarCapturaLinhasParaArquivo(null);
                    Console.WriteLine($"Arquivo {Nome} criado com sucesso");
                }
                else
                {
                    Console.WriteLine($"Arquivo {Nome} não foi criado");
                }
            }
            else
            {
                Console.WriteLine($"Arquivo {Nome} nao existe na pasta de gerenciamento");
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

        public void ListarArquivos()
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

