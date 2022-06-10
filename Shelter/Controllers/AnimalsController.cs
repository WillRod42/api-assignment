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
  public class AnimalsController : ControllerBase
  {
    private readonly ShelterContext _context;

    public AnimalsController(ShelterContext context)
    {
      _context = context;
    }

		[AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animal>>> Get()
    {
      return await _context.Animals.ToListAsync();
    }

		[AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
      var animal = await _context.Animals.FindAsync(id);

      if (animal == null)
      {
        return NotFound();
      }

      return animal;
    }

		[AllowAnonymous]
    [HttpGet("type/{id}")]
    public ActionResult<List<Animal>> GetAnimalsByType(int id)
    {
      var animals = _context.Animals.AsQueryable();
      
      if (animals == null)
      {
        return NotFound();
      }

      animals = animals.Where(entry => entry.TypeId == id);
      return animals.ToList();
    }

    [HttpPost]
    public async Task<ActionResult<Animal>> Post(Animal animal)
    {
      _context.Animals.Add(animal);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetAnimal", new { id = animal.AnimalId }, animal);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Animal animal)
    {
      if (id != animal.AnimalId)
      {
        return BadRequest();
      }

      _context.Entry(animal).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AnimalExists(id))
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
    public async Task<IActionResult> DeleteAnimal(int id)
    {
      var animal = await _context.Animals.FindAsync(id);
      if (animal == null)
      {
        return NotFound();
      }

      _context.Animals.Remove(animal);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool AnimalExists(int id)
    {
      return _context.Animals.Any(e => e.AnimalId == id);
    }
  }
}
