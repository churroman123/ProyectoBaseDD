using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBaseDD.Models;

namespace ProyectoBaseDD.Pages.Bitacora
{
    public class DetailsModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public DetailsModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

      public Models.Bitacora Bitacora { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bitacoras == null)
            {
                return NotFound();
            }

            var bitacora = await _context.Bitacoras.FirstOrDefaultAsync(m => m.IdBitacora == id);
            if (bitacora == null)
            {
                return NotFound();
            }
            else 
            {
                Bitacora = bitacora;
            }
            return Page();
        }
    }
}
