using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchaseOrderMgmtWebApi.DAL;

namespace PurchaseOrderMgmtWebApi.Controllers
{
    [Route("api/purchaseOrders")]
    [ApiController]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PurchaseOrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrder()
        {
            return await _context.PurchaseOrder.ToListAsync();
        }

        // GET: api/PurchaseOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrder>> GetPurchaseOrder(string id)
        {
            var purchaseOrder = await _context.PurchaseOrder.FindAsync(id);

            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return purchaseOrder;
        }

        // PUT: api/PurchaseOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseOrder(string id, PurchaseOrder purchaseOrder)
        {
            if (id != purchaseOrder.Code)
            {
                return BadRequest();
            }

            _context.Entry(purchaseOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseOrderExists(id))
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

        // POST: api/PurchaseOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseOrder>> PostPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            _context.PurchaseOrder.Add(purchaseOrder);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PurchaseOrderExists(purchaseOrder.Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPurchaseOrder", new { id = purchaseOrder.Code }, purchaseOrder);
        }

        // DELETE: api/PurchaseOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseOrder(string id)
        {
            try
            {
                var purchaseOrder = await _context.PurchaseOrder.FindAsync(id);
                if (purchaseOrder == null)
                {
                    return NotFound();
                }

                _context.PurchaseOrder.Remove(purchaseOrder);
                await _context.SaveChangesAsync();  // Use SaveChangesAsync for async operations

                return NoContent();
            }
            catch (DbUpdateException dbEx)
            {
                // Handle database update exceptions (e.g., constraint violations)
                return StatusCode(500, $"Database Update Exception: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                // Handle all other exceptions
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        private bool PurchaseOrderExists(string id)
        {
            return _context.PurchaseOrder.Any(e => e.Code == id);
        }
    }
}
