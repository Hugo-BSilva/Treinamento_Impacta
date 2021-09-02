using System;
using System.Collections.Generic;

namespace EntendendoPOO
{
    class Program
    {
        static void Main(string[] args)
        {
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
