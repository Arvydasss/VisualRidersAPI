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
    public class ServicesController : ControllerBase
    {
        private readonly VisualRidersContext _context;

        public ServicesController(VisualRidersContext context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetService()
        {
            return await _context.Service.ToListAsync();
        }

        // GET: api/Services/active
        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<Service>>> GetActiveServices()
        {
            var services = await _context.Service.ToListAsync();
            List<Service> result = new List<Service>();
            foreach (var service in services)
            {
                if(service.Status == ServiceStatus.Active)
                {
                    result.Add(service);
                }
            }
            return Ok(result);
        }

        // GET: api/Services/deleted
        [HttpGet("deleted")]
        public async Task<ActionResult<IEnumerable<Service>>> GetDeletedServices()
        {
            var services = await _context.Service.ToListAsync();
            List<Service> result = new List<Service>();
            foreach (var service in services)
            {
                if (service.Status != ServiceStatus.Active)
                {
                    result.Add(service);
                }
            }
            return Ok(result);
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(Guid id)
        {
            var service = await _context.Service.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }


        // PUT: api/Services/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(Guid id, Service service)
        {
            if (id != service.Id)
            {
                return BadRequest();
            }

            _context.Entry(service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
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

        // PUT: api/Services/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/status")]
        public async Task<IActionResult> PutServiceStatus(Guid id, ServiceStatus status)
        {
            var service = await _context.Service.FindAsync(id);

            if (id != service.Id)
            {
                return BadRequest();
            }

            //if(status == 1)
            //    service.Status = ServiceStatus.Active;
            //else
            service.Status = status;

            _context.Entry(service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
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

        // POST: api/Services
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Service>> PostService(Service service)
        {
            _context.Service.Add(service);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetService", new { id = service.Id }, service);
        }

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            var service = await _context.Service.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.Service.Remove(service);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceExists(Guid id)
        {
            return _context.Service.Any(e => e.Id == id);
        }
    }
}
