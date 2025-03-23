using ComputersWebShop.Data;
using ComputersWebShop.Profiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
string connStr = builder.Configuration.GetConnectionString("AComputerShopDb") ?? throw new InvalidCastException("Connection string not configured!");

builder.Services.AddDbContext<ShopContext>(options => options.UseSqlServer(connStr));
builder.Services.AddIdentity<ShopUser, IdentityRole>(
    options =>
    {
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
    })
    .AddEntityFrameworkStores<ShopContext>();

builder.Services.AddAutoMapper(typeof(ShopUserProfile)); // Registering one profile for user

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
//app.UseMvc();



app.MapControllerRoute(
     name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();

