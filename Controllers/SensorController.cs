using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartNature.API.Models;

namespace SmartNature.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly SmartNatureDbContext _context;

        public SensorController(SmartNatureDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sensores = await _context.Sensores.ToListAsync();
            return Ok(sensores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sensor = await _context.Sensores.FindAsync(id);
            if (sensor == null) return NotFound();
            return Ok(sensor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Sensor sensor)
        {
            _context.Sensores.Add(sensor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = sensor.Id }, sensor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Sensor sensor)
        {
            if (id != sensor.Id) return BadRequest();
            _context.Entry(sensor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sensor = await _context.Sensores.FindAsync(id);
            if (sensor == null) return NotFound();

            _context.Sensores.Remove(sensor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
