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

namespace ProyectoBaseDD.Pages.Horario
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public EditModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Horario Horario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }

            var horario =  await _context.Horarios.FirstOrDefaultAsync(m => m.CveAsig == id);
            if (horario == null)
            {
                return NotFound();
            }
            Horario = horario;
           ViewData["CveAsig"] = new SelectList(_context.Asignaturas, "CveAsig", "CveAsig");
           ViewData["IdProfesor"] = new SelectList(_context.Profesores, "IdProfesores", "IdProfesores");
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

            _context.Attach(Horario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorarioExists(Horario.CveAsig))
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

        private bool HorarioExists(string id)
        {
          return _context.Horarios.Any(e => e.CveAsig == id);
        }
    }
}
