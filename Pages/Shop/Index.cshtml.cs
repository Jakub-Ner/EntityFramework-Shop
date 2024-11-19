using Lab10DB.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lab12.Pages.Shops
{
    public class IndexModel : PageModel
    {
        private readonly Lab10DB.Data.MyDbContext _context;

        public IndexModel(Lab10DB.Data.MyDbContext context)
        {
            _context = context;
        }

        public IList<Category> Categories { get; set; } = default!;
        public IList<Article> Articles { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Articles = await _context.Articles
                .Include(a => a.Category).ToListAsync();

            Categories = await _context.Categories.ToListAsync();

            ViewData["SelectedCategory"] = "All";
        }

        public async Task OnPostAsync(int CategoryId)
        {
            Console.WriteLine("CategoryId: " + CategoryId);

            Categories = await _context.Categories.ToListAsync();
            if (CategoryId == -1)
            {
                Articles = await _context.Articles.ToListAsync();
                ViewData["SelectedCategory"] = "All";
            }
            else
            {
                Articles = await _context.Articles.Where(a => a.CategoryId == CategoryId).ToListAsync();
                ViewData["SelectedCategory"] = Categories.FirstOrDefault(c => c.Id == CategoryId).Name;
            }
            Console.WriteLine("SelectedCategory: " + ViewData["SelectedCategory"]);
        }
    }
}
