using Lab10DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab12.Pages.Articles
{
    public class CreateModel : PageModel
    {
        private readonly Lab10DB.Data.MyDbContext _context;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _he;


        public CreateModel(Lab10DB.Data.MyDbContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment he)
        {
            _context = context;
            _he = he;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Article Article { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Article.ImageFile != null && Article.ImageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Article.ImageFile.FileName);
                var filePath = Path.Combine(_he.WebRootPath, "upload", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Article.ImageFile.CopyToAsync(stream);
                }
                Article.ImagePath = fileName;
            }

            _context.Articles.Add(Article);
            await _context.SaveChangesAsync();
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", Article.CategoryId);

            return RedirectToPage("./Index");
        }
    }
}
