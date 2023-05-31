using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Alcohols
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1Context _context;

        public DeleteModel(WebApplication1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Alcohol Alcohol { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Alcohol = await _context.Alcohol.FirstOrDefaultAsync(m => m.ID == id);

            if (Alcohol == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Alcohol = await _context.Alcohol.FindAsync(id);

            if (Alcohol != null)
            {
                _context.Alcohol.Remove(Alcohol);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
