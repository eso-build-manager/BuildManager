using BuildManager.Library.DataBaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace BuildManager.WebApp.Server.API.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class SetListController : ControllerBase
        {
            private readonly BuildManagerContext _context;

            public SetListController(BuildManagerContext context)
            {
                _context = context;
            }

            // GET: api/SetLists
            [HttpGet]
            public async Task<ActionResult<IEnumerable<SetList>>> GetSetList()
            {
                if (_context.SetList == null)
                {
                    return NotFound();
                }
                return await _context.SetList.ToListAsync();
            }

            // GET: api/SetLists/5
            [HttpGet("{id}")]
            public async Task<ActionResult<SetList>> GetSetList(short id)
            {
                if (_context.SetList == null)
                {
                    return NotFound();
                }
                var SetList = await _context.SetList.FindAsync(id);

                if (SetList == null)
                {
                    return NotFound();
                }

                return SetList;
            }

            // PUT: api/SetLists/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IActionResult> PutSetList(short id, SetList SetList)
            {
                if (id != SetList.SetId)
                {
                    return BadRequest();
                }

                _context.Entry(SetList).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SetListExists(id))
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

            // POST: api/SetLists
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            public async Task<ActionResult<SetList>> PostSetList(SetList SetList)
            {
                if (_context.SetList == null)
                {
                    return Problem("Entity set 'AbioContext.SetList'  is null.");
                }
                _context.SetList.Add(SetList);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (SetListExists(SetList.SetId))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }

                return CreatedAtAction("GetSetList", new { id = SetList.SetId }, SetList);
            }

            // DELETE: api/SetLists/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteSetList(short id)
            {
                if (_context.SetList == null)
                {
                    return NotFound();
                }
                var SetList = await _context.SetList.FindAsync(id);
                if (SetList == null)
                {
                    return NotFound();
                }

                _context.SetList.Remove(SetList);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool SetListExists(short id)
            {
                return (_context.SetList?.Any(e => e.SetId == id)).GetValueOrDefault();
            }
        }

    }
