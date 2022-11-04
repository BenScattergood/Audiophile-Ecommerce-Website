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
                .Include(p => p.Category).ToList();
        }
    }
}
