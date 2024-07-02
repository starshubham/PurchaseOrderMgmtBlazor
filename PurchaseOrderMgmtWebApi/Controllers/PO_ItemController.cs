using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Common.Models;
using PurchaseOrderMgmtWebApi.DAL;

namespace PurchaseOrderMgmtWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PO_ItemController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PO_ItemController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PO_Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PO_Item>>> GetPO_Item()
        {
            return await _context.PO_Item.ToListAsync();
        }

        // GET: api/PO_Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<PO_Item>>> GetPO_Item(string id)
        {
            var pO_Item = await _context.PO_Item.Where(x => x.POCode == id).ToListAsync();

            if (pO_Item == null)
            {
                return NotFound();
            }

            return pO_Item.ToList();
        }

        // PUT: api/PO_Item/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPO_Item(int id, PO_Item pO_Item)
        {
            if (id != pO_Item.Id)
            {
                return BadRequest();
            }

            _context.Entry(pO_Item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PO_ItemExists(id))
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

        // POST: api/PO_Item
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PO_Item>> PostPO_Item(PO_Item pO_Item)
        {
            _context.PO_Item.Add(pO_Item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPO_Item", new { id = pO_Item.Id }, pO_Item);
        }

        // DELETE: api/PO_Item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePO_Item(string id)
        {
            var pO_Items = _context.PO_Item.Where(x => x.POCode == id).ToList();
            if (pO_Items.Count == 0)
            {
                return NotFound();
            }

            foreach (var item in pO_Items) 
            {
                _context.PO_Item.Remove(item);
            }           
            _context.SaveChanges();

            return NoContent();
        }

        private bool PO_ItemExists(int id)
        {
            return _context.PO_Item.Any(e => e.Id == id);
        }
    }
}
