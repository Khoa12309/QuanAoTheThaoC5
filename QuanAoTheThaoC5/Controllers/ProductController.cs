using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;

namespace QuanAoTheThaoC5.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> ProductView()
        {
            string requestURL =
            $"https://localhost:7001/api/Product";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(requestURL); // Lấy kết quả
                                                                  // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            List<Product> result = JsonConvert.DeserializeObject<List<Product>>(apiData);
            return View(result);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
        [HttpGet]
        public async Task< IActionResult> Details(Guid id)
        {

            string requestURL = $"https://localhost:7001/api/Product/{id}";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(requestURL); // Lấy kết quả
                                                                  // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            Product result = JsonConvert.DeserializeObject<Product>(apiData);

            return View(result);
        }
    }
}
