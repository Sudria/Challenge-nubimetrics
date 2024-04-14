using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SudriaGonzalo.Data;
using SudriaGonzalo.Models;

namespace SudriaGonzalo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Desafio3Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Desafio3Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("/[controller]/usuarios")]
        public async Task<IActionResult> Index()
        {
            var content = await _context.Users.ToListAsync();
            if (!content.IsNullOrEmpty())
            {
                return Ok(content);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("/[controller]/usuarios/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return Ok(userModel);
        }


       
        [HttpPost("/[controller]/usuarios")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Email,Password")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userModel);
                await _context.SaveChangesAsync();
                return Created();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut("/[controller]/usuarios/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Email,Password")] UserModel userModel)
        {
            if (id != userModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelExists(userModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }




        [HttpDelete("/[controller]/usuarios/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var userModel = await _context.Users.FindAsync(id);
            if (userModel != null)
            {
                _context.Users.Remove(userModel);
                await _context.SaveChangesAsync();
                return Ok("Eliminado con exito");
            }
            else
            {
                return NotFound();
            }

            
        }

        private bool UserModelExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
