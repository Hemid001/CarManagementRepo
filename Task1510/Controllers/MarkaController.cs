using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1510.Data;
using Task1510.Data.Entity;
using Task1510.DTO;

namespace Task1510.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkaController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MarkaController(AppDBContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreatMarka(MarkaDTO markaDTO)
        {
            var marka = new Marka
            {
                Name = markaDTO.Name,
            };
            _context.Marka.Add(marka);
            await _context.SaveChangesAsync();
            return Ok(marka);
        }
        [HttpGet]
        public async Task<IActionResult> GetMarkaById(int id)
        {
            var marka = await _context.Marka.Include(m => m.SpecialModels).FirstOrDefaultAsync(m => m.Id == id);
            if (marka == null)
            {
                return NotFound();
            }
            var markaDTO = new MarkaDTO
            {
                Id = marka.Id,
                Name = marka.Name,
            };
            return Ok(markaDTO);
        }
        [HttpPut]   
        public async Task<IActionResult> UpdateMarka(int id, MarkaDTO markaDTO)
        {
            if(id!=markaDTO.Id)
            {
                return BadRequest();
            }
            var marka = await _context.Marka.FindAsync(id);
            if (marka == null)
            {
                return NotFound();
            }
            marka.Name = markaDTO.Name;
            await _context.SaveChangesAsync();
            return NoContent ();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMarka(int id)
        {
            var marka = await _context.Marka.FindAsync(id);
            if(marka == null)
            {
                return NotFound();
            }
            _context.Marka.Remove(marka);
            await _context.SaveChangesAsync();
            return NoContent ();
        }
    }
}
