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

namespace ProyectoBaseDD.Pages.Profesores
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public EditModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Profesore Profesore { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {

            if (id == null || _context.Profesores == null)
            {
                return NotFound();
            }

            var profesore =  await _context.Profesores.FirstOrDefaultAsync(m => m.IdProfesores == id);
            if (profesore == null)
            {
                return NotFound();
            }
            Profesore = profesore;
           ViewData["Depto"] = new SelectList(_context.Carreras, "CveCarrera", "Nombre");
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

            _context.Attach(Profesore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesoreExists(Profesore.IdProfesores))
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

        private bool ProfesoreExists(string id)
        {
          return _context.Profesores.Any(e => e.IdProfesores == id);
        }
    }
}
