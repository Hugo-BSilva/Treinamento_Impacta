using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaosAObra02.Models
{
    [Table("TB_BLOG")]
    class Blog
    {
        [Key]
        [Column("ID_BLOG")]
        public int Id { get; set; }
        [Column("ID_USER_BLOG")]
        public int IdUser { get; set; }

        [Column("DSC_BLOG", TypeName = "VARCHAR(100)")]
        public string Name { get; set; }
        [Column("DT_CREATED")]
        public DateTime CreatedTimeStamp { get; set; }

        //Um blog tem um usuário, um usuário tem uma lista de blogs
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }
    }
}
