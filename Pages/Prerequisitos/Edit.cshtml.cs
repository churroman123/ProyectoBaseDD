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

namespace ProyectoBaseDD.Pages.Prerequisitos
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public EditModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Prerequisito Prerequisito { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Prerequisitos == null)
            {
                return NotFound();
            }

            var prerequisito =  await _context.Prerequisitos.FirstOrDefaultAsync(m => m.IdPrerequisitos == id);
            if (prerequisito == null)
            {
                return NotFound();
            }
            Prerequisito = prerequisito;
           ViewData["CveAsig"] = new SelectList(_context.Asignaturas, "CveAsig", "CveAsig");
           ViewData["IdKardex"] = new SelectList(_context.Kardices, "IdKardex", "IdKardex");
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

            _context.Attach(Prerequisito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrerequisitoExists(Prerequisito.IdPrerequisitos))
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

        private bool PrerequisitoExists(int id)
        {
          return _context.Prerequisitos.Any(e => e.IdPrerequisitos == id);
        }
    }
}
