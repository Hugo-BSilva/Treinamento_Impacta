using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDapper.Models;

namespace TesteDapper.Services
{
    class DapperService
    {
        public static void ConsultarLinhas(string conexao)
        {
            //using (var db = new SqlConnection(conexao))
            //{
            //    var query = @"SELECT * FROM tblAluno";
            //    db.Execute(query);
            //}
        }
        public static void CriarAluno(string conexao)
        {
            var aluno = ObterDadosAluno();
            if (aluno == null)
            {
                return;
            }
            using (var db = new SqlConnection(conexao))
            {
                var query = @"INSERT INTO tblAluno (Nome, DataNascimento, RG)
                               VALUES (@Nome, @DataNascimento, @RG)";
                db.Execute(query, aluno);
            }
        }
        public static void AtualizarAluno(string conexao)
        {
            var aluno = ObterDadosAluno();
            if (aluno == null)
            {
                return;
            }
            using (var db = new SqlConnection(conexao))
            {
                var query = @"Update tblAluno Set Nome=@Nome, DataNascimento=@DataNascimento, RG=@RG
                            Where AlunoId=@Id";
            }
        }        

        private static Aluno ObterDadosAluno()
        {
            Console.WriteLine("Informe qual o nome do aluno atualizado:");
            var nome = Console.ReadLine();

            if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome do Aluno e obrigatorio");
                return null;
            }

            var diaNascimento = CapturarInformacoesInt("dia de nascimento", 1, 31);
            if (diaNascimento == 0) { return null; }
            var mesNascimento = CapturarInformacoesInt("mes de nascimento", 1, 12);
            if (mesNascimento == 0) { return null; }
            var anoNascimento = CapturarInformacoesInt("ano de nascimento", 1901, 2100);
            if (anoNascimento == 0) { return null; }

            Console.WriteLine("Informe qual o rg do aluno a ser atualizado:");
            var rg = Console.ReadLine();

            var aluno = new Aluno()
            {
                Nome = nome,
                Rg = rg,
                DataNascimento = new DateTime(anoNascimento, mesNascimento, diaNascimento)
            };

            return aluno;
        }

        private static int CapturarInformacoesInt(string tipoDeInfo, int? valorMinimo, int? valorMaximo)
        {
            var mensagem = $"Informe qual o {tipoDeInfo} do usuario";
            if (valorMinimo != null || valorMaximo != null)
            {
                mensagem += $" ({valorMinimo} a {valorMaximo}):";
            }
            else
            {
                mensagem += ":";
            }

            Console.WriteLine(mensagem);
            var infoStr = Console.ReadLine();
            if (string.IsNullOrEmpty(infoStr) || string.IsNullOrWhiteSpace(infoStr))
            {
                Console.WriteLine($"{tipoDeInfo} do Aluno e obrigatorio");
                return 0;
            }

            int info;
            try
            {
                info = int.Parse(infoStr);

                if ((valorMinimo != null && info < valorMinimo) ||
                    (valorMaximo != null && info > valorMaximo))
                {
                    throw new Exception();
                }

                return info;
            }
            catch (Exception)
            {
                Console.WriteLine($"{tipoDeInfo} do Aluno nao e valido");
                return 0;
            }
        }
    }
}
