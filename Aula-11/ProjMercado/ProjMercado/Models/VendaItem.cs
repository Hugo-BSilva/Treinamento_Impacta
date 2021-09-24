using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjMercado.Models
{
    [Table("TB_VENDA_ITEM")]
    class VendaItem
    {
        [Key]
        [Column("ID_VENDA_ITEM")]
        public int Id { get; set; }

        [Column("ID_VENDA")]
        public int Id_Venda { get; set; }

        [Column("ID_PRODUTO")]
        public int Id_Produto { get; set; }

        [Column("QUANTIDADE")]
        public int  Quantidade { get; set; }


        // CHAVES ESTRANGEIRAS, DE FORMA RESPECTIVA
        [ForeignKey("Id_Venda")]
        public virtual Venda Venda { get; set; }
        [ForeignKey("Id_Produto")]
        public virtual Produto Produto { get; set; }
    }
}
