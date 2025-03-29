using ComputersLibrary;
using System.ComponentModel.DataAnnotations;

namespace ComputersWebShop.Models.DTOs.Brands
{
    public class BrandDTO
    {
        public int Id { get; set; }

        [Display(Name = "Brand name")]
        public string BrandName { get; set; } = default!;

        [Display(Name = "Country of brand registration")]
        public string Country { get; set; } = default!;

        //public ICollection<Product> Products { get; set; } = default!;
    }
}


