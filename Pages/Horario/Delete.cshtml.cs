using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBaseDD.Data;
using ProyectoBaseDD.Models;

namespace ProyectoBaseDD.Pages.Horario
{
    public class DeleteModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public DeleteModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Models.Horario Horario { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios.FirstOrDefaultAsync(m => m.CveAsig == id);

            if (horario == null)
            {
                return NotFound();
            }
            else 
            {
                Horario = horario;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }
            var horario = await _context.Horarios.FindAsync(id);

            if (horario != null)
            {
                Horario = horario;
                _context.Horarios.Remove(Horario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
