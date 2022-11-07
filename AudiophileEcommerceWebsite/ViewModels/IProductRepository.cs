namespace AudiophileEcommerceWebsite.ViewModels
{
    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public List<Product> GetProductsFromCategory(string category);
        public Product GetProductById(int id);
        public void ProvideProductIdToRelatedDataVM(ProductViewModel product);
    }
}
