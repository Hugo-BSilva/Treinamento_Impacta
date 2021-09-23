using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TesteScaffold.Models
{
    [Table("TB_MOVIE")]
    public class Movie
    {
        [Key]
        [Column("ID_MOVIE")]
        public int Id { get; set; }

        [Column("ID_CLIENT")]
        public int IdClient { get; set; }

        [Column("TITLE")]
        public string Title { get; set; }

        [Column("DATA_RELEASE")]
        [DataType(DataType.Date)]
        public DateTime DateRelease { get; set; }

        [Column("GENRE")]
        public string Genre { get; set; }

        [Column("PRICE", TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }

    }
}
