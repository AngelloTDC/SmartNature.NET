using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartNature.API.Models;

namespace SmartNature.API.Pages.Leituras
{
    public class IndexModel : PageModel
    {
        private readonly SmartNatureDbContext _context;

        public List<Leitura> Leituras { get; set; } = new();

        public IndexModel(SmartNatureDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Leituras = await _context.Leituras
                .Include(l => l.Sensor)
                .OrderByDescending(l => l.DataHora)
                .ToListAsync();
        }
    }
}
