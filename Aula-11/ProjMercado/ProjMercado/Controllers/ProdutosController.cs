using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjMercado.Data;
using ProjMercado.Models;

namespace ProjMercado.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class ProdutosController : Controller
    {
        private readonly ProjMercadoContext _context;

        public ProdutosController(ProjMercadoContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produto.ToListAsync());
        }

        [Route("Details/{id}")]
        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.Id_Produto == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [Route("Create")]
        // GET: Produtos/Create        
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<IActionResult> Create(int Id_Produto, string Nome_Produto, string Preco_ProdutoDigitado, DateTime Data_Validade, string Tipo_Produto)
        {
            var Preco_ProdutoConvertido = Preco_ProdutoDigitado.Replace(".", ",");

            var produto = new Produto()
            {
                Id_Produto = Id_Produto,
                Nome_Produto = Nome_Produto,
                Preco_Produto = decimal.Parse(Preco_ProdutoConvertido),
                Data_Validade = Data_Validade,
                Tipo_Produto = Tipo_Produto
            };

            if (ModelState.IsValid)
            {                
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        [Route("Edit/{id}")]
        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Produto,Nome_Produto,Preco_Produto,Data_Validade,Tipo_Produto")] Produto produto)
        {
            if (id != produto.Id_Produto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id_Produto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        [Route("Delete/{id}")]
        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.Id_Produto == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.Id_Produto == id);
        }
    }
}
