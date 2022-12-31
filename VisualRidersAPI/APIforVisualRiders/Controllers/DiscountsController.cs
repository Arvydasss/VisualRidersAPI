using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using apiForVisualRiders.Models;

namespace APIforVisualRiders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly VisualRidersContext _context;

        public DiscountsController(VisualRidersContext context)
        {
            _context = context;
        }

        // GET: api/Discounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discount>>> GetDiscount()
        {
            return await _context.Discount.ToListAsync();
        }

        // GET: api/Discounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Discount>> GetDiscount(Guid id)
        {
            var discount = await _context.Discount.FindAsync(id);

            if (discount == null)
            {
                return NotFound();
            }

            return discount;
        }

        // PUT: api/Discounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscount(Guid id, Discount discount)
        {
            if (id != discount.Id)
            {
                return BadRequest();
            }

            _context.Entry(discount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscountExists(id))
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

        // POST: api/Discounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Discount>> PostDiscount(Discount discount)
        {
            _context.Discount.Add(discount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiscount", new { id = discount.Id }, discount);
        }

        // DELETE: api/Discounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscount(Guid id)
        {
            var discount = await _context.Discount.FindAsync(id);
            if (discount == null)
            {
                return NotFound();
            }

            _context.Discount.Remove(discount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiscountExists(Guid id)
        {
            return _context.Discount.Any(e => e.Id == id);
        }
    }
}
