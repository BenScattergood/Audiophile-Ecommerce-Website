using AudiophileEcommerceWebsite.Entities;
using System.Text.Json;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Image = AudiophileEcommerceWebsite.Entities.Image;

public static class DbInitializer
{
    private static AudiophileDbContext _context;
    private static JsonSerializerOptions options => new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    private static List<Accessory> accessories = new List<Accessory>();
    private static List<Image> images = new List<Image>();
    private static List<Gallery> galleries = new List<Gallery>();
    private static List<RelatedData> relatedData = new List<RelatedData>();
    private static List<Product> products = new List<Product>();

    public static void Seed(IApplicationBuilder application)
    {
        _context = application.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<AudiophileDbContext>();

        if (!_context.Categories.Any())
        {
            _context.Categories.AddRange(Categories.Select(c => c.Value));
        }

        if (!_context.Products.Any())
        {
            Categories.Select(c => c.Value);
            DeserializeJson();
        }

        _context.SaveChanges();
    }
    private static void DeserializeJson()
    {
        var jsonStr = File.ReadAllText("data.json");

        products = JsonSerializer.Deserialize<List<Product>>(jsonStr, options);

        using (JsonDocument document = JsonDocument.Parse(jsonStr))
        {
            JsonElement root = document.RootElement;
            int i = 1;

            foreach (var jsonProduct in root.EnumerateArray())
            {
                Product product = products[i - 1];

                PopulateProductImageMembers(jsonProduct, product);
                var temp = jsonProduct.GetProperty("new");

                DeserializeJsonToAccessoryObject(product, jsonProduct);
                DeserializeJsonToGalleryObject(product, jsonProduct);
                DeserializeJsonToRelatedDataObject(product, jsonProduct);
                PopulateProductCategoryMember(jsonProduct, product);
                i++;
            }
        }
        _context.AddRange(products);
    }

    private static void PopulateProductCategoryMember(JsonElement jsonProduct, Product product)
    {
        var categoryNode = jsonProduct.GetProperty("category");
        product.Category = categories[categoryNode.ToString().ToLower()];
        product.ProductId = 0;
    }
    private static void PopulateProductImageMembers(JsonElement jsonProduct, Product product)
    {
        List<Image> ImageList =
                            DeserializeImageNode(jsonProduct);
        product.Image = ImageList[0];

        ImageList =
            DeserializeImageNode(jsonProduct, "categoryImage");
        product.CategoryImages = ImageList[0];
    }
    private static void DeserializeJsonToRelatedDataObject(Product product, JsonElement item)
    {
        var othersNode = item.GetProperty("others");
        var deserializedRelatedData = othersNode.Deserialize<List<RelatedData>>(options);

        int i = 0;
        foreach (var relatedDataItem in deserializedRelatedData)
        {
            var existingRelatedData = relatedData
                .SingleOrDefault(d => d.Name == relatedDataItem.Name);

            var updatedRelatedData =
                UpdateGenericNodeReference<RelatedData>(relatedData, relatedDataItem, existingRelatedData);

            updatedRelatedData.Images =
                    DeserializeImageNode(othersNode[i]);

            product.RelatedData.Add(updatedRelatedData);

            i++;
        }
    }
    private static void DeserializeJsonToGalleryObject(Product product, JsonElement item)
    {
        var galleryNode = (JsonElement)item.GetProperty("gallery");
        var gallery = new Gallery();

        List<Image> newListImages = DeserializeImageNode(galleryNode, "first");
        gallery.First.AddRange(newListImages);

        newListImages = DeserializeImageNode(galleryNode, "second");
        gallery.Second.AddRange(newListImages);

        newListImages = DeserializeImageNode(galleryNode, "third");
        gallery.Third.AddRange(newListImages);

        product.Gallery = gallery;
    }
    private static void DeserializeJsonToAccessoryObject(Product product, JsonElement item)
    {
        var includesNode = item.GetProperty("includes");
        var deserializedAccessories = includesNode.Deserialize<List<Accessory>>(options);

        foreach (var accessory in deserializedAccessories)
        {
            var existingAccessory = accessories
                .SingleOrDefault(d => d.Quantity == accessory.Quantity
                                       && d.Item == accessory.Item);

            var updatedAccessory =
                UpdateGenericNodeReference<Accessory>(accessories, accessory, existingAccessory);

            product.Accessories.Add(updatedAccessory);
        }
    }
    private static List<Image> DeserializeImageNode(JsonElement item, string nodeNameStr = "image")
    {
        var node = item.GetProperty(nodeNameStr);
        var image = node.Deserialize<Image>(options);

        CorrectImageFilePath(image);

        var existingNode = images
            .FirstOrDefault(d => d.Mobile == image.Mobile);

        var updatedImage = UpdateGenericNodeReference<Image>(images, image, existingNode);

        return new List<Image>() { updatedImage };
    }

    private static void CorrectImageFilePath(Image? image)
    {
        image.Mobile = new string(image.Mobile.Skip(1).ToArray());
        image.Tablet = new string(image.Tablet.Skip(1).ToArray());
        image.Desktop = new string(image.Desktop.Skip(1).ToArray());
    }

    private static T UpdateGenericNodeReference<T>(List<T> list, T node, T existingNode)
    {
        if (existingNode is null)
        {
            list.Add(node);
            return node;
        }

        return existingNode;
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