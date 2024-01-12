using System.ComponentModel.DataAnnotations;

namespace Lab10DB.Models
{
    public class Category
    {
        public required int Id { get; set; }

        [StringLength(60, MinimumLength = 3, ErrorMessage = "Name should has at least 3 characters and less than 60")]
        public required string Name { get; set; }

        public ICollection<Article>? Articles { get; set; }

    }

    public class CategoryViewModel
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3, ErrorMessage = "Name should have at least 3 characters and less than 60")]
        [Required]
        public string Name { get; set; }
    }
}
