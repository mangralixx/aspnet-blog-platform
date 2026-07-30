using WebApplication.Db;

namespace MyWebApplication.Models
{
    public class PostCategoriesModel
    {
        private readonly BlogDbContext _blogDbContext;

        public PostCategoriesModel(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }
    }
}