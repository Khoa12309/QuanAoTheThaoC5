using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;
using System.Text;

namespace QuanAoTheThaoC5.Controllers
{
    public class Product1Controller : Controller
    {
        public List<Size> Sizes()
        {

            string requestURL =
            $"https://localhost:7001/api/Size";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = httpClient.GetAsync(requestURL).Result; // Lấy kết quả                                                                 // Đọc ra string Json
            string apiData = response.Content.ReadAsStringAsync().Result;
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result = JsonConvert.DeserializeObject<List<Size>>(apiData);
            return result;
        }
        public List<Category> LCategory()
        {

            string requestURL =
            $"https://localhost:7001/api/Category";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = httpClient.GetAsync(requestURL).Result; // Lấy kết quả                                                                 // Đọc ra string Json
            string apiData = response.Content.ReadAsStringAsync().Result;
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result = JsonConvert.DeserializeObject<List<Category>>(apiData);
            return result;
        }
        public List<Supplier> LSupplier()
        {

            string requestURL =
            $"https://localhost:7001/api/Supplier";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = httpClient.GetAsync(requestURL).Result; // Lấy kết quả                                                                 // Đọc ra string Json
            string apiData = response.Content.ReadAsStringAsync().Result;
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result = JsonConvert.DeserializeObject<List<Supplier>>(apiData);
            return result;
        }
        public async Task<bool> Addimg(Guid idpro, string url)
        {
            var obj = new ProductImg()
            {
                IDProduct = idpro,
                URl = url
            };

            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            string requestURL =
            $"https://localhost:7001/api/ProductImg";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.PostAsync(requestURL + "/CreateProductImg", content);
            return true;
        }
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

        [HttpGet]
        public IActionResult CreateProduct()
        {
            ViewBag.LSize = Sizes();
            ViewBag.LCategory = LCategory();
            ViewBag.LSupplier = LSupplier();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product obj)
        {

            obj.Id = Guid.NewGuid();



            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync("https://localhost:7001/api/Product/CreateProduct", content);
            //var x = imageFile.FileName;
            //if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            //{
            //    //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
            //    var path = Path.Combine(
            //        Directory.GetCurrentDirectory(), "wwwroot", "themes", "img", imageFile.FileName);
            //    using (var stream = new FileStream(path, FileMode.Create))
            //    {
            //        // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
            //        imageFile.CopyTo(stream);
            //    }
            //    // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
            //}
            //Addimg(obj.Id, imageFile.FileName);


            return RedirectToAction("ProductView");

        }
    }
}
