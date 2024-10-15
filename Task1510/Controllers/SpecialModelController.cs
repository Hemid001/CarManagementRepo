using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1510.Data.Entity;
using Task1510.Data;
using Task1510.DTO;
using Microsoft.EntityFrameworkCore;

namespace Task1510.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialModelController : ControllerBase
    {
        private readonly AppDBContext _context;

        public SpecialModelController(AppDBContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreatModel(SpecialModelDTO specialModelDTO)
        {
            var specialModel = new SpecialModel
            {
                Name = specialModelDTO.Name,
                MarkaID = specialModelDTO.MarkaID,
            };
            _context.SpecialModels.Add(specialModel);
            await _context.SaveChangesAsync();
            return Ok(specialModel);
        }
        [HttpGet]
        public async Task<IActionResult> GetModelById(int id)
        {
            var specialModel = await _context.SpecialModels.Include(sm => sm.Marka).FirstOrDefaultAsync(sm => sm.Id == id); if (specialModel == null)
            {
                return NotFound();
            }
            var secialModelDTO = new SpecialModelDTO
            {
                Id = specialModel.Id,
                Name = specialModel.Name,
            };
            return Ok(secialModelDTO);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateModel(int id, SpecialModelDTO specialModelDTO)
        {
            if (id != specialModelDTO.Id)
            {
                return BadRequest();
            }
            var specialModel = await _context.SpecialModels.FindAsync(id);
            if (specialModel == null)
            {
                return NotFound();
            }
            specialModel.Name = specialModelDTO.Name;
            specialModel.MarkaID = specialModelDTO.MarkaID;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteModel(int id)
        {
            var specilModel = await _context.SpecialModels.FindAsync(id);
            if (specilModel == null)
            {
                return NotFound();
            }
            _context.SpecialModels.Remove(specilModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
