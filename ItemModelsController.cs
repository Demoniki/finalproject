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
    public class ItemModelsController : ControllerBase
    {
        private readonly GroceryDbContext _context;

        public ItemModelsController(GroceryDbContext context)
        {
            _context = context;
        }

        // GET: api/ItemModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemModel>>> GetItemModels()
        {
            return await _context.ItemModels.ToListAsync();
        }

        // GET: api/ItemModels/5
      //  [HttpGet("{ItemName}")]
   /*     public async Task<ActionResult<ItemModel>> GetItemModel(String itemName)
        {
           
           var itemModels=await (from i in _context.ItemModels
                           join g in _context.GroceryTables on 
                           i.GroceryId equals g.GroceryId
                           select new ItemModel
                           {
                               ItemId=i.ItemId,
                               ItemName=i.ItemName,
                               Price=i.Price,
                               GroceryId=i.GroceryId
                           }
                           ).ToListAsync();

           
            return Ok(itemModels);
        }

       */

        // POST: api/ItemModels
        // To protect from o[verposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
       // [Authorize(Roles = "seller")]
        public async Task<ActionResult<ItemModel>> AddItemModel(ItemModel itemModel)
        {
            _context.ItemModels.Add(itemModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemModel", new { id = itemModel.ItemId }, itemModel);
        }

        // DELETE: api/ItemModels/5
        [HttpDelete("{id}")]
        //seller
        public async Task<ActionResult<ItemModel>> DeleteItemModel(int id)
        {
            var itemModel = await _context.ItemModels.FindAsync(id);
            if (itemModel == null)
            {
                return NotFound();
            }

            _context.ItemModels.Remove(itemModel);
            await _context.SaveChangesAsync();

            return itemModel;
        }

        private bool ItemModelExists(int id)
        {
            return _context.ItemModels.Any(e => e.ItemId == id);
        }
    }
}
