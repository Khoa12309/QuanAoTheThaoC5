using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;
using QuanAoTheThaoC5.Service;
using System.Text;

namespace QuanAoTheThaoC5.Controllers
{
	public class ProductImgController : Controller
	{
        private GetdataApi<Product> Lpro;
        public ProductImgController()
        {
            Lpro = new GetdataApi<Product>();
        }
		public IActionResult Index()
		{
			return View();
		}
        public async Task<IActionResult> ImgView()
        {
            string requestURL =
            $"https://localhost:7001/api/ProductImg";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(requestURL); // Lấy kết quả
                                                                  // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            List<ProductImg> result = JsonConvert.DeserializeObject<List<ProductImg>>(apiData);
            return View(result);
        }
        [HttpGet]
        public IActionResult CreateImg()
        {
            ViewBag.product = Lpro.GetApi("Product");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateImg(ProductImg obj, [Bind] IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "themes", "img", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile.CopyTo(stream);
                }
                // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
                obj.URl = imageFile.FileName;
            }
           
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            string requestURL =
            $"https://localhost:7001/api/ProductImg" +$"/CreateProductImg?IDProduct={obj.IDProduct}&URl={obj.URl}";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.PostAsync(requestURL , content); // Lấy kết quả// ]Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();

            return RedirectToAction("ImgView");
        }
        public async Task<IActionResult> UpdateImg(ProductImg obj, [Bind] IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "themes", "img", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile.CopyTo(stream);
                }
                // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
                obj.URl = imageFile.FileName;
            }
           
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            string requestURL =
            $"https://localhost:7001/api/ProductImg" +$"/UpdateProductImg?id={obj.Id}&IDProduct={obj.IDProduct}&URl={obj.URl}";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.PostAsync(requestURL , content); // Lấy kết quả// ]Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();

            return RedirectToAction("ImgView");
        }
        public async Task<IActionResult> DeleteImg(Guid id)
        {
            string requestURL =
            $"https://localhost:7001/api/ProductImg";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.DeleteAsync(requestURL + "/DeleteImg?id=" + id.ToString());

            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            return RedirectToAction("ImgView");
        }
    }
}
