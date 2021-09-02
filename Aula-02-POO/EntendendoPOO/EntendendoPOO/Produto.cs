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
