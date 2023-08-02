using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBaseDD.Data;
using ProyectoBaseDD.Models;

namespace ProyectoBaseDD.Pages.Asignatura
{
    public class DetailsModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public DetailsModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

      public Models.Asignatura Asignatura { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Asignaturas == null)
            {
                return NotFound();
            }

            var asignatura = await _context.Asignaturas.FirstOrDefaultAsync(m => m.CveAsig == id);
            if (asignatura == null)
            {
                return NotFound();
            }
            else 
            {
                Asignatura = asignatura;
            }
            return Page();
        }
    }
}
