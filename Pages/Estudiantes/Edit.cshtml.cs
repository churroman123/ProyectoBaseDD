using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoBaseDD.Data;
using ProyectoBaseDD.Models;

namespace ProyectoBaseDD.Pages.Estudiantes
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public EditModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Estudiante Estudiante { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiante =  await _context.Estudiantes.FirstOrDefaultAsync(m => m.Ncontrol == id);
            if (estudiante == null)
            {
                return NotFound();
            }
            Estudiante = estudiante;
            ViewData["CveCarrera"] = new SelectList(_context.Carreras, "CveCarrera", "CveCarrera");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Estudiante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(Estudiante.Ncontrol))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EstudianteExists(string id)
        {
          return _context.Estudiantes.Any(e => e.Ncontrol == id);
        }
    }
}
