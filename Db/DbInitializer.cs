using Microsoft.EntityFrameworkCore;
using WebApplication.Entities;
using MyWebApplication.Entities;
using WebApplication.Db;

namespace MyWebApplication.Db
{
    public class DbInitializer
    {
        public static void Initialize(BlogDbContext context)
        {
           
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            SeedOptions(context);
            SeedNavigates(context);
            SeedTags(context);
            SeedCategories(context);
            SeedPosts(context);
            SeedPostTags(context);
            SeedPostCategories(context);
            SeedClientMessages(context);
        }

        private static void SeedTags(BlogDbContext context)
        {
            if (!context.Tags.Any())
            {
                // У методі SeedTags
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Tags ON"); // Дозволяємо ручні ID
                    context.Tags.Add(new Tag { Id = 1, Title = "DotNet", Slug = "dotnet" });
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Tags OFF"); // Вимикаємо
                }
                finally { context.Database.CloseConnection(); }
            }
        }

        private static void SeedCategories(BlogDbContext context)
        {
            if (context.Categories.Any()) return;

            var categories = new List<Category>
    {
        new Category { Name = "Культура", Slug = "culture" },
        new Category { Name = "Бізнес", Slug = "business" },
        new Category { Name = "Спорт", Slug = "sport" },
        new Category { Name = "Технології", Slug = "tech" } // Слаг тут "tech"
    };

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void SeedPosts(BlogDbContext context)
        {
            if (context.Posts.Any()) return;

            // ВИПРАВЛЕНО: Слаг має збігатися з тим, що в SeedCategories ("tech", а не "it-tech")
            var catIT = context.Categories.FirstOrDefault(c => c.Slug == "tech");
            var catBiz = context.Categories.FirstOrDefault(c => c.Slug == "business");

            if (catIT != null && catBiz != null)
            {
                context.Posts.AddRange(
                    new Post
                    {
                        Title = "Майбутнє .NET у 2026 році",
                        Slug = "future-dotnet",
                        CategoryId = catIT.Id,
                        Status = PostStatuses.Published,
                        Content = "Зміст про технології...",
                        DateOfCreated = DateTime.Now
                    },
                    new Post
                    {
                        Title = "Як почати бізнес",
                        Slug = "start-business",
                        CategoryId = catBiz.Id,
                        Status = PostStatuses.Published,
                        Content = "Зміст про бізнес...",
                        DateOfCreated = DateTime.Now
                    }
                );
                context.SaveChanges();
            }
        }

        private static void SeedClientMessages(BlogDbContext context)
        {
            if (!context.ClientMessages.Any())
            {
                // Виправлено помилки CS0117 та CS0103 (image_e182be.png)
                context.ClientMessages.Add(new ClientMessage
                {
                    UserName = "Олександр",
                    UserEmail = "alex@test.com",
                    Subject = "Питання по блогу",
                    Message = "Дуже цікавий контент, дякую вам!",
                    DateofCreated = DateTime.Now, // Маленька 'o', як у вашому класі
                    Status = MessageStatus.New     // Використовуємо правильний enum MessageStatus
                });
                context.SaveChanges();
            }
        }

        private static void SeedNavigates(BlogDbContext context)
        {
            if (!context.Navigations.Any())
            {
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Navigations ON");
                    context.Navigations.Add(new Navigate { Id = 1, Title = "Головна", Href = "/", Order = 1 });
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Navigations OFF");
                }
                finally { context.Database.CloseConnection(); }
            }
        }

        private static void SeedOptions(BlogDbContext context)
        {
            if (!context.Options.Any())
            {
                context.Options.Add(new Option { Name = "SiteName", Value = "Мій Блог", IsSystem = true });
                context.SaveChanges();
            }
        }

        private static void SeedPostTags(BlogDbContext context)
        {
            if (!context.PostTags.Any())
            {
                var post = context.Posts.FirstOrDefault();
                var tag = context.Tags.FirstOrDefault();
                if (post != null && tag != null)
                {
                    context.PostTags.Add(new MyWebApplication.Entities.PostTags { PostId = post.Id, TagId = tag.Id });
                    context.SaveChanges();
                }
            }
        }

        private static void SeedPostCategories(BlogDbContext context)
        {
            if (!context.PostCategories.Any())
            {
                var post = context.Posts.FirstOrDefault();
                var cat = context.Categories.FirstOrDefault();
                if (post != null && cat != null)
                {
                    context.PostCategories.Add(new MyWebApplication.Entities.PostCategories { PostId = post.Id, CategoryId = cat.Id });
                    context.SaveChanges();
                }
            }
        }
    }
}