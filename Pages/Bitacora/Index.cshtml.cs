using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBaseDD.Models;

namespace ProyectoBaseDD.Pages.Bitacora
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public IndexModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

        public IList<Models.Bitacora> Bitacora { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Bitacoras != null)
            {
                Bitacora = await _context.Bitacoras.ToListAsync();
            }
        }
    }
}
