using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoBaseDD.Models;

namespace ProyectoBaseDD.Pages.Bitacora
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public EditModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Bitacora Bitacora { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bitacoras == null)
            {
                return NotFound();
            }

            var bitacora =  await _context.Bitacoras.FirstOrDefaultAsync(m => m.IdBitacora == id);
            if (bitacora == null)
            {
                return NotFound();
            }
            Bitacora = bitacora;
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

            _context.Attach(Bitacora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BitacoraExists(Bitacora.IdBitacora))
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

        private bool BitacoraExists(int id)
        {
          return _context.Bitacoras.Any(e => e.IdBitacora == id);
        }
    }
}
