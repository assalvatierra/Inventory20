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
    public class IndexModel : PageModel
    {
        private readonly WebInv.Data.ApplicationDbContext _context;

        public IndexModel(WebInv.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<InvSupplier> InvSupplier { get;set; }

        public async Task OnGetAsync()
        {
            InvSupplier = await _context.InvSuppliers.ToListAsync();
        }
    }
}
