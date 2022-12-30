using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIforVisualRiders.Models;
using Northwind.Data;

namespace APIforVisualRiders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoriesController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public ItemCategoriesController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/ItemCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemCategory>>> GetItemCategory()
        {
            return await _context.ItemCategory.ToListAsync();
        }

        // GET: api/ItemCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemCategory>> GetItemCategory(Guid id)
        {
            var itemCategory = await _context.ItemCategory.FindAsync(id);

            if (itemCategory == null)
            {
                return NotFound();
            }

            return itemCategory;
        }

        // PUT: api/ItemCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemCategory(Guid id, ItemCategory itemCategory)
        {
            if (id != itemCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemCategoryExists(id))
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

        // POST: api/ItemCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemCategory>> PostItemCategory(ItemCategory itemCategory)
        {
            _context.ItemCategory.Add(itemCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemCategory", new { id = itemCategory.Id }, itemCategory);
        }

        //POST: api/ItemCategories/5/apply
        [HttpPost("{id}/apply")]
        public async Task<IActionResult> ApplyCategory(Guid id, Guid purchasableItemId)
        {
            var category = _context.ItemCategory.Find(id);
            if (category != null)
            {
                _context.PurchasableItems.Find(purchasableItemId).ItemCategory = id;
            }
            else
            {
                return NotFound();
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemCategoryExists(id))
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

        // DELETE: api/ItemCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemCategory(Guid id)
        {
            var itemCategory = await _context.ItemCategory.FindAsync(id);
            if (itemCategory == null)
            {
                return NotFound();
            }

            _context.ItemCategory.Remove(itemCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //DELETE: api/ItemCategories/5/apply
        [HttpDelete("{id}/apply")]
        public async Task<IActionResult> DeleteCategory(Guid id, Guid purchasableItemId)
        {
            var itemCategory = await _context.ItemCategory.FindAsync(id);
            if (itemCategory == null)
            {
                return NotFound();
            }

            _context.PurchasableItems.Find(purchasableItemId).ItemCategory = null;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ItemCategoryExists(Guid id)
        {
            return _context.ItemCategory.Any(e => e.Id == id);
        }
    }
}
