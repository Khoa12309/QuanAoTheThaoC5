using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;
using System.Text;

namespace QuanAoTheThaoC5.Controllers
{
    public class SizeController : Controller
    {
        // GET: SizeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VoucherController/Details/5
        public async Task<IActionResult> SizeView()
        {
            string requestURL =
            $"https://localhost:7001/api/Size";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(requestURL); // Lấy kết quả
                                                                  // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result = JsonConvert.DeserializeObject<List<Size>>(apiData);
            return View(result);
        }

        // GET: VoucherController/Create
        [HttpGet]
        public ActionResult CreateSize()
        {
            return View();
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSize(Size obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            string requestURL =
            $"https://localhost:7001/api/Size";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.PostAsync(requestURL + "/createsize", content);
            return RedirectToAction("SizeView");
        }

        // GET: VoucherController/Edit/5
        [HttpGet]
        public async Task<IActionResult> EditSize(Guid id)
        {

            string requestURL =
             $"https://localhost:7001/api/Size";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(requestURL); // Lấy kết quả
                                                                  // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result = JsonConvert.DeserializeObject<List<Size>>(apiData);


            return View(result.Find(c => c.SizeId == id));
        }

        // POST: VoucherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSize(Guid id,Size obj)
        {
            var url = $"https://localhost:7001/api/Size";
            obj.SizeId = id;
            var data = JsonConvert.SerializeObject(obj);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            var response= await httpClient.PutAsync(url+ "/UpdateSize", content);
            return RedirectToAction("SizeView");
        }

        // GET: VoucherController/Delete/5
        public async Task<IActionResult> DeleteSize(Guid id)
        {

            string requestURL =
            $"https://localhost:7001/api/Size";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.DeleteAsync(requestURL + "/deletesize?id=" + id.ToString());

            return RedirectToAction("SizeView");
        }
       
    }
}
