using System;
using System.Collections.Generic;
using System.Text;

namespace EntendendoPOO
{
    class Produto
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public DateTime Validade { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }

        public Produto()
        {

        }
        public Produto(int id, string tipo, string nome, DateTime validade, decimal valor, string descricao)
        {
            Id = id;
            Tipo = tipo;
            Nome = nome;
            Validade = validade;
            Valor = valor;
            Descricao = descricao;
        }

        public bool IsProdutoValido()
        {
            return Validade > DateTime.Now;
        }

        public void AtualizarDataValidade(DateTime novaData)
        {
            Validade = novaData;
        }
    }
}
