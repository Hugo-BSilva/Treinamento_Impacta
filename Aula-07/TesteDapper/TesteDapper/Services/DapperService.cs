using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDapper.Models;
using TesteDapper.Utils;

namespace TesteDapper.Services
{
    class DapperService
    {
        public static void ConsultarLinhas(string conexao)
        {
            using (var db = new SqlConnection(conexao))
            {
                var alunos = db.Query<Aluno>("Select AlunoID, NOME, DATANASCIMENTO, RG From tblALUNO").ToList();
                //db.Open();
                //var query = "Select ALUNOID, NOME, DATANASCIMENTO, RG From tblAluno";
                //var alunos = db.Query<Aluno>(query);
                //await db.OpenAsync();                
                //var query = @"SELECT ID, NOME, DataNascimento as DataNascimento, RG FROM tblAluno";
                //var alunos = await db.QueryAsync<Aluno>(query);
                //db.Execute(query);

                Console.WriteLine("ID | NOME | DATA DE NASCIMENTO | RG");
                foreach (var aluno in alunos)
                {
                    Console.WriteLine($"{aluno.Id} | {aluno.Nome} |" +
                        $" {aluno.DataNascimento.FormatarDataSistema()} | {aluno.Rg}");
                }
            }
        }

        public static async void ConsultarAluno(string conexao)
        {
            using (var db = new SqlConnection(conexao))
            {
                Console.WriteLine("Digite o ID do aluno: ");
                int consultaAluno = int.Parse(Console.ReadLine());

                var alunos = db.Query<Aluno>("Select AlunoID, NOME, DATANASCIMENTO, RG From tblALUNO WHERE AlunoID = " + consultaAluno).ToList();

                Console.WriteLine("ID | NOME | DATA DE NASCIMENTO | RG");
                foreach (var aluno in alunos)
                {
                    Console.WriteLine($"{aluno.Id} | {aluno.Nome} |" +
                        $" {aluno.DataNascimento.FormatarDataSistema()} | {aluno.Rg}");
                }
            }
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
            Console.WriteLine("Aluno Criado!");
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
            Console.WriteLine("Aluno Atualizado !");
        }
        public static void DeletarAluno(string conexao)
        {
            int id = CapturarInformacoesInt("Id", null, null);
            if (id == 0) { return; }

            using (var db = new SqlConnection(conexao))
            {
                var query = @"DELETE FROM tblAluno WHERE ID=" + id;
                db.Execute(query);

                Console.WriteLine("Aluno Removido!");
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
