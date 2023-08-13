using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CryptographyAPI.Data;
using CryptographyAPI.Models;

namespace CryptographyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptEntitiesController : ControllerBase
    {
        private readonly CryptoDbContext _context;

        public CryptEntitiesController(CryptoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CryptEntity>>> GetCryptEntities()
        {
            return await _context.CryptEntities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CryptEntity>> GetCryptEntity(long id)
        {
            var cryptEntity = await _context.CryptEntities.FindAsync(id);

            if (cryptEntity == null)
            {
                return NotFound();
            }

            return cryptEntity;
        }

        [HttpPost]
        public async Task<ActionResult<CryptEntity>> PostCryptEntity(CryptEntity cryptEntity)
        {
            _context.CryptEntities.Add(cryptEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCryptEntity", new { id = cryptEntity.Id }, cryptEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCryptEntity(long id, CryptEntity cryptEntity)
        {
            if (id != cryptEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(cryptEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CryptEntityExists(id))
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
        public async Task<IActionResult> DeleteCryptEntity(long id)
        {
            var cryptEntity = await _context.CryptEntities.FindAsync(id);
            if (cryptEntity == null)
            {
                return NotFound();
            }

            _context.CryptEntities.Remove(cryptEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CryptEntityExists(long id)
        {
            return _context.CryptEntities.Any(e => e.Id == id);
        }
    }
}
