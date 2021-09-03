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
    public class InvUomsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InvUomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InvUoms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvUom>>> GetInvUom()
        {
            return await _context.InvUoms.ToListAsync();
        }

        // GET: api/InvUoms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvUom>> GetInvUom(int id)
        {
            var invUom = await _context.InvUoms.FindAsync(id);

            if (invUom == null)
            {
                return NotFound();
            }

            return invUom;
        }

        // PUT: api/InvUoms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvUom(int id, InvUom invUom)
        {
            if (id != invUom.Id)
            {
                return BadRequest();
            }

            _context.Entry(invUom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvUomExists(id))
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

        // POST: api/InvUoms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvUom>> PostInvUom(InvUom invUom)
        {
            _context.InvUoms.Add(invUom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvUom", new { id = invUom.Id }, invUom);
        }

        // DELETE: api/InvUoms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvUom(int id)
        {
            var invUom = await _context.InvUoms.FindAsync(id);
            if (invUom == null)
            {
                return NotFound();
            }

            _context.InvUoms.Remove(invUom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvUomExists(int id)
        {
            return _context.InvUoms.Any(e => e.Id == id);
        }
    }
}
