using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjMercado.Models
{
    
    class Usuario
    {
        
        public int Id { get; set; }

        
        public string Nome_Usuario { get; set; }

        
        public string Data_Nascimento { get; set; }

        //Uma venda tem um usuário, um usuário tem uma lista de vendas
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
