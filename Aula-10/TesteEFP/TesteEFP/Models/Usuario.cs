using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEFP.Models
{
    [Table("TB_USUARIO")]
    class Usuario
    {
        [Key]
        [Column("ID_USUARIO")]
        public int Id { get; set; }

        [Column("DSC_USUARIO", TypeName = "VARCHAR(100)")]
        public string Nome_Usuario { get; set; }

        [Column("DATA_NASCIMENTO")]
        public string Data_Nascimento { get; set; }

        //Uma venda tem um usuário, um usuário tem uma lista de vendas
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
