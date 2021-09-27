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
    [Route("Vendas/")]
    public class VendasController : Controller
    {
        private readonly ProjMercadoContext _context;

        public VendasController(ProjMercadoContext context)
        {
            _context = context;
        }

        [Route("Index")]
        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var projMercadoContext = _context.Venda.Include(v => v.Usuario);
            return View(await projMercadoContext.ToListAsync());
        }

        [Route("Details/{id}")]
        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        [Route("[controller]")]
        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewData["Id_Usuario"] = new SelectList(_context.Usuario, "Id", "Nome");
            ViewData["Produtos"] = new SelectList(_context.Produto, "Id", "Produto");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<IActionResult> Create(int Id_Usuario, int Id_Produto, int quantidade)
        {
            if (Id_Usuario <= 0)
            {
                ViewData["ErrorUsuario"] = "Usuario nao informado";
            }
            if (Id_Produto <= 0)
            {
                ViewData["ErrorProduto"] = "Produto nao informado";
            }
            if (quantidade <= 0)
            {
                ViewData["ErrorQuantidade"] = "Quantidade nao informada";
            }
            Venda venda = null;
            if (ModelState.IsValid)
            {
                var produto = await _context.Produto.FirstOrDefaultAsync(p => p.Id_Produto == Id_Produto);
                if (produto == null)
                {
                    return NotFound();
                }
                venda = new Venda()
                {
                    Id_Usuario = Id_Usuario,
                    Valor_Total = produto.Preco_Produto
                };
                var item = new VendaItem()
                {
                    Id_Produto = Id_Produto,
                    Id_Venda = venda.Id,
                    Quantidade = quantidade
                };

                //_context.Add(venda);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                
                _context.VendaItem.Add(item);
                await _context.SaveChangesAsync();
                
            }
            
            ViewData["Produtos"] = new SelectList(_context.Produto, "Id", "Nome", 0);
            Venda vendaAtualizada = null;
            if(vendaAtualizada == null)
            {
                ViewData["Id_Usuario"] = new SelectList(_context.Usuario, "Id", "Id", venda.Id_Usuario);
                var vendaAtualizada = await getVendaAtualizada(venda.Id);
            }
            

            return View(vendaAtualizada);
        }       

        private bool VendaExists(int id)
        {
            return _context.Venda.Any(e => e.Id = id);
        }

        private async Venda getVendaAtualizada(int id)
        {
            var venda = await _context.Venda
                .Include()

             
        }
    }
}
