using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Db;
using WebApplication.Entities;

namespace WebApplication.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogDbContext _context;

        public BlogController(BlogDbContext context)
        {
            _context = context;
        }

        // МЕТОД ДЛЯ СПИСКУ ПОСТІВ
        public async Task<IActionResult> Index(string? category, string? tag, string? searchString, int page = 1)
        {
            int pageSize = 5;

            var postsQuery = _context.Posts
                .Include(p => p.PostCategories).ThenInclude(pc => pc.Category)
                .Include(p => p.PostTags).ThenInclude(pt => pt.Tag)
                .AsQueryable();

            // Фільтр категорій
            if (!string.IsNullOrEmpty(category))
            {
                postsQuery = postsQuery.Where(p => p.PostCategories.Any(pc => pc.Category.Slug == category));
                ViewData["CategoryFilter"] = category;
            }

            // Фільтр тегів (той самий баг, що ти питав)
            if (!string.IsNullOrEmpty(tag))
            {
                postsQuery = postsQuery.Where(p => p.PostTags.Any(pt => pt.Tag.Slug == tag));
                ViewData["TagFilter"] = tag;
            }

            // Пошук
            if (!string.IsNullOrEmpty(searchString))
            {
                postsQuery = postsQuery.Where(p => p.Title.Contains(searchString));
                ViewData["SearchFilter"] = searchString;
            }

            int totalItems = await postsQuery.CountAsync();
            var posts = await postsQuery
                .OrderByDescending(p => p.DateOfCreated)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            return View(posts);
        }

        // --- ОСЬ ВІН, МЕТОД DETAILS ---
        // Викликається, коли ти тиснеш "Читати далі"
        public async Task<IActionResult> Details(string slug)
        {
            if (string.IsNullOrEmpty(slug)) return NotFound();

            var post = await _context.Posts
                .Include(p => p.PostTags).ThenInclude(pt => pt.Tag)
                .Include(p => p.PostCategories).ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync(p => p.Slug == slug);

            if (post == null) return NotFound();

            return View(post);
        }
    }
}