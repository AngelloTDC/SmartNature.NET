using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartNature.API.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartNature.API.Pages.Sensores
{
    public class EditModel : PageModel
    {
        private readonly SmartNatureDbContext _context;

        public EditModel(SmartNatureDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sensor Sensor { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Verifica se o sensor existe pelo ID vindo da URL
            Sensor = await _context.Sensores
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (Sensor == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            // Busca original do banco para atualizar apenas os campos permitidos
            var sensorExistente = await _context.Sensores.FindAsync(Sensor.Id);
            if (sensorExistente == null)
            {
                return NotFound();
            }

            sensorExistente.Nome = Sensor.Nome;
            sensorExistente.Localizacao = Sensor.Localizacao;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
