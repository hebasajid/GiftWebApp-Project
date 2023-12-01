using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftInfoLibraryy.Models;

namespace GiftAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentGiftsController : ControllerBase
    {
        private readonly GiftInfoDbContext _context;

        public ParentGiftsController(GiftInfoDbContext context)
        {
            _context = context;
        }

        // GET: api/ParentGifts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParentGift>>> GetParentGifts()
        {
          if (_context.ParentGifts == null)
          {
              return NotFound();
          }
            return await _context.ParentGifts.ToListAsync();
        }

        // GET: api/ParentGifts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParentGift>> GetParentGift(int id)
        {
          if (_context.ParentGifts == null)
          {
              return NotFound();
          }
            var parentGift = await _context.ParentGifts.FindAsync(id);

            if (parentGift == null)
            {
                return NotFound();
            }

            return parentGift;
        }

        // PUT: api/ParentGifts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParentGift(int id, ParentGift parentGift)
        {
            if (id != parentGift.PGiftId)
            {
                return BadRequest();
            }

            _context.Entry(parentGift).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParentGiftExists(id))
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

        // POST: api/ParentGifts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParentGift>> PostParentGift(ParentGift parentGift)
        {
          if (_context.ParentGifts == null)
          {
              return Problem("Entity set 'GiftInfoDbContext.ParentGifts'  is null.");
          }
            _context.ParentGifts.Add(parentGift);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParentGift", new { id = parentGift.PGiftId }, parentGift);
        }

        // DELETE: api/ParentGifts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParentGift(int id)
        {
            if (_context.ParentGifts == null)
            {
                return NotFound();
            }
            var parentGift = await _context.ParentGifts.FindAsync(id);
            if (parentGift == null)
            {
                return NotFound();
            }

            _context.ParentGifts.Remove(parentGift);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParentGiftExists(int id)
        {
            return (_context.ParentGifts?.Any(e => e.PGiftId == id)).GetValueOrDefault();
        }
    }
}
