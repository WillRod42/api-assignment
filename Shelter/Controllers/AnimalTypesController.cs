using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Shelter.Models;

namespace Shelter.Controllers
{
	[Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalTypesController : ControllerBase
  {
    private readonly ShelterContext _context;

    public AnimalTypesController(ShelterContext context)
    {
      _context = context;
    }

		[AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AnimalType>>> Get()
    {
      return await _context.Types.ToListAsync();
    }

		[AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<AnimalType>> GetAnimalType(int id)
    {
      var animalType = await _context.Types.FindAsync(id);

      if (animalType == null)
      {
        return NotFound();
      }

      return animalType;
    }

    [HttpPost]
    public async Task<ActionResult<AnimalType>> Post(AnimalType animalType)
    {
      _context.Types.Add(animalType);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetAnimalType", new { id = animalType.AnimalTypeId }, animalType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, AnimalType type)
    {
      if (id != type.AnimalTypeId)
      {
        return BadRequest();
      }

      _context.Entry(type).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AnimalTypeExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimalType(int id)
    {
      var animalType = await _context.Types.FindAsync(id);
      if (animalType == null)
      {
        return NotFound();
      }

      _context.Types.Remove(animalType);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool AnimalTypeExists(int id)
    {
      return _context.Types.Any(e => e.AnimalTypeId == id);
    }
  }
}
