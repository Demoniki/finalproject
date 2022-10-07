using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EGroceryyStoreApplication.Data;
using EGroceryyStoreApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace EGroceryyStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryTablesController : ControllerBase
    {
        private readonly GroceryDbContext _context;

        public GroceryTablesController(GroceryDbContext context)
        {
            _context = context;
        }

        // GET: api/GroceryTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroceryTable>>> GetGroceryTables()
        {
            return await _context.GroceryTables.ToListAsync();
        }

        // GET: api/GroceryTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroceryTable>> GetGroceryTable(int id)
        {
            var groceryTable = await _context.GroceryTables.FindAsync(id);

            if (groceryTable == null)
            {
                return NotFound();
            }

            return groceryTable;
        }

        // PUT: api/GroceryTables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroceryTable(int id, GroceryTable groceryTable)
        {
            if (id != groceryTable.GroceryId)
            {
                return BadRequest();
            }

            _context.Entry(groceryTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryTableExists(id))
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

        // POST: api/GroceryTables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
       [HttpPost]
       [Authorize(Roles = "Seller")]
       [Route("GroceryAdd")]
        public async Task<ActionResult<GroceryTable>> GroceryAdd(GroceryTable groceryTable)
        {
            _context.GroceryTables.Add(groceryTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroceryTable", new { id = groceryTable.GroceryId }, groceryTable);
        }

        // DELETE: api/GroceryTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroceryTable>> DeleteGroceryTable(int id)
        {
            var groceryTable = await _context.GroceryTables.FindAsync(id);
            if (groceryTable == null)
            {
                return NotFound();
            }

            _context.GroceryTables.Remove(groceryTable);
            await _context.SaveChangesAsync();

            return groceryTable;
        }

        private bool GroceryTableExists(int id)
        {
            return _context.GroceryTables.Any(e => e.GroceryId == id);
        }
    }
}
