using System.ComponentModel.DataAnnotations.Schema;
using WebApplication.Entities;

namespace MyWebApplication.Entities
{
    public class PostCategories // Переконайтеся, що в Post.cs вказано саме це ім'я
    {
        public int Id { get; set; }
        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}