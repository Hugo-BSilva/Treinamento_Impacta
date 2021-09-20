using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaosAObra02.Models
{
    [Table("TB_USER")]
    class User
    {
        [Key]
        [Column("ID_USER")]
        public int Id { get; set; }
        [Column("DSC_USER", TypeName = "VARCHAR(100)")]
        public string NameUser { get; set; }

        //Um blog tem um usuário, um usuário tem uma lista de blogs
        public virtual ICollection<Blog> Blog { get; set; }
    }
}
