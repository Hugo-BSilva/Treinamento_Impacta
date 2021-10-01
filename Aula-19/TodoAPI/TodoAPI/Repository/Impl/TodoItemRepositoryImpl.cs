using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Models;

namespace TodoAPI.Repository.Impl
{
    public class TodoItemRepositoryImpl : TodoItemRepository
    {
        private readonly TodoAPIDBContext _context;

        public TodoItemRepositoryImpl(TodoAPIDBContext context)
        {
            _context = context;
        }

        public async Task Atualizar(TodoItem todo)
        {
            _context.Entry(todo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var query = _context.TodoItem.Where(e => e.Id = id);
            _context.TodoItem.RemoveRange(query);
            await _context.SaveChangesAsync();
        }

        public async Task<TodoItem> GetById(int id)
        {
            var todoItem = await _context.TodoItem.FindAsync(id);
        }

        public async Task<List<IEnumerable<TodoItem>>> Listar()
        {
            //return await _context.TodoItem.ToList();
            return await _context.TodoItem.ToList();
        }

        public async Task Salvar(TodoItem todo)
        {
            _context.TodoItem.Add(todo);
            await _context.SaveChangesAsync();
        }
    }
}
