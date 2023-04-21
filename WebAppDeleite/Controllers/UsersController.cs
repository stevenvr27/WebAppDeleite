using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppDeleite.Attributes;
using WebAppDeleite.Models;
using WebAppDeleite.Tools;

namespace WebAppDeleite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [ApiKey]
    public class UsersController : ControllerBase
    {
        private readonly DeleiteContext _context;

        public Crypto MYCrypto { get; set; }

        public UsersController(DeleiteContext context)
        {
            _context = context;
            MYCrypto = new Tools.Crypto();
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpGet("ValidateUserLogin")]
        public async Task<ActionResult<User>> ValidateUserLogin(string pUserName, string pPassword)
        {
            // encriptalas contraseñas y las valida en Bd 
            string EncriptedPassword = MYCrypto.EncriptarEnUnSentido(pPassword);



            var user = await _context.Users.SingleOrDefaultAsync(e => e.Email == pUserName && e.LoginPassword == EncriptedPassword);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

      
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            string EncriptedPassword = MYCrypto.EncriptarEnUnSentido(user.LoginPassword);

            user.LoginPassword = EncriptedPassword;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
