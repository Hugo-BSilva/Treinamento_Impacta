using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TesteScaffold.Data;
using TesteScaffold.Models;

namespace TesteScaffold.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly TesteScaffold.Data.TesteScaffoldContext _context;

        public IndexModel(TesteScaffold.Data.TesteScaffoldContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
