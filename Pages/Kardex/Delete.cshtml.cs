using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBaseDD.Data;
using ProyectoBaseDD.Models;

namespace ProyectoBaseDD.Pages.Kardex
{
    public class DeleteModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public DeleteModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Models.Kardex Kardex { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Kardices == null)
            {
                return NotFound();
            }

            var kardex = await _context.Kardices.FirstOrDefaultAsync(m => m.IdKardex == id);

            if (kardex == null)
            {
                return NotFound();
            }
            else 
            {
                Kardex = kardex;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Kardices == null)
            {
                return NotFound();
            }
            var kardex = await _context.Kardices.FindAsync(id);

            if (kardex != null)
            {
                Kardex = kardex;
                _context.Kardices.Remove(Kardex);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
