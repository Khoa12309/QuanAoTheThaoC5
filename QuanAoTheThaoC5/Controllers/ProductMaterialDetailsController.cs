using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;
using System.Text;

namespace QuanAoTheThaoC5.Controllers
{
    public class ProductMaterialDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ProductMaterialDetailsView()
        {
            string requestURL =
            $"https://localhost:7001/api/ProductMaterialDetails";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(requestURL); // Lấy kết quả
                                                                  // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            List<ProductMaterialDetails> result = JsonConvert.DeserializeObject<List<ProductMaterialDetails>>(apiData);
            return View(result);
        }
        [HttpGet]
        public IActionResult CreateProductMaterialDetails()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductMaterialDetails(ProductMaterialDetails obj)
        {

            obj.Id= Guid.NewGuid(); 
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            string requestURL =
            $"https://localhost:7001/api/ProductMaterialDetails";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.PostAsync(requestURL + "/CreateProductMaterialDetails", content); // Lấy kết quả// ]Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();

            return RedirectToAction("ProductMaterialDetailsView");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProductMaterialDetails(Guid id)
        {
            string requestURL =
            $"https://localhost:7001/api/ProductMaterialDetails";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(requestURL); // Lấy kết quả
                                                                  // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            List<ProductMaterialDetails> result = JsonConvert.DeserializeObject<List<ProductMaterialDetails>>(apiData);

            return View(result.Find(c => c.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProductMaterialDetails(ProductMaterialDetails obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            string requestURL =
            $"https://localhost:7001/api/ProductMaterialDetails";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.PutAsync(requestURL + "/UpdateProductMaterialDetails", content);

            string apiData = await response.Content.ReadAsStringAsync();
            return RedirectToAction("ProductMaterialDetailsView");
        }

        public async Task<IActionResult> DeleteProductMaterialDetails(Guid id)
        {

            string requestURL =
            $"https://localhost:7001/api/ProductMaterialDetails";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.DeleteAsync(requestURL + "/DeleteProductMaterialDetails?id=" + id.ToString());

            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            return RedirectToAction("ProductMaterialDetailsView");
            //
            //
        }
    }
}

