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
  public class CatsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;
    private readonly IUriService uriService;

    public CatsController(AnimalShelterContext db, IUriService uriService)
    {
      this.uriService = uriService;
      _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter, string species, string gender, string name, int age)
    {
      var route = Request.Path.Value;
      var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
      var pagedData = await _db.Cats
        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        .Take(validFilter.PageSize)
        .ToListAsync();
      var totalRecords = await _db.Cats.CountAsync();
      var pagedResponse = PaginationHelper.CreatePagedResponse<Cat>(pagedData, validFilter, totalRecords, uriService, route);

      return Ok(pagedResponse);
    }

     // GET: api/Cats/Query?
    [HttpGet]
    [Route("Query")]
    public async Task<ActionResult<IEnumerable<Cat>>> Get(string species, string gender, string name, int age, int maximumAge)
    {
      var query = _db.Cats.AsQueryable();

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

      if (maximumAge > 0)
      {
        query = query.Where(entry => entry.Age <= maximumAge);
      }

      return await query.ToListAsync();
    }

     //GET: api/Cats/Popular
    [HttpGet]
    [Route("Popular")]
    public async Task<ActionResult<IEnumerable<Cat>>> Popular()
    {
      var query = _db.Cats.AsQueryable();

      var all = _db.Cats.GroupBy(x => x.CatId)
        .Select(group => new {CatId = group.Key, Count = group.Count()})
        .OrderByDescending(x => x.Count);

      var item = all.First();
      int mostfrequent = item.CatId;
      var mostfrequentcount = item.Count;

      query = query.Where(entry => entry.CatId == mostfrequent);
      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var cat = await _db.Cats.Where(a => a.CatId == id).FirstOrDefaultAsync();
      return Ok(new Response<Cat>(cat));
    }


    // PUT: api/Cats/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Cat cat)
    {
      if (id != cat.CatId)
      {
        return BadRequest();
      }

      _db.Entry(cat).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CatExists(id))
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

    // POST: api/Cats
    [HttpPost]
    public async Task<ActionResult<Cat>> Post(Cat cat)
    {
      _db.Cats.Add(cat);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetById), new { id = cat.CatId }, cat);
    }

    // DELETE: api/Cats/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCat(int id)
    {
      var cat = await _db.Cats.FindAsync(id);
      if (cat == null)
      {
        return NotFound();
      }

      _db.Cats.Remove(cat);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool CatExists(int id)
    {
      return _db.Cats.Any(e => e.CatId == id);
    }
  }
  
  [ApiVersion("2.0")]
  [Route("api/{v:apiVersion}/[controller]")]
  [ApiController]
  public class CatsV2Controller : ControllerBase
  {
      private readonly AnimalShelterContext _db;

    public CatsV2Controller(AnimalShelterContext db)
    {
      _db = db;
    }
    //GET: api/Cats/Random
    [HttpGet]
    [Route("Random")]
    public async Task<ActionResult<IEnumerable<Cat>>> Random()
    {
      var query = _db.Cats.AsQueryable();
      Random random = new Random();
      int r = 0;
      while (!query.Any(d => d.CatId == r))
      {
        r = random.Next(1, (query.Count() + 1));
      }
      query = query.Where(entry => entry.CatId == r);
      return await query.ToListAsync();
    }
  }
}