using Microsoft.EntityFrameworkCore;
using MyWebApplication.Entities;
using WebApplication.Db;
using WebApplication.Entities;
using WebApplication.Models;
namespace WebApplication.Db
{
    public class BlogDbContext : DbContext
    {
        public DbSet<ClientMessage> ClientMessages { get; set; }
        public DbSet<Navigate> Navigations { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTags> PostTags { get; set; }
        public DbSet<PostCategories> PostCategories { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
     : base(options)
        {
         
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        
            modelBuilder.Entity<PostTags>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.PostTags) 
                .HasForeignKey(pt => pt.PostId);

            modelBuilder.Entity<PostTags>()
                .HasOne(pt => pt.Tag)
                .WithMany()
                .HasForeignKey(pt => pt.TagId);

    
            modelBuilder.Entity<PostCategories>()
                .HasOne(pc => pc.Post)
                .WithMany(p => p.PostCategories) 
                .HasForeignKey(pc => pc.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}