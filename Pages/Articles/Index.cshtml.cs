using Lab10DB.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lab12.Pages.Articles
{
    public class IndexModel : PageModel
    {
        private readonly Lab10DB.Data.MyDbContext _context;

        public IndexModel(Lab10DB.Data.MyDbContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Article = await _context.Articles
                .Include(a => a.Category).ToListAsync();
        }
    }
}
