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

namespace ProyectoBaseDD.Pages.Asignatura
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public EditModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Asignatura Asignatura { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Asignaturas == null)
            {
                return NotFound();
            }

            var asignatura =  await _context.Asignaturas.Include(a => a.CveCarreraNavigation).FirstOrDefaultAsync(m => m.CveAsig == id);
            if (asignatura == null)
            {
                return NotFound();
            }
            Asignatura = asignatura;
           ViewData["CveCarrera"] = new SelectList(_context.Carreras, "CveCarrera", "Nombre");
            
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

            _context.Attach(Asignatura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignaturaExists(Asignatura.CveAsig))
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

        private bool AsignaturaExists(string id)
        {
          return _context.Asignaturas.Any(e => e.CveAsig == id);
        }
    }
}
