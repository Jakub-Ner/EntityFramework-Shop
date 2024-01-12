using Lab10DB.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lab12.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Lab10DB.Data.MyDbContext _context;

        public IndexModel(Lab10DB.Data.MyDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}
