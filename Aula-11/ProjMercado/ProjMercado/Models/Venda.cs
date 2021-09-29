using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjMercado.Models
{
    [Table("TB_VENDA")]
    public class Venda
    {
        [Key]
        [Column("ID_VENDA")]
        public int Id { get; set; }

        [Column("ID_USUARIO_VENDA", TypeName = "nvarchar(450)")]
        public string Id_Usuario { get; set; }

        [Column("VALOR_TOTAL", TypeName = "decimal(10,2)")]
        public decimal Valor_Total { get; set; }


        [ForeignKey("Id_Usuario")]
        public virtual IdentityUser Usuario { get; set; }
        public virtual ICollection<VendaItem> Items { get; set; }
    }
}
