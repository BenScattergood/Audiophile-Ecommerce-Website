using Microsoft.EntityFrameworkCore;

namespace AudiophileEcommerceWebsite.ViewModels
{
    public class ProductRepository : IProductRepository
    {
        private readonly AudiophileDbContext _audiophileDbContext;

        public ProductRepository(AudiophileDbContext audiophileDbContext)
        {
            this._audiophileDbContext = audiophileDbContext;
        }

        public List<Product> GetAllProducts()
        {
            return
            _audiophileDbContext.Products.Select(c => c)
                .ToList();
        }

        public List<Product> GetProductsFromCategory(string category)
        {
            return
                _audiophileDbContext.Products
                .Where(c => c.Category.CategoryName.ToLower() == category.ToLower())
                .Include(p => p.Category)
                .Include(p => p.CategoryImages)
                .ToList();
        }

        public Product GetProductById(int id)
        {
            return _audiophileDbContext.Products
                .Include(c => c.Category)
                .Include(c => c.Image)
                .Include(c => c.CategoryImages)
                .Include(c => c.Accessories)
                .Include(c => c.Gallery.First)
                .Include(c => c.Gallery.Second)
                .Include(c => c.Gallery.Third)
                .Include(c => c.RelatedData)
                .ThenInclude(r => r.Images)
                .SingleOrDefault(c => c.ProductId == id);
        }

        public void ProvideProductIdToRelatedDataVM(ProductViewModel product)
        {
            foreach (var data in product.RelatedData)
            {
                data.ProductId =
                    _audiophileDbContext.Products
                    .FirstOrDefault(p => p.Slug == data.Slug)
                    .ProductId;
            }
        }
        public Product ReturnShallowProductFromName(string productName)
        {
            return _audiophileDbContext.Products
                .SingleOrDefault(p => p.ProductName == productName);
        }
    }
}
