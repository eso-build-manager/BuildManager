using BuildManager.Library.DataBaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace BuildManager.WebApp.Server.API.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class SetUsableItemSlotsController : ControllerBase
        {
            private readonly BuildManagerContext _context;

            public SetUsableItemSlotsController(BuildManagerContext context)
            {
                _context = context;
            }

            // GET: api/SetUsableItemSlotss
            [HttpGet]
            public async Task<ActionResult<IEnumerable<SetUsableItemSlots>>> GetSetUsableItemSlotControllerList()
            {
                if (_context.SetUsableItemSlots == null)
                {
                    return NotFound();
                }
                return await _context.SetUsableItemSlots.ToListAsync();
            }

            // GET: api/SetUsableItemSlotss/5
            [HttpGet("{id}")]
            public async Task<ActionResult<SetUsableItemSlots>> GetSetUsableItemSlots(int id)
            {
                if (_context.SetUsableItemSlots == null)
                {
                    return NotFound();
                }
                var SetUsableItemSlots = await _context.SetUsableItemSlots.FindAsync(id);

                if (SetUsableItemSlots == null)
                {
                    return NotFound();
                }

                return SetUsableItemSlots;
            }

            // PUT: api/SetUsableItemSlotss/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IActionResult> PutSetUsableItemSlots(int id, SetUsableItemSlots SetUsableItemSlots)
            {
                if (id != SetUsableItemSlots.SetUsableItemSlotId)
                {
                    return BadRequest();
                }

                _context.Entry(SetUsableItemSlots).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SetUsableItemSlotsExists(id))
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

            // POST: api/SetUsableItemSlotss
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            public async Task<ActionResult<SetUsableItemSlots>> PostSetUsableItemSlots(SetUsableItemSlots SetUsableItemSlots)
            {
                if (_context.SetUsableItemSlots == null)
                {
                    return Problem("Entity set 'AbioContext.SetUsableItemSlots'  is null.");
                }
                _context.SetUsableItemSlots.Add(SetUsableItemSlots);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (SetUsableItemSlotsExists(SetUsableItemSlots.SetUsableItemSlotId))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }

                return CreatedAtAction("GetSetUsableItemSlots", new { id = SetUsableItemSlots.SetUsableItemSlotId }, SetUsableItemSlots);
            }

            // DELETE: api/SetUsableItemSlotss/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteSetUsableItemSlots(int id)
            {
                if (_context.SetUsableItemSlots == null)
                {
                    return NotFound();
                }
                var SetUsableItemSlots = await _context.SetUsableItemSlots.FindAsync(id);
                if (SetUsableItemSlots == null)
                {
                    return NotFound();
                }

                _context.SetUsableItemSlots.Remove(SetUsableItemSlots);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool SetUsableItemSlotsExists(int id)
            {
                return (_context.SetUsableItemSlots?.Any(e => e.SetUsableItemSlotId == id)).GetValueOrDefault();
            }
        }

    }
