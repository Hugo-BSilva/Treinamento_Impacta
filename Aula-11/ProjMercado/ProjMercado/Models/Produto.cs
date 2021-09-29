using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjMercado.Models
{
    [Table("TB_PRODUTO")]
    public class Produto
    {
        [Key]
        [Column("ID_PRODUTO")]
        public int Id_Produto { get; set; }

        [Column("NOME_PRODUTO", TypeName = "VARCHAR(250)")]
        public string Nome_Produto { get; set; }

        [Column("PRECO_PRODUTO", TypeName = "decimal(10,2)")]
        public decimal Preco_Produto { get; set; }

        [Column("DATA_VALIDADE")]
        [DataType(DataType.Date)]
        public DateTime Data_Validade { get; set; }

        [Column("TIPO_PRODUTO")]
        public string Tipo_Produto { get; set; }

        [NotMapped]
        public string ValorAExibir { get; set; }

        //Um produto tem uma VendaItem, uma VendaItem tem uma lista de produtos
        public virtual ICollection<VendaItem> ItensDoProdutoVendido { get; set; }

    }

}
