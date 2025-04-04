using ComputersWebShop.Data;
using ComputersWebShop.Infrastructure.BinderProviders;
using ComputersWebShop.Profiles;
using ComputersWebShop.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
string connStr = builder.Configuration.GetConnectionString("AComputerShopDb") ?? throw new InvalidCastException("Connection string not configured!");
builder.Services.AddDbContext<ShopContext>(options =>
options.UseSqlServer(connStr));
builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new CartModelBinderProvider());
});

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

//builder.Services.AddTransient<IAuthorizationRequirement, MinimalAgeRequirement>();
//builder.Services.AddTransient<IAuthorizationHandler, MinimalAgeAuthorizationHandler>();
builder.Services.AddScoped<IAuthorizationRequirement, MinimalAgeRequirement>();
builder.Services.AddScoped<IAuthorizationHandler, MinimalAgeAuthorizationHandler>();



builder.Services.AddAuthorization(configure =>
{
    configure.AddPolicy("managerPolicy", policyBuilder =>
    {
        //policyBuilder.RequireRole("manager");
        policyBuilder.RequireRole("admin", "manager");
        policyBuilder.RequireClaim("Hobbie", "Fishing");
    });
    // Extra policy, based on requirements
    configure.AddPolicy("hasAppropreateAge", policyBuilder =>
    {
        policyBuilder.RequireRole("manager");
        //policyBuilder.Requirements.Add(new MinimalAgeRequirement { MinimalAge = 18 });
        policyBuilder.Requirements.Add(new MinimalAgeRequirement(minimalAge: 18));
    });
});
builder.Services.AddAutoMapper(typeof(ShopUserProfile), typeof(RoleProfile),
    typeof(BrandProfile), typeof(CategoryProfile), typeof(ProductProfile)); // Registering our profiles for user, roles, brands
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
//app.UseMvc();



app.MapControllerRoute(
     name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();
