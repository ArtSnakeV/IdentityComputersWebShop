﻿using ComputersWebShop.Models.DTOs.Products;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComputersWebShop.Models.ViewModels.Products
{
    public class CreateProductVM
    {
        public ProductDTO ProductDTO {get; set;} = default;

        public SelectList? Brands { get; set; }

        public SelectList? Categories { get; set; }
    }
}
