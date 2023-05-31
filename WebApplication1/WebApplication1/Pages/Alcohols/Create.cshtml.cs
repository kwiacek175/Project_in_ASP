using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Pages.Alcohols
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication1Context _context;

        [BindProperty]
        public Alcohol Alcohol { get; set; }

        public CreateModel(WebApplication1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Alcohol.Add(Alcohol);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
