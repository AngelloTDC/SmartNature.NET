using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartNature.API.Models;

namespace SmartNature.API.Pages.Sensores
{
    public class CreateModel : PageModel
    {
        private readonly SmartNatureDbContext _context;

        [BindProperty]
        public Sensor Sensor { get; set; } = new();

        public CreateModel(SmartNatureDbContext context)
        {
            _context = context;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Sensores.Add(Sensor);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
