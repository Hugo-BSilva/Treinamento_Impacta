using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjMercado.Models;

namespace ProjMercado.Data
{
    public class ProjMercadoContext : IdentityDbContext
    {
        public ProjMercadoContext (DbContextOptions<ProjMercadoContext> options)
            : base(options)
        {
        }

        public DbSet<ProjMercado.Models.Produto> Produto { get; set; }

        public DbSet<ProjMercado.Models.Venda> Venda { get; set; }

        public DbSet<ProjMercado.Models.VendaItem> VendaItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach(var relationshitp in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationshitp.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
