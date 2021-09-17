using MaosAObra;
using MaosAObra.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEntityFramework
{
    class MaosAObrakDBContext : DbContext
    {
        //Lista de tabelas que queremos, tabela de blog
        public DbSet<Blog> Blog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-2D092G7\\SQLEXPRESS;Database=TESTE_ENTITYFRAMEWORK;trusted_connection=true");
        }


        //Vai sobrescrever o método OnModelCreating da classe DbContext
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Pega todas as chaves estrangeiras, e guarda cada uma em relationship
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                /* Altera a propriedade DeleteBehavior da migration gerada de cascade para: 
                 onDelete: ReferentialAction.Restrict. Assim quando um blog for deletado, o usuário
                que pertence aquele blog não será deletado. */
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }
}
