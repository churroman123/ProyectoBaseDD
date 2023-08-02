using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBaseDD.Data;
using ProyectoBaseDD.Models;

namespace ProyectoBaseDD.Pages.Profesores
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBaseDD.Data.practica2Context _context;

        public CreateModel(ProyectoBaseDD.Data.practica2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Depto"] = new SelectList(_context.Carreras, "CveCarrera", "CveCarrera");
            return Page();
        }

        [BindProperty]
        public Profesore Profesore { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Profesores.Add(Profesore);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
