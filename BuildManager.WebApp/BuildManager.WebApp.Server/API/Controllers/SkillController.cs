using BuildManager.Library.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace BuildManager.WebApp.Server.API.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class SkillController : ControllerBase
        {
            private readonly BuildManagerContext _context;

            public SkillController(BuildManagerContext context)
            {
                _context = context;
            }

            // GET: api/Skills
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Skill>>> GetAllSkills()
            {
                if (_context.Skill == null)
                {
                    return NotFound();
                }
                return await _context.Skill.ToListAsync();
            }

            // GET: api/Skills/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Skill>> GetSkill(int id)
            {
                if (_context.Skill == null)
                {
                    return NotFound();
                }
                var Skill = await _context.Skill.FindAsync(id);

                if (Skill == null)
                {
                    return NotFound();
                }

                return Skill;
            }

            // PUT: api/Skills/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IActionResult> PutSkill(int id, Skill Skill)
            {
                if (id != Skill.SkillId)
                {
                    return BadRequest();
                }

                _context.Entry(Skill).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillExists(id))
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

            // POST: api/Skills
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            public async Task<ActionResult<Skill>> PostSkill(Skill Skill)
            {
                if (_context.Skill == null)
                {
                    return Problem("Entity set 'AbioContext.Skill'  is null.");
                }
                _context.Skill.Add(Skill);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (SkillExists(Skill.SkillId))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }

                return CreatedAtAction("GetSkill", new { id = Skill.SkillId }, Skill);
            }

            // DELETE: api/Skills/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteSkill(int id)
            {
                if (_context.Skill == null)
                {
                    return NotFound();
                }
                var Skill = await _context.Skill.FindAsync(id);
                if (Skill == null)
                {
                    return NotFound();
                }

                _context.Skill.Remove(Skill);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool SkillExists(int id)
            {
                return (_context.Skill?.Any(e => e.SkillId == id)).GetValueOrDefault();
            }
        }

    }
