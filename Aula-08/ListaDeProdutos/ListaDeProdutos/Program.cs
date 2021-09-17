using Dapper;
using ListaDeProdutos.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace ListaDeProdutos
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();
            var conexao = configuration["ConnectionStrings:DefaultConnection"];

            using (var db = new SqlConnection(conexao))
            {
                var produtos = db.Query<Produto>("SELECT IDProduto, NOME, DATA_VALIDADE as DATAVALIDADE, VALOR FROM TB_PRODUTO").ToList();

                foreach (var produto in produtos)
                {
                    Console.WriteLine($"ID: {produto.Id} | NOME: {produto.Nome} | VALIDADE: {produto.DATAVALIDADE} | VALOR: {produto.VALOR}");
                }
            }
        }
    }
}
