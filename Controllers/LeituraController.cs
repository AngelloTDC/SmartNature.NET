using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartNature.API.Models;

namespace SmartNature.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeituraController : ControllerBase
    {
        private readonly SmartNatureDbContext _context;

        public LeituraController(SmartNatureDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var leituras = await _context.Leituras
                .Include(l => l.Sensor)
                .ToListAsync();

            return Ok(leituras);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var leitura = await _context.Leituras
                .Include(l => l.Sensor)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (leitura == null) return NotFound();

            return Ok(leitura);
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LeituraRequest request)
        {
            var sensor = await _context.Sensores.FindAsync(request.SensorId);
            if (sensor == null)
                return BadRequest("Sensor não encontrado.");

            var leitura = new Leitura
            {
                Temperatura = request.Temperatura,
                Umidade = request.Umidade,
                Fumaca = request.Fumaca,
                DataHora = request.DataHora,
                SensorId = request.SensorId,
                Sensor = sensor
            };

            _context.Leituras.Add(leitura);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = leitura.Id }, leitura);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var leitura = await _context.Leituras.FindAsync(id);
            if (leitura == null) return NotFound();

            _context.Leituras.Remove(leitura);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
