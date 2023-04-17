using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppDeleite.Attributes;
using WebAppDeleite.Models;

namespace WebAppDeleite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class BuyDetailsController : ControllerBase
    {
        private readonly DeleiteContext _context;

        public BuyDetailsController(DeleiteContext context)
        {
            _context = context;
        }

        // GET: api/BuyDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyDetail>>> GetBuyDetails()
        {
          if (_context.BuyDetails == null)
          {
              return NotFound();
          }
            return await _context.BuyDetails.ToListAsync();
        }

        // GET: api/BuyDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuyDetail>> GetBuyDetail(int id)
        {
          if (_context.BuyDetails == null)
          {
              return NotFound();
          }
            var buyDetail = await _context.BuyDetails.FindAsync(id);

            if (buyDetail == null)
            {
                return NotFound();
            }

            return buyDetail;
        }

        // PUT: api/BuyDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuyDetail(int id, BuyDetail buyDetail)
        {
            if (id != buyDetail.BuyBuyId)
            {
                return BadRequest();
            }

            _context.Entry(buyDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyDetailExists(id))
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

        // POST: api/BuyDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BuyDetail>> PostBuyDetail(BuyDetail buyDetail)
        {
          if (_context.BuyDetails == null)
          {
              return Problem("Entity set 'DeleiteContext.BuyDetails'  is null.");
          }
            _context.BuyDetails.Add(buyDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BuyDetailExists(buyDetail.BuyBuyId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBuyDetail", new { id = buyDetail.BuyBuyId }, buyDetail);
        }

        // DELETE: api/BuyDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuyDetail(int id)
        {
            if (_context.BuyDetails == null)
            {
                return NotFound();
            }
            var buyDetail = await _context.BuyDetails.FindAsync(id);
            if (buyDetail == null)
            {
                return NotFound();
            }

            _context.BuyDetails.Remove(buyDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuyDetailExists(int id)
        {
            return (_context.BuyDetails?.Any(e => e.BuyBuyId == id)).GetValueOrDefault();
        }
    }
}
