using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjMercado.Data;
using ProjMercado.Models;

namespace ProjMercado.Controllers
{
    [Controller]
    [Route("/")]
    public class VendasController : Controller
    {
        private readonly ProjMercadoContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public VendasController(ProjMercadoContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //Trás a lista de vendas + usuários e produtos
        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var isAdmin = User.IsInRole("ADMIN");
                var user = await _userManager.FindByEmailAsync(User.Identity.Name);

                var projMercadoContext = _context.Venda
                    .Include(v => v.Usuario)
                    .Include(v => v.Items)
                    .ThenInclude(i => i.Produto)
                    .Where(v => isAdmin == true || (v.Id_Usuario == user.Id));
                return View(await projMercadoContext.ToListAsync());
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }

        [Route("Details/{id}")]
        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            var venda = await getVendaAtualizada(id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }


        [Route("Create")]
        // GET: Vendas/Create
        public IActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

            //ViewData["Id_Usuario"] = new SelectList(_context.Usuario, "Id", "Nome");
            ViewData["Produtos"] = new SelectList(_context.Produto, "Id", "Nome");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<IActionResult> Create(int Id_Usuario, int Id_Produto, int quantidade, int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

            //Apresenta erro caso o usuário não passe uma das 3 informações
            //if (Id_Usuario <= 0)
            //{
            //    ViewData["ErrorUsuario"] = "Usuario nao informado";
            //}
            if (Id_Produto <= 0)
            {
                ViewData["ErrorProduto"] = "Produto nao informado";
            }

            //Verifica se o produto foi encontrado
            var produto = await _context.Produto.FirstOrDefaultAsync(p => p.Id_Produto == Id_Produto);
            if (produto == null)
            {
                return NotFound();
            }

            if (quantidade <= 0)
            {
                ViewData["ErrorQuantidade"] = "Quantidade nao informada";
            }


            Venda venda = null;
            if (id > 0)
            {
                venda = await getVendaAtualizada(id);
            }

            if (Id_Produto > 0 && quantidade > 0)
            {
                if (id == null || id == 0)
                {
                    var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                    venda = new Venda()
                    {
                        Id_Usuario = user.Id,
                        Valor_Total = produto.Preco_Produto * quantidade
                    };

                    _context.Add(venda);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    venda.Valor_Total += produto.Preco_Produto * quantidade;
                    await _context.SaveChangesAsync();
                }

                var itens = new VendaItem()
                {
                    Id_Produto = produto.Id_Produto,
                    Id_Venda = venda.Id,
                    Quantidade = quantidade
                };

                _context.VendaItem.Add(itens);
                await _context.SaveChangesAsync();
            }
            
            ViewData["Produtos"] = new SelectList(_context.Produto, "Id", "Nome");
            Venda vendaAtualizada = null;

            if (vendaAtualizada != null)
            {
                //ViewData["Id_Usuario"] = new SelectList(_context.Usuario, "Id", "Nome", venda.Id_Usuario);
                vendaAtualizada = await getVendaAtualizada(venda.Id);
            }

            return View(vendaAtualizada);
        } 

        //Verifica se a venda existe
        private bool VendaExists(int id)
        {
            return _context.Venda.Any(e => e.Id == id);
        }

        //Trás a venda atualizada pegando pelo id da mesma
        private async Task<Venda> getVendaAtualizada(int? id)
        {
            var venda = await _context.Venda
                .Include(v => v.Usuario)
                .Include(v => v.Items)
                .ThenInclude(i => i.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            return venda;             
        }
    }
}
