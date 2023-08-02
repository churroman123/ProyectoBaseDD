using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBaseDD.Data;
using ProyectoBaseDD.Models;

namespace ProyectoBaseDD.Pages.Profesores
{
    public class DeleteModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public DeleteModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Profesore Profesore { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Profesores == null)
            {
                return NotFound();
            }

            var profesore = await _context.Profesores.FirstOrDefaultAsync(m => m.IdProfesores == id);

            if (profesore == null)
            {
                return NotFound();
            }
            else 
            {
                Profesore = profesore;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Profesores == null)
            {
                return NotFound();
            }
            var profesore = await _context.Profesores.FindAsync(id);

            if (profesore != null)
            {
                Profesore = profesore;
                _context.Profesores.Remove(Profesore);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
