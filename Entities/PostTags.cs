using System.ComponentModel.DataAnnotations.Schema;
using WebApplication.Entities;

namespace MyWebApplication.Entities
{
    public class PostTags
    {
        public int Id { get; set; }

        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        public int TagId { get; set; }
        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; } // Додано цю властивість, щоб працював .ThenInclude(pt => pt.Tag)
    }
}