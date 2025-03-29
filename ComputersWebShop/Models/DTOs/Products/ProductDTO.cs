using ComputersLibrary;
using ComputersWebShop.Models.DTOs.Brands;
using ComputersWebShop.Models.DTOs.Categories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputersWebShop.Models.DTOs.Products
{
    public class ProductDTO
    {
        
        public int Id { get; set; }
        [Display(Name = "Product name")]
        public string ProductName { get; set; } = default!;
        [Display(Name = "Product Description")]
        public string Description { get; set; } = default!;
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Brand Id")]
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        [Display(Name = "Brand")]
        public BrandDTO? Brand { get; set; } = default!;
        [Display(Name = "Category")]
        public CategoryDTO? Category { get; set; } = default!;
        [Display(Name = "Category id")]
        public int CategoryId { get; set; }

        public ICollection<ProductImage>? ProductImages { get; set; } = default!;
    }
}
