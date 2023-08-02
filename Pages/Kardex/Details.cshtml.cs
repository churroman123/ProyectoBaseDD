using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBaseDD.Data;
using ProyectoBaseDD.Models;

namespace ProyectoBaseDD.Pages.Kardex
{
    public class DetailsModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public DetailsModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

      public Models.Kardex Kardex { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Kardices == null)
            {
                return NotFound();
            }

            var kardex = await _context.Kardices.FirstOrDefaultAsync(m => m.IdKardex == id);
            if (kardex == null)
            {
                return NotFound();
            }
            else 
            {
                Kardex = kardex;
            }
            return Page();
        }
    }
}
