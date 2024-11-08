using Allatmenhely_API.Entities;
using Castle.Core.Resource;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class GondozoksController : ControllerBase
{
    private readonly AnimalContext _context;

    public GondozoksController(AnimalContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Gondozok>>> GetGondozoks()
    {
        return await _context.Gondozoks.ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Gondozok>> GetGondozok(int id)
    {
        var gondozok = await _context.Gondozoks.FindAsync(id);

        if (gondozok == null)
        {
            return NotFound();
        }

        return gondozok;
    }


    [HttpPost]
    public async Task<ActionResult<Gondozok>> PostGondozok(Gondozok gondozok)
    {
        _context.Gondozoks.Add(gondozok);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetGondozok), new { id = gondozok.Id }, gondozok);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutGondozok(int id, Gondozok gondozok)
    {
        if (id != gondozok.Id)
        {
            return BadRequest();
        }

        _context.Entry(gondozok).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Gondozoks.Any(e => e.Id == id))
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
    public async Task<IActionResult> DeleteGondozok(int id)
    {
        var gondozok = await _context.Gondozoks.FindAsync(id);
        if (gondozok == null)
        {
            return NotFound();
        }

        _context.Gondozoks.Remove(gondozok);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
