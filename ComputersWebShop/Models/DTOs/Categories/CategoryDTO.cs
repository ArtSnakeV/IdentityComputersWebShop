using ComputersLibrary;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ComputersWebShop.Models.DTOs.Categories
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Display(Name = "Category name")]
        public string CategoryName { get; set; } = default!;
        [Display(Name = "Parent category")]
        public int? ParentCategoryId { get; set; }

        //[ForeignKey(nameof(ParentCategoryId))]
        public CategoryDTO? ParentCategory { get; set; }

        public ICollection<CategoryDTO>? ChildCategories { get; set; } = default!;

        public ICollection<Product>? Products { get; set; } = default!;

    }
}
