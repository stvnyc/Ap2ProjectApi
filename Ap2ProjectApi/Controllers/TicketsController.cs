﻿using Ap2ProjectApi.DAL;
using Ap2ProjectApi.Data.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ap2ProjectApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketsController : ControllerBase
{
    private readonly Contexto _context;
    public TicketsController(Contexto context)
    {
        _context = context;
    }
    // GET: api/Tickets
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tickets>>> GetTickets()
    {
        return await _context.Tickets.ToListAsync();
    }
    // GET: api/Tickets/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Tickets>> GetTickets(int id)
    {
        var tickets = await _context.Tickets.FindAsync(id);
        if (tickets == null)
        {
            return NotFound();
        }
        return tickets;
    }
    // PUT: api/Tickets/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTickets(int id, Tickets tickets)
    {
        if (id != tickets.TicketId)
        {
            return BadRequest();
        }
        _context.Entry(tickets).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TicketsExists(id))
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
    // POST: api/Tickets
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Tickets>> PostTickets(Tickets tickets)
    {
        if (tickets.TicketId <= 0 || !TicketsExists(tickets.TicketId))
        {
            _context.Tickets.Add(tickets);
        }
        else
        {
            _context.Tickets.Update(tickets);
        }
        await _context.SaveChangesAsync();
        return Ok(tickets);
    }
    // DELETE: api/Tickets/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTickets(int id)
    {
        if (!_context.Tickets.Any())
        {
            return NotFound();
        }
        var tickets = await _context.Tickets.FindAsync(id);
        if (tickets == null)
        {
            return NotFound();
        }
        _context.Tickets.Remove(tickets);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    private bool TicketsExists(int id)
    {
        return _context.Tickets.Any(e => e.TicketId == id);
    }
}