using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBaseDD.Data;
using ProyectoBaseDD.Models;

namespace ProyectoBaseDD.Pages.Carreras
{
    public class DetailsModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public DetailsModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

      public Carrera Carrera { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Carreras == null)
            {
                return NotFound();
            }

            var carrera = await _context.Carreras.FirstOrDefaultAsync(m => m.CveCarrera == id);
            if (carrera == null)
            {
                return NotFound();
            }
            else 
            {
                Carrera = carrera;
            }
            return Page();
        }
    }
}
