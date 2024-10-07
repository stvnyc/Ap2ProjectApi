using Ap2ProjectApi.DAL;
using Ap2ProjectApi.Data.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ap2ProjectApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SistemasController : ControllerBase
{
    private readonly Contexto _context;
    public SistemasController(Contexto context)
    {
        _context = context;
    }
    // GET: api/Sistemas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sistemas>>> GetSistemas()
    {
        return await _context.Sistemas.ToListAsync();
    }
    // GET: api/Sistemas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Sistemas>> GetSistemas(int id)
    {
        var sistemas = await _context.Sistemas.FindAsync(id);
        if (sistemas == null)
        {
            return NotFound();
        }
        return sistemas;
    }
    // PUT: api/Sistemas/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSistemas(int id, Sistemas sistemas)
    {
        if (id != sistemas.SistemasId)
        {
            return BadRequest();
        }
        _context.Entry(sistemas).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SistemasExists(id))
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
    // POST: api/Sistemas
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Sistemas>> PostSistemas(Sistemas sistemas)
    {
        if (sistemas.SistemasId <= 0 || !SistemasExists(sistemas.SistemasId))
        {
            _context.Sistemas.Add(sistemas);
        }
        else
        {
            _context.Sistemas.Update(sistemas);
        }
        await _context.SaveChangesAsync();
        return Ok(sistemas);
    }
    // DELETE: api/Sistemas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSistemas(int id)
    {
        if (!_context.Sistemas.Any())
        {
            return NotFound();
        }
        var sistemas = await _context.Sistemas.FindAsync(id);
        if (sistemas == null)
        {
            return NotFound();
        }
        _context.Sistemas.Remove(sistemas);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    private bool SistemasExists(int id)
    {
        return _context.Sistemas.Any(e => e.SistemasId == id);
    }
}