using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDBSchema.Models;
using WebInv.Server.Data;

namespace WebInv.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvSuppliersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InvSuppliersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InvSuppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvSupplier>>> GetInvSupplier()
        {
            return await _context.InvSuppliers.ToListAsync();
        }

        // GET: api/InvSuppliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvSupplier>> GetInvSupplier(int id)
        {
            var invSupplier = await _context.InvSuppliers.FindAsync(id);

            if (invSupplier == null)
            {
                return NotFound();
            }

            return invSupplier;
        }

        // PUT: api/InvSuppliers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvSupplier(int id, InvSupplier invSupplier)
        {
            if (id != invSupplier.Id)
            {
                return BadRequest();
            }

            _context.Entry(invSupplier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvSupplierExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InvSuppliers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvSupplier>> PostInvSupplier(InvSupplier invSupplier)
        {
            _context.InvSuppliers.Add(invSupplier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvSupplier", new { id = invSupplier.Id }, invSupplier);
        }

        // DELETE: api/InvSuppliers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvSupplier(int id)
        {
            var invSupplier = await _context.InvSuppliers.FindAsync(id);
            if (invSupplier == null)
            {
                return NotFound();
            }

            _context.InvSuppliers.Remove(invSupplier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvSupplierExists(int id)
        {
            return _context.InvSuppliers.Any(e => e.Id == id);
        }
    }
}
