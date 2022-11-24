using AudiophileEcommerceWebsite.Entities;
using AudiophileEcommerceWebsite.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using static System.Net.Mime.MediaTypeNames;

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

//builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<AudiophileDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddDefaultIdentity<IdentityUser>(/*options => */
    /*options.SignIn.RequireConfirmedAccount = true*/)
    .AddEntityFrameworkStores<AudiophileDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
    app.UseExceptionHandler("/Product/Error");
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();
//}

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
//DbInitializer.Seed(app);

DbInitializer.Seed(appBuilder.ApplicationServices.CreateScope().ServiceProvider
            .GetRequiredService<AudiophileDbContext>());

app.Run();
