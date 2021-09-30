using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    public class TodoAPIDBContext : DbContext
    {
        public TodoAPIDBContext(DbContextOptions<TodoAPIDBContext> options)
           : base(options)
        {
        }
        public DbSet<TodoItem> TodoItem { get; set; }
    }
}
