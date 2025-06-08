using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartNature.API.Models;

namespace SmartNature.API.Pages.Alertas
{
    public class IndexModel : PageModel
    {
        private readonly SmartNatureDbContext _context;

        public IndexModel(SmartNatureDbContext context)
        {
            _context = context;
        }

        public List<Leitura> LeiturasComAlerta { get; set; } = new();

        public async Task OnGetAsync()
        {
            LeiturasComAlerta = await _context.Leituras
                .Include(l => l.Sensor)
                .OrderByDescending(l => l.DataHora)
                .Take(20)
                .ToListAsync();
        }

        public string ObterSeveridade(Leitura l)
        {
            if (l.Temperatura >= 45 || l.Fumaca >= 60 || l.Umidade <= 20)
                return "ALTA";

            if (l.Temperatura >= 40 || l.Fumaca >= 40 || l.Umidade <= 30)
                return "MÉDIA";

            return "BAIXA";
        }
    }
}
