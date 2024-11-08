
using Allatmenhely_API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


[Route("api/[controller]")]
[ApiController]
public class OrokbefogadasoksController : ControllerBase
{
    private readonly AnimalContext _context;

    public OrokbefogadasoksController(AnimalContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Orokbefogadasok>>> GetOrokbefogadasoks()
    {
        return await _context.Orokbefogadasoks.ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Orokbefogadasok>> GetOrokbefogadasok(int id)
    {
        var orokbefogadasok = await _context.Orokbefogadasoks.FindAsync(id);

        if (orokbefogadasok == null)
        {
            return NotFound();
        }

        return orokbefogadasok;
    }


    [HttpPost]
    public async Task<ActionResult<Orokbefogadasok>> PostOrokbefogadasok(Orokbefogadasok orokbefogadasok)
    {
        _context.Orokbefogadasoks.Add(orokbefogadasok);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOrokbefogadasok), new { id = orokbefogadasok.Id }, orokbefogadasok);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrokbefogadasok(int id, Orokbefogadasok orokbefogadasok)
    {
        if (id != orokbefogadasok.Id)
        {
            return BadRequest();
        }

        _context.Entry(orokbefogadasok).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Orokbefogadasoks.Any(e => e.Id == id))
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
    public async Task<IActionResult> DeleteOrokbefogadasok(int id)
    {
        var orokbefogadasok = await _context.Orokbefogadasoks.FindAsync(id);
        if (orokbefogadasok == null)
        {
            return NotFound();
        }

        _context.Orokbefogadasoks.Remove(orokbefogadasok);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}