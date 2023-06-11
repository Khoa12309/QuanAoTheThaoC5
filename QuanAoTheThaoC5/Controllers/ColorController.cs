using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;
using System.Text;

namespace QuanAoTheThaoC5.Controllers
{
    public class ColorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ColorView()
        {
            string requestURL =
            $"https://localhost:7001/api/Color";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(requestURL); // Lấy kết quả
                                                                  // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            List<Color> result = JsonConvert.DeserializeObject<List<Color>>(apiData);
            return View(result);
        }
        [HttpGet]
        public IActionResult CreateColor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateColor(Color obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            string requestURL =
            $"https://localhost:7001/api/Category";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.PostAsync(requestURL + "/CreateColor", content); // Lấy kết quả// ]Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();

            return RedirectToAction("ColorView");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateColor(Guid id)
        {
            string requestURL =
            $"https://localhost:7001/api/Color";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(requestURL); // Lấy kết quả
                                                                  // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            List<Color> result = JsonConvert.DeserializeObject<List<Color>>(apiData);

            return View(result.Find(c => c.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateColor(Color obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            string requestURL =
            $"https://localhost:7001/api/Color";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.PutAsync(requestURL + "/UpdateColor", content);

            string apiData = await response.Content.ReadAsStringAsync();
            return RedirectToAction("ColorView");
        }

        public async Task<IActionResult> DeleteColor(Guid id)
        {

            string requestURL =
            $"https://localhost:7001/api/Category";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.DeleteAsync(requestURL + "/DeleteColor?id=" + id.ToString());

            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            return RedirectToAction("ColorView");
        }
    }
}
