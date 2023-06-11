using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;
using QuanAoTheThaoC5.Service;
using System.Diagnostics;
using System.Net.Http;

namespace QuanAoTheThaoC5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       // private readonly GetdataApi<Product> LproApi;
        //public HomeController()
        //{
        //       LproApi = new GetdataApi<Product>();
        //}
        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
        }

        public IActionResult Index()
        {
            string a = "Product";
           // ViewBag.Lproduct = LproApi.GetApiAsync(a);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public Product Product(Guid id)
        {
            
            var httpClient=new HttpClient();
            var respones =  httpClient.GetAsync("https://localhost:7001/api/Product").Result;
            var dataapi =  respones.Content.ReadAsStringAsync().Result;
            List<Product> dataobj = JsonConvert.DeserializeObject<List<Product>>(dataapi);
            return dataobj.FirstOrDefault(c=>c.Id==id);
        }

        //Cart
        public async Task<IActionResult> Cart()
        {
            var product = SessionService.GetObjFromSession(HttpContext.Session, "Cart");
            return View(product);
        }
        public async Task<IActionResult> AddToCart(Guid id, int SoLuong)
        {
            var product = Product(id);
            product.Quantity = SoLuong;
            var products = SessionService.GetObjFromSession(HttpContext.Session, "Cart");
           
            if (products.Count==0)
            {

                products.Add(product);
                SessionService.SetObjToJson(HttpContext.Session, "Cart", products);

            }
            else
            {
                if (!SessionService.CheckProductInCart(id, products)) // SP chưa nằm trong cart
                {
                    products.Add(product); 

                    SessionService.SetObjToJson(HttpContext.Session, "Cart", products);
                }
                else
                {
                    var productcart = products.FirstOrDefault(c => c.Id == id);
                    productcart.Quantity += SoLuong;
                    products.Remove(productcart);
                    products.Add(productcart);
                    SessionService.SetObjToJson(HttpContext.Session, "Cart", products);

                }
            }
            return View("Cart");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}