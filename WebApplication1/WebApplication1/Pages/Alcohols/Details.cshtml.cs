using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Alcohols
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1Context _context;

        public DetailsModel(WebApplication1Context context)
        {
            _context = context;
        }

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
    }
}
