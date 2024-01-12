using Lab10DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab10DB.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Category>()
                        .HasMany(c => c.Articles)
                        .WithOne(a => a.Category)
                        .HasForeignKey(a => a.CategoryId)
                        .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Articles)
                .WithOne(a => a.Category)
                .IsRequired(false);


            //modelBuilder.Seed();
        }

    }
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            Category[] categories =
            [
                new Category
                {
                    Id = 1,
                    Name = "Toy"
                },
                new Category
                {
                    Id = 2,
                    Name = "Shoes"
                },
                new Category
                {
                    Id = 3,
                    Name = "Clothes"
                },
                new Category
                {
                    Id = 4,
                    Name = "Food"
                },
                new Category
                {
                    Id = 5,
                    Name = "Drink"
                },
                new Category
                {
                    Id = 6,
                    Name = "Other"
                }
            ];

            modelBuilder.Entity<Category>().HasData(categories);

            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    Id = 1,
                    Name = "car",
                    CategoryId = 1,
                    Price = 100
                },
                new Article
                {
                    Id = 2,
                    Name = "nike",
                    CategoryId = 1,
                    Price = 200
                },
                new Article
                {
                    Id = 3,
                    Name = "plane T-Shirt",
                    CategoryId = 2,
                    Price = 300
                },
                new Article
                {
                    Id = 4,
                    Name = "Burger",
                    CategoryId = 3,
                    Price = 400
                },
                new Article
                {
                    Id = 5,
                    Name = "Coffee",
                    CategoryId = 4,
                    Price = 500
                },
                new Article
                {
                    Id = 6,
                    Name = "Knife",
                    CategoryId = 5,
                    Price = 600
                }
            );
        }
    }
}