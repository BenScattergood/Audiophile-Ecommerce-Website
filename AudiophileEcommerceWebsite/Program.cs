using AudiophileEcommerceWebsite.Entities;
using AudiophileEcommerceWebsite.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString
    ("AudiophileEcommerceWebsite") ?? throw new InvalidOperationException
    ("Connection string 'AudiophileEcommerceWebsite' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<OrderViewModelValidator>());
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();    
builder.Services.AddScoped<IShoppingBasket, ShoppingBasket>(sp => new ShoppingBasket(sp));

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

//builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<AudiophileDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Product/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");


DbInitializer.Seed(app);
app.Run();
