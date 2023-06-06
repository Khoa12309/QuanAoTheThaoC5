using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;
using System.Text;

namespace QuanAoTheThaoC5.Controllers
{
    public class VoucherController : Controller
    {
     
        // GET: VoucherController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VoucherController/Details/5
        public async Task<IActionResult> VoucherView()
        {
            string requestURL =
            $"https://localhost:7001/api/Voucher";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(requestURL); // Lấy kết quả
                                                                  // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result = JsonConvert.DeserializeObject<List<Voucher>>(apiData);
            return View(result);
        }

        // GET: VoucherController/Create
        [HttpGet]
        public ActionResult CreateVoucher()
        {
            return View();
        }

        // POST: VoucherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVoucher(Voucher obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            string requestURL =
            $"https://localhost:7001/api/Voucher";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.PostAsync(requestURL + "/create-item", content); 
            return RedirectToAction("VoucherView");

        }

        // GET: VoucherController/Edit/5

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)

        {

            string requestURL =
             $"https://localhost:7001/api/Voucher";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(requestURL); // Lấy kết quả
                                                                  // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result = JsonConvert.DeserializeObject<List<Voucher>>(apiData);


            return View(result.Find(c=>c.Id==id));
        }

        // POST: VoucherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(Voucher obj)

        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                string requestURL =
                $"https://localhost:7001/api/Voucher";
                var httpClient = new HttpClient(); // Tại 1 httpClient để call API
                var response = await httpClient.PutAsync(requestURL + "/put-item", content);
                string apiData = await response.Content.ReadAsStringAsync();
                return RedirectToAction("VoucherView");
            }
            catch
            {
                return View();
            }
        }

        // GET: VoucherController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {

            string requestURL =
            $"https://localhost:7001/api/Voucher";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.DeleteAsync(requestURL + "/delete-item?id=" + id.ToString());
            string apiData = await response.Content.ReadAsStringAsync();
           
            return RedirectToAction("VoucherView");
        }
    }
}
