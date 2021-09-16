using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;
using TesteDapper.Services;
using TesteDapper.Models;
using TesteDapper.Utils;

namespace TesteDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string loop;
                bool op;
                do
                {
                    var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
                    var configuration = builder.Build();
                    var conexao = configuration["ConnectionStrings:DefaultConnection"];

                    if (string.IsNullOrEmpty(conexao) || string.IsNullOrWhiteSpace(conexao))
                    {
                        Console.WriteLine("Arquivo de configuracao (appSettings) nao foi encontrado na pasta de binario");
                        return;
                    }

                    Console.WriteLine("Informe qual operacao voce quer realizar no banco: (1 - select, 2 - create, 3 - update e 4 - delete, 5 - select id)");
                    var opcaoStr = Console.ReadLine();
                    var opcao = int.Parse(opcaoStr);

                    switch (opcao)
                    {
                        case 1:
                            DapperService.ConsultarLinhas(conexao);
                            break;
                        case 2:
                            DapperService.CriarAluno(conexao);
                            break;
                        case 3:
                            DapperService.AtualizarAluno(conexao);
                            break;
                        case 4:
                            DapperService.DeletarAluno(conexao);
                            break;
                        case 5:
                            DapperService.ConsultarAluno(conexao);
                            break;
                        default:
                            Console.WriteLine("Opcao informada nao e valida, tente novamente!");
                            break;
                    }

                    Console.WriteLine("Deseja Realizar outra operação ? (SIM / S) ou (NAO / N)");
                    loop = Console.ReadLine();
                    op = false;

                    if (!string.IsNullOrWhiteSpace(loop) || !string.IsNullOrEmpty(loop) && 
                        (loop.ToUpper() == "SIM" || loop.ToUpper() == "S"))
                    {
                        op = true;
                    }
                    Console.Clear();
                } while (op == true && (loop.ToUpper() == "SIM" || loop.ToUpper() == "S"));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Voce informou um numero invalido, tente novamente!");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Voce informou um numero invalido, tente novamente!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu erro ao processar dados via Dapper: " + e.Message);
            }
        }
    }
}
