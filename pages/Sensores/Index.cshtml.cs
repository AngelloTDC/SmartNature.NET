using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartNature.API.Models;

namespace SmartNature.API.Pages.Sensores
{
    public class IndexModel : PageModel
    {
        private readonly SmartNatureDbContext _context;
        public List<Sensor> Sensores { get; set; } = new();

        public IndexModel(SmartNatureDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Sensores = await _context.Sensores
                .Include(s => s.Leituras)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var sensor = await _context.Sensores.FindAsync(id);
            if (sensor != null)
            {
                _context.Sensores.Remove(sensor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}

