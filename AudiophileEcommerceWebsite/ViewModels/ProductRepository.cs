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
                .ToList();
        }

        public Product GetProductById(int id)
        {
            return
                _audiophileDbContext.Products
                .Include(c => c.Category)
                .Include(c => c.Image)
                .Include(c => c.CategoryImages)
                .Include(c => c.Accessories)
                .Include(c => c.Gallery)
                .Include(c => c.RelatedData)
                .SingleOrDefault(c => c.ProductId == id);
        }
    }
}
