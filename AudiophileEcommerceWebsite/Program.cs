using AudiophileEcommerceWebsite.Entities;
using AudiophileEcommerceWebsite.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString
    ("AudiophileEcommerceWebsite") ?? throw new InvalidOperationException
    ("Connection string 'AudiophileEcommerceWebsite' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<OrderViewModelValidator>());
builder.Services.AddHsts(hstsOpts =>
{
    hstsOpts.IncludeSubDomains = true;
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();    
builder.Services.AddScoped<IShoppingBasket, ShoppingBasket>(sp => new ShoppingBasket(
    sp.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session,
    sp.GetService<AudiophileDbContext>()));

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<AudiophileDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<AudiophileDbContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Product/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

IApplicationBuilder appBuilder = (IApplicationBuilder)app;
DbInitializer.Seed(appBuilder.ApplicationServices.CreateScope().ServiceProvider
            .GetRequiredService<AudiophileDbContext>());

app.Run();
