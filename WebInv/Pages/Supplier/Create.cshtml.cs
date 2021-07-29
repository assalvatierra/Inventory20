using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebDBSchema.Models;
using WebInv.Data;

namespace WebInv.Pages.Supplier
{
    public class CreateModel : PageModel
    {
        private readonly WebInv.Data.ApplicationDbContext _context;

        public CreateModel(WebInv.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public InvSupplier InvSupplier { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.InvSuppliers.Add(InvSupplier);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
