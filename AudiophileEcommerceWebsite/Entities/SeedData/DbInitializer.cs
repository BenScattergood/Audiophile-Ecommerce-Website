using AudiophileEcommerceWebsite.Entities;
using AudiophileEcommerceWebsite.Helpers;
using System.Text.Json;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Image = AudiophileEcommerceWebsite.Entities.Image;

public static class DbInitializer
{
    private static AudiophileDbContext _context;
    
    public static void Seed(IApplicationBuilder application)
    {
        _context = application.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<AudiophileDbContext>();

        if (!_context.Categories.Any())
        {
            _context.Categories.AddRange(Categories.GetCategories());
        }

        if (!_context.Products.Any())
        {
            _context.AddRange(JsonProductsDeserializer.DeserializeJson
                ("Entities/SeedData/data.json"));
        }

        _context.SaveChanges();
    }
    
}