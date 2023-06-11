using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;
using System.Text;

namespace QuanAoTheThaoC5.Controllers
{
	public class ProductImgController : Controller
	{
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
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateImg(ProductImg obj)
        {
            
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            string requestURL =
            $"https://localhost:7001/api/ProductImg" +$"/CreateProductImg?IDProduct={obj.IDProduct}&URl={obj.URl}";
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
