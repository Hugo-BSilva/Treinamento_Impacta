using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEF.Models
{
    [Table("TB_VENDA")]
    class Venda
    {
        [Key]
        [Column("ID_VENDA")]
        public int Id { get; set; }

        [Key]
        [Column("ID_USER")]
        public int Id_User { get; set; }

        [Column("NAME_USER", TypeName = "VARCHAR(100)")]
        public string NameUser { get; set; }

        //Um blog tem um usuário, um usuário tem uma lista de blogs
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
