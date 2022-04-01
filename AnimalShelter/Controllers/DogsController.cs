using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;
using AnimalShelter.Wrappers;
using AnimalShelter.Filter;
using AnimalShelter.Helpers;
using AnimalShelter.Services;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DogsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;
    private readonly IUriService uriService; 

    public DogsController(AnimalShelterContext db, IUriService uriService)
    {
      this.uriService = uriService;
      _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
    {
      var route = Request.Path.Value;
      var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
      var pagedData = await _db.Dogs
        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        .Take(validFilter.PageSize)
        .ToListAsync();
      var totalRecords = await _db.Dogs.CountAsync();
      var pagedResponse = PaginationHelper.CreatePagedResponse<Dog>(pagedData, validFilter, totalRecords, uriService, route);
      return Ok(pagedResponse);
    }

    // GET: api/Cats/Query?
    [HttpGet]
    [Route("Query")]
    public async Task<ActionResult<IEnumerable<Dog>>> Get(string species, string gender, string name, int age)
    {
      var query = _db.Dogs.AsQueryable();

      if (species != null)
      {
        query = query.Where(entry => entry.Species == species);
      }

      if (gender != null)
      {
        query = query.Where(entry => entry.Gender == gender);
      }    

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }    

      if (age != 0)
      {
        query = query.Where(entry => entry.Age == age);
      }  

      return await query.ToListAsync();
    }

     //GET: api/Dogs/Popular
    [HttpGet]
    [Route("Popular")]
    public async Task<ActionResult<IEnumerable<Dog>>> Popular()
    {
      var query = _db.Dogs.AsQueryable();

      var all = _db.Dogs.GroupBy(x => x.DogId)
        .Select(group => new {DogId = group.Key, Count = group.Count()})
        .OrderByDescending(x => x.Count);

      var item = all.First();
      int mostfrequent = item.DogId;
      var mostfrequentcount = item.Count;

      query = query.Where(entry => entry.DogId == mostfrequent);
      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var dog = await _db.Dogs.Where(a => a.DogId == id).FirstOrDefaultAsync();
      return Ok(new Response<Dog>(dog));
    }


    // PUT: api/Dogs/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Dog dog)
    {
      if (id != dog.DogId)
      {
        return BadRequest();
      }

      _db.Entry(dog).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DogExists(id))
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

    // POST: api/Dogs
    [HttpPost]
    public async Task<ActionResult<Dog>> Post(Dog dog)
    {
      _db.Dogs.Add(dog);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetById), new { id = dog.DogId }, dog);
    }

    // DELETE: api/Dogs/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDog(int id)
    {
      var dog = await _db.Dogs.FindAsync(id);
      if (dog == null)
      {
        return NotFound();
      }

      _db.Dogs.Remove(dog);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool DogExists(int id)
    {
      return _db.Dogs.Any(e => e.DogId == id);
    }
  }
}