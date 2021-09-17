using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEntityFramework.Models
{
    //Data Annotations = Carimbos que possuem um comportamento
    [Table("TB_BLOG")]
    class Blog
    {
        //Para o reconhecimento do ID como chave primária
        [Key]
        [Column("ID_BLOG")]
        public int Id { get; set; }

        [Column("ID_USER_BLOG")]
        public int IdUser { get; set; }

        [Column("ID_BLOG", TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        [Column("DT_CREATED")]
        public DateTime CreatedTimeStamp { get; set; }

        [ForeignKey("IdUser")]
        public virtual User user { get; set; }
    }
}
