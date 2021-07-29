using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebDBSchema.Models;
using WebInv.Data;

namespace WebInv.Pages.Supplier
{
    public class DetailsModel : PageModel
    {
        private readonly WebInv.Data.ApplicationDbContext _context;

        public DetailsModel(WebInv.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public InvSupplier InvSupplier { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InvSupplier = await _context.InvSuppliers.FirstOrDefaultAsync(m => m.Id == id);

            if (InvSupplier == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
