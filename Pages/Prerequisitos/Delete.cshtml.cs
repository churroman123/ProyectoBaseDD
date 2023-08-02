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
    public class DeleteModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public DeleteModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Prerequisito Prerequisito { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Prerequisitos == null)
            {
                return NotFound();
            }

            var prerequisito = await _context.Prerequisitos.FirstOrDefaultAsync(m => m.IdPrerequisitos == id);

            if (prerequisito == null)
            {
                return NotFound();
            }
            else 
            {
                Prerequisito = prerequisito;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Prerequisitos == null)
            {
                return NotFound();
            }
            var prerequisito = await _context.Prerequisitos.FindAsync(id);

            if (prerequisito != null)
            {
                Prerequisito = prerequisito;
                _context.Prerequisitos.Remove(Prerequisito);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
