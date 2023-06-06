using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> CreateVoucher(string Name, string VoucherCode, string Description, int Status, DateTime CreateDate, DateTime StartDate, DateTime EndDate, int DiscountValue)
        {
        
            string requestURL =
            $"https://localhost:7001/api/Voucher/" + $"create-item?Name={Name}&VoucherCode={VoucherCode}&Description={Description}&Status={Status}&CreateDate={CreateDate}&StartDate={StartDate}&EndDate={EndDate}&DiscountValue={DiscountValue}";
            
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var content = new StringContent(requestURL);
          //  var response = await httpClient.PostAsync(); // Lấy kết quả
                                                                  // Đọc ra string Json
           
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json

            return RedirectToAction("VoucherView");

        }

        // GET: VoucherController/Edit/5
        public ActionResult UpdateVocher(int id)
        {
            return View();
        }

        // POST: VoucherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateVocher(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VoucherController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VoucherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
