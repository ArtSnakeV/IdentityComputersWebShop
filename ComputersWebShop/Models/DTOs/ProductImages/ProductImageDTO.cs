using ComputersLibrary;
using ComputersWebShop.Models.DTOs.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputersWebShop.Models.DTOs.ProductImages
{
    public class ProductImageDTO
    {
        public int Id { get; set; }
        [Display(Name = "Photo")]
        public byte[] ImageData { get; set; } = default!;
        [Display(Name = "Product")]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public ProductDTO? Product { get; set; } = default!;

    }
}
