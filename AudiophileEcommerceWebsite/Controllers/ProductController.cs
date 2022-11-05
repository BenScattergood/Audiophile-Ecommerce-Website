
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AudiophileEcommerceWebsite.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository productRepository;
        private readonly IMapper _mapper;

        public ProductController(ILogger<ProductController> logger,
            IProductRepository productRepository, IMapper mapper)
        {
            _logger = logger;
            this.productRepository = productRepository;
            this._mapper = mapper;
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

            var viewModelList = _mapper.Map<List<ProductViewModel>>(products);
            return View(viewModelList);
        }

        public IActionResult Product(int id)
        {
            var product = productRepository.GetProductById(id);

            var viewModel = _mapper.Map<ProductViewModel>(product);
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}