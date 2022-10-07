using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EGroceryyStoreApplication.Data;
using EGroceryyStoreApplication.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cors;

namespace EGroceryyStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class UserAccountModelsController : ControllerBase
    {
        private readonly GroceryDbContext _context;

        public UserAccountModelsController(GroceryDbContext context)
        {
            _context = context;
        }

        // GET: api/UserAccountModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAccountModel>>> GetUserAccount()
        {
            return await _context.UserAccount.ToListAsync();
        }

        // GET: api/UserAccountModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAccountModel>> GetUserAccountModel(int id)
        {
            var userAccountModel = await _context.UserAccount.FindAsync(id);

            if (userAccountModel == null)
            {
                return NotFound();
            }

            return userAccountModel;
        }

        // PUT: api/UserAccountModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAccountModel(int id, UserAccountModel userAccountModel)
        {
            if (id != userAccountModel.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userAccountModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAccountModelExists(id))
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

        // POST: api/UserAccountModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Register")]
      
        public async Task<ActionResult<UserAccountModel>> Register(UserAccountModel userAccountModel)
        {
            _context.UserAccount.Add(userAccountModel);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUserAccountModel", new { id = userAccountModel.UserId }, userAccountModel);
            return Ok("success");
        }


        [HttpPost("Login")]
      
        public async Task<IActionResult> Login([FromBody]LoginModel loginModel)
        {
            var user = await _context.UserAccount.Where(i => i.UserName == loginModel.UserName
              && i.Password == loginModel.Password).Include(i => i.RolesModel).FirstOrDefaultAsync();




            if (user == null)
                throw new Exception("invalid credentials");

            var claims = new List<Claim>
            {
                new Claim(type:ClaimTypes.Name,value: user?.UserName),
                 new Claim(type:ClaimTypes.Role,value: user?.RolesModel?.RoleType)

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));

            return Ok(user);
        }
       
        // DELETE: api/UserAccountModels/5

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserAccountModel>> DeleteUserAccountModel(int id)
        {
            var userAccountModel = await _context.UserAccount.FindAsync(id);
            if (userAccountModel == null)
            {
                return NotFound();
            }

            _context.UserAccount.Remove(userAccountModel);
            await _context.SaveChangesAsync();

            return userAccountModel;
        }

        private bool UserAccountModelExists(int id)
        {
            return _context.UserAccount.Any(e => e.UserId == id);
        }
    }
}
