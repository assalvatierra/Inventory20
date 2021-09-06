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
    public class InvClassificationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InvClassificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InvClassifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvClassification>>> GetInvClassification()
        {
            return await _context.InvClassifications.ToListAsync();
        }

        // GET: api/InvClassifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvClassification>> GetInvClassification(int id)
        {
            var invClassification = await _context.InvClassifications.FindAsync(id);

            if (invClassification == null)
            {
                return NotFound();  
            }

            return invClassification;
        }

        // PUT: api/InvClassifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvClassification(int id, InvClassification invClassification)
        {
            if (id != invClassification.Id)
            {
                return BadRequest();
            }

            _context.Entry(invClassification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvClassificationExists(id))
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

        // POST: api/InvClassifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvClassification>> PostInvClassification(InvClassification invClassification)
        {
            _context.InvClassifications.Add(invClassification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvClassification", new { id = invClassification.Id }, invClassification);
        }

        // DELETE: api/InvClassifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvClassification(int id)
        {
            var invClassification = await _context.InvClassifications.FindAsync(id);
            if (invClassification == null)
            {
                return NotFound();
            }

            _context.InvClassifications.Remove(invClassification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvClassificationExists(int id)
        {
            return _context.InvClassifications.Any(e => e.Id == id);
        }
    }
}
