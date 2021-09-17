using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaosAObra02.Models
{
    [Table("TB_PEDIDO")]
    class Pedido
    {
        [Key]
        [Column("ID_PEDIDO")]
        public int Id_Pedido { get; set; }

        [Column("ID_PRODUTO_PEDIDO")]
        public int Id_Produto_Pedido { get; set; }

        [Column("VALOR_PEDIDO")]
        public decimal Valor_Pedido { get; set; }

        [Column("DESCRICAO_PEDIDO", TypeName = "VARCHAR(200)")]
        public string Descricao_Pedido { get; set; }


        [ForeignKey("Id_Produto_Pedido")]
        public virtual Produto Produto { get; set; }
    }
}
