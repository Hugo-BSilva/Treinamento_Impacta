using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjMercado.Models;

namespace ProjMercado.Data
{
    public class ProjMercadoContext : DbContext
    {
        public ProjMercadoContext (DbContextOptions<ProjMercadoContext> options)
            : base(options)
        {
        }

        public DbSet<ProjMercado.Models.Produto> Produto { get; set; }

        public DbSet<ProjMercado.Models.Usuario> Usuario { get; set; }

        public DbSet<ProjMercado.Models.Venda> Venda { get; set; }
    }
}
