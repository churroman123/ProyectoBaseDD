using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBaseDD.Data;
using ProyectoBaseDD.Models;

namespace ProyectoBaseDD.Pages.Prerequisitos
{
    public class DetailsModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public DetailsModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

      public Prerequisito Prerequisito { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _context.Prerequisitos == null)
            {
                return NotFound();
            }

            var prerequisito = await _context.Prerequisitos.FirstOrDefaultAsync(m => m.IdPrerequisitos == id);
            if (prerequisito == null)
            {
                return NotFound();
            }
            else 
            {
                Prerequisito = prerequisito;
            }
            return Page();
        }
    }
}
