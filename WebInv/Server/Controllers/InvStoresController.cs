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
    public class InvStoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InvStoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InvStores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvStore>>> GetInvStore()
        {
            return await _context.InvStores.ToListAsync();
        }

        // GET: api/InvStores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvStore>> GetInvStore(int id)
        {
            var invStore = await _context.InvStores.FindAsync(id);

            if (invStore == null)
            {
                return NotFound();
            }

            return invStore;
        }

        // PUT: api/InvStores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvStore(int id, InvStore invStore)
        {
            if (id != invStore.Id)
            {
                return BadRequest();
            }

            _context.Entry(invStore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvStoreExists(id))
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

        // POST: api/InvStores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvStore>> PostInvStore(InvStore invStore)
        {
            _context.InvStores.Add(invStore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvStore", new { id = invStore.Id }, invStore);
        }

        // DELETE: api/InvStores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvStore(int id)
        {
            var invStore = await _context.InvStores.FindAsync(id);
            if (invStore == null)
            {
                return NotFound();
            }

            _context.InvStores.Remove(invStore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvStoreExists(int id)
        {
            return _context.InvStores.Any(e => e.Id == id);
        }
    }
}
