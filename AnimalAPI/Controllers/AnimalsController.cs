using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalAPI.Models;
using System.Linq;
using System;

namespace AnimalAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private readonly AnimalAPIContext _db;

    public AnimalsController(AnimalAPIContext db)
    {
      _db = db;
    }

    // GET: api/Animals
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animal>>> Get(string Family, string Age, string Breed, string Sex, string Admission)
    {
      var query = _db.Animals.AsQueryable();

      if (Family != null)
      {
        query = query.Where(entry => entry.Family == Family);
      }

      if (Age != null)
      {
        query = query.Where(entry => entry.Age == Age);
      }

      if (Breed != null)
      {
        query = query.Where(entry => entry.Breed == Breed);
      }

      if (Sex != null)
      {
        query = query.Where(entry => entry.Sex == Sex);
      }

      if (Admission != null)
      {
        query = query.Where(entry => entry.Admission == Admission);
      }

      return await query.OrderByDescending(entry => entry.Breed).ToListAsync();
    }
    
    // POST api/Animals
    [HttpPost]
    public async Task<ActionResult<Animal>> Post(Animal Animal)
    {
      _db.Animals.Add(Animal);
      await _db.SaveChangesAsync();

     return CreatedAtAction(nameof(GetAnimal), new { id = Animal.AnimalId }, Animal);
    }

    //GET api/Animals/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
        var Animal = await _db.Animals.FindAsync(id);

        if (Animal == null)
        {
            return NotFound();
        }

        return Animal;
    }

     //GET api/Animals/random
    [HttpGet("random")]
    public async Task<ActionResult<Animal>> GetAnimal(string random)
    {
        int count = _db.Animals.Count();
        Random rng = new Random();
        int id = rng.Next(1, count);
        var Animal = await _db.Animals.FindAsync(id);
        return Animal;
    }
    
    // PUT: api/Animals/user
    [HttpPut("{id}/{userName}")]
    public async Task<IActionResult> Put(int id, Animal Animal, string userName)
    {
      if (id != Animal.AnimalId || userName != Animal.UserName)
      {
        return BadRequest();
      }

      _db.Entry(Animal).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
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
     private bool AnimalExists(int id)
    {
      return _db.Animals.Any(e => e.AnimalId == id);
    }

    // DELETE: api/Animals/5
    [HttpDelete("{id}/{userName}")]
    public async Task<IActionResult> DeleteAnimal(int id, string userName)
    {
      var Animal = await _db.Animals.FindAsync(id);

      if(userName != Animal.UserName)
      {
        return BadRequest();
      } else {
      
      if (Animal == null)
      {
        return NotFound();
      }

      _db.Animals.Remove(Animal);
      await _db.SaveChangesAsync();

      return NoContent();
      }
    }
  }
}