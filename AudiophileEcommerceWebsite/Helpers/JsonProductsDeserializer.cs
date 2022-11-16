using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace AudiophileEcommerceWebsite.Helpers
{
    public class JsonProductsDeserializer
    {
        private static JsonSerializerOptions options => new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        private static List<Accessory> accessories = new List<Accessory>();
        private static List<Image> images = new List<Image>();
        private static List<Gallery> galleries = new List<Gallery>();
        private static List<RelatedData> relatedData = new List<RelatedData>();
        private static List<Product> products = new List<Product>();
        private static Dictionary<string, Category> categories = Categories.categories;

        public static List<Product> DeserializeJson(string filePath)
        {
            var jsonStr = File.ReadAllText(filePath);

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
            return products;
        }
        private static void PopulateProductImageMembers(JsonElement jsonProduct, Product product)
        {
            Image returnedImage = DeserializeImageNode(jsonProduct);
            product.Image = returnedImage;

            returnedImage =
                DeserializeImageNode(jsonProduct, "categoryImage");
            product.CategoryImages = returnedImage;
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

            Image newImages = DeserializeImageNode(galleryNode, "first");
            gallery.First = newImages;

            newImages = DeserializeImageNode(galleryNode, "second");
            gallery.Second = newImages;

            newImages = DeserializeImageNode(galleryNode, "third");
            gallery.Third = newImages;

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
        private static Image DeserializeImageNode(JsonElement item, string nodeNameStr = "image")
        {
            var node = item.GetProperty(nodeNameStr);
            var image = node.Deserialize<Image>(options);

            CorrectImageFilePath(image);

            var existingNode = images
                .FirstOrDefault(d => d.Mobile == image.Mobile);

            var updatedImage = UpdateGenericNodeReference<Image>(images, image, existingNode);

            return updatedImage;
        }
        private static void CorrectImageFilePath(Image? image)
        {
            image.Mobile = new string(image.Mobile.Skip(1).ToArray());
            image.Tablet = new string(image.Tablet.Skip(1).ToArray());
            image.Desktop = new string(image.Desktop.Skip(1).ToArray());
        }
        private static void PopulateProductCategoryMember(JsonElement jsonProduct, Product product)
        {
            var categoryNode = jsonProduct.GetProperty("category");
            product.Category = categories[categoryNode.ToString().ToLower()];
            product.ProductId = 0;
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

    }
}
