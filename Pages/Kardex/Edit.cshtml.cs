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

namespace ProyectoBaseDD.Pages.Kardex
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public EditModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Kardex Kardex { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Kardices == null)
            {
                return NotFound();
            }

            var kardex =  await _context.Kardices.FirstOrDefaultAsync(m => m.IdKardex == id);
            if (kardex == null)
            {
                return NotFound();
            }
            Kardex = kardex;
           ViewData["CveAsig"] = new SelectList(_context.Asignaturas, "CveAsig", "CveAsig");
           ViewData["Ncontrol"] = new SelectList(_context.Estudiantes, "Ncontrol", "Ncontrol");
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

            _context.Attach(Kardex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KardexExists(Kardex.IdKardex))
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

        private bool KardexExists(int id)
        {
          return _context.Kardices.Any(e => e.IdKardex == id);
        }
    }
}
