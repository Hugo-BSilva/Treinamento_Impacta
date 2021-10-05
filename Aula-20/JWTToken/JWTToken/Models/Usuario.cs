using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JWTToken.Models
{
    [Table("TB_USUARIO")]
    public class Usuario
    {
        [Key]
        [Column("ID_USUARIO")]
        public int Id { get; set; }
        [Column("NM_USUARIO", TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }
        [Column("CD_EMAIL", TypeName ="VARCHAR(60)")]
        public string Email { get; set; }

        [JsonIgnore]
        [Column("CD_SENHA", TypeName = "VARCHAR(20)")]
        public string Senha { get; set; }
        [Column("CD_PERFIL", TypeName = "VARCHAR(20)")]
        public string Perfil { get; set; }
    }
}
