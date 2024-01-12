using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab10DB.Models
{
    public class Article
    {
        [Required]
        public required int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Name should has at least 3 characters and less than 60")]
        public required string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int Price { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string? ImagePath { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }

    public class ArticleViewModel
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3, ErrorMessage = "Name should have at least 3 characters and less than 60")]
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number.")]
        [Required]
        public int Price { get; set; }

        public IFormFile? ImageFile { get; set; }
        public string? ImagePath { get; set; }

        public int? CategoryId { get; set; }
    }
}
