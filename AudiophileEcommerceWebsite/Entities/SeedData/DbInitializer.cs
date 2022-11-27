using AudiophileEcommerceWebsite.Entities;
using AudiophileEcommerceWebsite.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Image = AudiophileEcommerceWebsite.Entities.Image;

public static class DbInitializer
{
    private static AudiophileDbContext _context;
    
    public static void Seed(AudiophileDbContext _audiophileDbContext)
    {
        _context = _audiophileDbContext;

        if (!_context.Products.Any())
        {
            _context.AddRange(JsonProductsDeserializer.DeserializeJson
                ("Entities/SeedData/data.json"));
        }
        if (!_context.Categories.Any())
        {
            _context.AddRange(Categories.GetCategories());
        }

        _context.SaveChanges();
    }
    
}