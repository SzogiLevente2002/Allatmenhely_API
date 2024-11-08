
using Allatmenhely_API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


[Route("api/[controller]")]
[ApiController]
public class AllatoksController : ControllerBase
{
    private readonly AnimalContext _context;

    public AllatoksController(AnimalContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Allatok>>> GetAllatoks()
    {
        return await _context.Allatoks
                             .Include(o => o.Gondozok)
                             .Include(o => o.Orokbefogadasok)
                             .ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Allatok>> GetAllatok(int id)
    {
        var allatok = await _context.Allatoks
                                   .Include(o => o.Gondozok)
                                   .Include(o => o.Orokbefogadasok)
                                   .FirstOrDefaultAsync(o => o.Id == id);

        if (allatok == null)
        {
            return NotFound();
        }

        return allatok;
    }


    [HttpPost]
    public async Task<ActionResult<Allatok>> PostAllatok(Allatok allatok)
    {
        _context.Allatoks.Add(allatok);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAllatok), new { id = allatok.Id }, allatok);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutAllatok(int id, Allatok allatok)
    {
        if (id != allatok.Id)
        {
            return BadRequest();
        }

        _context.Entry(allatok).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Allatoks.Any(e => e.Id == id))
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
    public async Task<IActionResult> DeleteAllatok(int id)
    {
        var allatok = await _context.Allatoks.FindAsync(id);
        if (allatok == null)
        {
            return NotFound();
        }

        _context.Allatoks.Remove(allatok);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}