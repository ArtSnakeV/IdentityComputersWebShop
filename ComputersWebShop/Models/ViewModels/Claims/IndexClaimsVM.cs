﻿using System.Security.Claims;

namespace ComputersWebShop.Models.ViewModels.Claims
{
    public class IndexClaimsVM
    {
        public IEnumerable<Claim>? Claims { get; set; }

        public string UserName { get; set; } = default!;

        public string Email { get; set; } = default!;
    }
}

