using APIforVisualRiders.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.Data;

namespace APIforVisualRiders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasableItemsController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public PurchasableItemsController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/PurchasableItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchasableItem>>> GetPurchasableItems()
        {
            return await _context.PurchasableItems.ToListAsync();
        }

        // GET: api/PurchasableItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchasableItem>> GetPurchasableItem(Guid id)
        {
            var purchasableItem = await _context.PurchasableItems.FindAsync(id);

            if (purchasableItem == null)
            {
                return NotFound();
            }

            return purchasableItem;
        }

        // GET: api/PurchasableItems/active
        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<PurchasableItem>>> GetPurchasableItemsActive()
        {
            var purchasableItems = await _context.PurchasableItems.ToListAsync();
            List<PurchasableItem> result = new List<PurchasableItem>();

            foreach (var item in purchasableItems)
            {
                if (item.Status == PurchasableItemStatus.Active)
                {
                    result.Add(item);
                }
            }
            return Ok(result);
        }

        // GET: api/PurchasableItems/active
        [HttpGet("deleted")]
        public async Task<ActionResult<IEnumerable<PurchasableItem>>> GetPurchasableItemsDeleted()
        {
            var purchasableItems = await _context.PurchasableItems.ToListAsync();
            List<PurchasableItem> result = new List<PurchasableItem>();

            foreach (var item in purchasableItems)
            {
                if (item.Status == PurchasableItemStatus.Deleted)
                {
                    result.Add(item);
                }
            }
            return Ok(result);
        }

        // PUT: api/PurchasableItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchasableItem(Guid id, PurchasableItem purchasableItem)
        {
            if (id != purchasableItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchasableItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchasableItemExists(id))
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

        // PUT: api/PurchasableItems/5/category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/category")]
        public async Task<IActionResult> PutPurchasableItemCategory(Guid id, Guid itemCategoryId)
        {
            var purchasableItem = await _context.PurchasableItems.FindAsync(id);

            if (id != purchasableItem.Id)
            {
                return BadRequest();
            }
            purchasableItem.ItemCategory = itemCategoryId;
            _context.Entry(purchasableItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchasableItemExists(id))
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

        // PUT: api/PurchasableItems/5/status
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/status")]
        public async Task<IActionResult> PutPurchasableItemStatus(Guid id, PurchasableItemStatus itemStatus)
        {
            var purchasableItem = await _context.PurchasableItems.FindAsync(id);

            if (id != purchasableItem.Id)
            {
                return BadRequest();
            }
            purchasableItem.Status = itemStatus;
            _context.Entry(purchasableItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchasableItemExists(id))
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

        // POST: api/PurchasableItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchasableItem>> PostPurchasableItem(PurchasableItem purchasableItem)
        {
            _context.PurchasableItems.Add(purchasableItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchasableItem", new { id = purchasableItem.Id }, purchasableItem);
        }

        // DELETE: api/PurchasableItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchasableItem(Guid id)
        {
            var purchasableItem = await _context.PurchasableItems.FindAsync(id);
            if (purchasableItem == null)
            {
                return NotFound();
            }

            _context.PurchasableItems.Remove(purchasableItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchasableItemExists(Guid id)
        {
            return _context.PurchasableItems.Any(e => e.Id == id);
        }
    }
}
