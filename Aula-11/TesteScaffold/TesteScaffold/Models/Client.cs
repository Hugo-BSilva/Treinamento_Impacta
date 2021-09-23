using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TesteScaffold.Models
{
    [Table("TB_CLIENT")]
    public class Client
    {
        [Key]
        [Column("ID_CLIENT")]
        public int Id { get; set; }

        [Column("NAME_CLIENT")]
        public string NameClient { get; set; }

        [Column("LOCATOR")]
        public bool Locator { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
