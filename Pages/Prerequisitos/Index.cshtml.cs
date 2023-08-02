using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBaseDD.Data;
using ProyectoBaseDD.Models;

namespace ProyectoBaseDD.Pages.Prerequisitos
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public IndexModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

        public IList<Prerequisito> Prerequisito { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Prerequisitos != null)
            {
                Prerequisito = await _context.Prerequisitos
                .Include(p => p.CveAsigNavigation)
                .Include(p => p.IdKardexNavigation).ToListAsync();
            }
        }
    }
}
