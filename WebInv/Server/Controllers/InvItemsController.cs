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
    public class InvItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InvItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InvItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvItem>>> GetInvItem()
        {
            try
            {

                return await _context.InvItems
                    .Include(i=>i.InvUom)
                    .ToListAsync();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/InvItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvItem>> GetInvItem(int id)
        {
            var invItem = await _context.InvItems.Include(i=>i.InvUom)
                                .Where(i=>i.Id == id)
                                .FirstAsync();

            if (invItem == null)
            {
                return NotFound();
            }

            return invItem;
        }

        // PUT: api/InvItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvItem(int id, InvItem invItem)
        {
            if (id != invItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(invItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvItemExists(id))
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

        // POST: api/InvItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvItem>> PostInvItem(InvItem invItem)
        {
            _context.InvItems.Add(invItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvItem", new { id = invItem.Id }, invItem);
        }

        // DELETE: api/InvItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvItem(int id)
        {
            var invItem = await _context.InvItems.FindAsync(id);
            if (invItem == null)
            {
                return NotFound();
            }

            _context.InvItems.Remove(invItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvItemExists(int id)
        {
            return _context.InvItems.Any(e => e.Id == id);
        }
    }
}
