using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTToken.Models
{
    public class JWTTokenTesteDBContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        public JWTTokenTesteDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
