using AudiophileEcommerceWebsite.Entities;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using Image = AudiophileEcommerceWebsite.Entities.Image;

public static class DbInitializer
{
    public static void Seed(IApplicationBuilder application)
    {
        //EntertainmentWebAppDbContext context = application.ApplicationServices
        //    .CreateScope().ServiceProvider
        //    .GetRequiredService<EntertainmentWebAppDbContext>();

        //if (!context.Categories.Any())
        //{
        //    context.Categories.AddRange(Categories.Select(c => c.Value));
        //}

        //if (!context.MotionPictures.Any())
        //{
        //    context.AddRange(DeserializeJsonToMotionPicture().Select(m => m));
        //}

        //context.SaveChanges();
        Categories.Select(c => c.Value);

        var temp = DeserializeJsonToMotionPicture();
    }

    private static List<Product> DeserializeJsonToMotionPicture()
    {
        var jsonStr = File.ReadAllText("data.json");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        List<Product> Products = JsonSerializer.Deserialize<List<Product>>(jsonStr, options);

        using (JsonDocument document = JsonDocument.Parse(jsonStr))
        {
            JsonElement root = document.RootElement;
            int i = 0;

            foreach (var item in root.EnumerateArray())
            {
                var categoryNode = item.GetProperty("category");
                Products[i].Category = categories[categoryNode.ToString().ToLower()];
                int p = 0;
                var others = item.GetProperty("others");
                foreach (var member in others.EnumerateArray())
                {
                    var image = member.GetProperty("image");
                    Products[i].Others[p].Images = new Image();
                    Products[i].Others[p].Images.Mobile =
                        image.GetProperty("mobile").ToString();
                    Products[i].Others[p].Images.Tablet =
                        image.GetProperty("tablet").ToString();
                    Products[i].Others[p].Images.Desktop =
                        image.GetProperty("desktop").ToString();
                    p++;
                }
                

                i++;
            }

            Console.WriteLine();
        }

        return Products;
    }

    private static Dictionary<string, Category>? categories;

    public static Dictionary<string, Category> Categories
    {
        get
        {
            if (categories == null)
            {
                var genresList = new Category[]
                {
                        new Category { CategoryName = "headphones" },
                        new Category { CategoryName = "earphones" },
                        new Category { CategoryName = "speakers" },
                };

                categories = new Dictionary<string, Category>();

                foreach (Category genre in genresList)
                {
                    categories.Add(genre.CategoryName, genre);
                }
            }

            return categories;
        }
    }
}