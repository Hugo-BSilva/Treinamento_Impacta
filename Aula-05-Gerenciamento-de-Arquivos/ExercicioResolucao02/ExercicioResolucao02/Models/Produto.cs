using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioResolucao02
{
    public class Produto
    {
        public string Nome { get; set; }
        public DateTime DataDeValidade { get; set; }
        public double Preço { get; set; }
        public string Marca { get; set; }
        public Produto(string nome, DateTime dataDeValidade, double preço, string marca)
        {
            Nome = nome;
            DataDeValidade = dataDeValidade;
            Preço = preço;
            Marca = marca;
        }
    }
}
