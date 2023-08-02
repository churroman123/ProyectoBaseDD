using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBaseDD.Data;
using ProyectoBaseDD.Models;

namespace ProyectoBaseDD.Pages.Prerequisitos
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
        ViewData["CveAsig"] = new SelectList(_context.Asignaturas, "CveAsig", "CveAsig");
        ViewData["IdKardex"] = new SelectList(_context.Kardices, "IdKardex", "IdKardex");
            return Page();
        }

        [BindProperty]
        public Prerequisito Prerequisito { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Prerequisitos.Add(Prerequisito);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
