using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEFP.Models
{
    [Table("TB_VENDA")]
    class Venda
    {
        [Key]
        [Column("ID_VENDA")]
        public int Id { get; set; }
        [Column("ID_USUARIO")]
        public int Id_Usuario { get; set; }

        [Column("VALOR_TOTAL")]
        public string Valor_Total { get; set; }

        [ForeignKey("Id_Usuario")]
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<VendaItem> Itens { get; set; }
    }
}
