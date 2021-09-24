using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjMercado.Models
{
    [Table("TB_USUARIO")]
    public class Usuario
    {
        [Key]
        [Column("ID_USUARIO")]
        public int Id { get; set; }

        [Column("NOME_USUARIO")]
        public string Nome_Usuario { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data_Nascimento { get; set; }

        [Column("SENHA")]
        public string Senha { get; set; }

        //Uma venda tem um usuário, um usuário tem uma lista de vendas
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
