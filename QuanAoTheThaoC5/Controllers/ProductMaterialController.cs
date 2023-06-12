using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;
using System.Text;

namespace QuanAoTheThaoC5.Controllers
{
    public class ProductMaterialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ProductMaterialView()
        {
            string requestURL =
            $"https://localhost:7001/api/ProductMaterial";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(requestURL); // Lấy kết quả
                                                                  // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            List<ProductMaterial> result = JsonConvert.DeserializeObject<List<ProductMaterial>>(apiData);
            return View(result);///
        }
        [HttpGet]
        public IActionResult CreateProductMaterial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductMaterial(ProductMaterial obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            string requestURL =
            $"https://localhost:7001/api/ProductMaterial";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.PostAsync(requestURL + "/CreateProductMaterial", content); // Lấy kết quả// ]Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();

            return RedirectToAction("ProductMaterialView");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProductMaterial(Guid id)
        {
            string requestURL =
            $"https://localhost:7001/api/ProductMaterial";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(requestURL); // Lấy kết quả
                                                                  // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            List<ProductMaterial> result = JsonConvert.DeserializeObject<List<ProductMaterial>>(apiData);

            return View(result.Find(c => c.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProductMaterial(ProductMaterial obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            string requestURL =
            $"https://localhost:7001/api/ProductMaterial";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.PutAsync(requestURL + "/UpdateProductMaterial", content);

            string apiData = await response.Content.ReadAsStringAsync();
            return RedirectToAction("ProductMaterialView");
        }

        public async Task<IActionResult> DeleteProductMaterial(Guid id)
        {

            string requestURL =
            $"https://localhost:7001/api/ProductMaterial";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.DeleteAsync(requestURL + "/DeleteProductMaterial?id=" + id.ToString());

            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            return RedirectToAction("ProductMaterialView");
        }
    }
}

