
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AudiophileEcommerceWebsite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper _mapper;
        //private readonly ILogger _logger;

        public ProductController(IProductRepository productRepository,
            IMapper mapper /*ILogger logger*/)
        {
            this.productRepository = productRepository;
            this._mapper = mapper;
            //_logger = logger;
        }

        public IActionResult Index()
        {
            var products = productRepository.GetAllProducts();

            var viewModelList = _mapper.Map<List<ProductViewModel>>(products);
            return View(viewModelList);
        }

        public IActionResult Category(string category)
        {
            var products = productRepository.GetProductsFromCategory(category);
            if (products.Count == 0)
            {
                return NotFound();
            }
            var viewModelList = _mapper.Map<List<ProductViewModel>>(products);
            var sortedVML = viewModelList
                .OrderByDescending(c => c.isNew)
                .ToList();

            return View(sortedVML);
        }

        public IActionResult Product(int id)
        {
            var product = productRepository.GetProductById(id);
            if (product is null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<ProductViewModel>(product);

            productRepository.ProvideProductIdToRelatedDataVM(viewModel);

            return View(viewModel);
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //log error
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}