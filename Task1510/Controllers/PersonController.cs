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
    public class PersonController : ControllerBase
    {
        private readonly AppDBContext _context;

        public PersonController(AppDBContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePerson(PersonDTO personDTO)
        {
            var person = new Person
            {
                Name = personDTO.Name,
                SpecialModelID = personDTO.SpecialModelID,
            };
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }
        [HttpGet]
        public async Task<IActionResult> GetPersonById(int id)
        {
            var person = await _context.Persons.Include(p=>p.SpecialModel).FirstOrDefaultAsync(p=>p.Id == id);  
            if (person == null)
            {
                return NotFound();
            }

            var personDTO = new PersonDTO
            {
                Id = person.Id,
                Name = person.Name,
                SpecialModelID = person.SpecialModelID ?? 0
            };
            return Ok(personDTO);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePerson(int id, PersonDTO personDTO)
        {
            if (id != personDTO.Id)
            {
                return BadRequest();
            }

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            person.Name = personDTO.Name;
            person.SpecialModelID = personDTO.SpecialModelID;

            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
