using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Alcohols
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1Context _context;

        public EditModel(WebApplication1Context context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Alcohol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlcoholExists(Alcohol.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AlcoholExists(int id)
        {
            return _context.Alcohol.Any(e => e.ID == id);
        }
    }
}
