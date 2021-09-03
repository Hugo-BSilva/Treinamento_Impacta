using System;
using System.Collections.Generic;

namespace EntendendoPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            var validade = new DateTime(2021, 9, 1);
            Produto cafe = new Produto()
            {
                Id = 1,
                Nome = "Cafe 3 coracoes",
                Descricao = "Cafe premium Torrado embalado a vacuo",
                Tipo = "alimento",
                Valor = 9.78m
            };
            cafe.AtualizarDataValidade(validade);

            Produto bolacha = new Produto(3, 
                "alimento",
                "Bolacha agua e sal",
                validade,
                2.89m, 
                "Bolacha agua e sal");

            Usuario usuario = new Usuario() { Id = 1, Nome = "João", Demissao = null };
            Cliente cliente = new Cliente() { Id = 2, Nome = "Luiz", IsMaiorDeIdade= true};
            Pessoa p = new Pessoa() { Id = 3, Nome = "Cleide" };

            List<Pessoa> pessoas = new List<Pessoa>();
            pessoas.Add(cliente);
            pessoas.Add(usuario);

            foreach (var item in pessoas)
            {
                if (item is Cliente)
                {
                    Console.WriteLine($"Cliente: {item.Nome}, é maior de idade? {((Cliente)item).IsMaiorDeIdade}");
                }
            }
            
        }
    }
}
