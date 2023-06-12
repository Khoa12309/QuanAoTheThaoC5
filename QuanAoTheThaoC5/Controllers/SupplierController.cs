using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;
using System.Text;

namespace QuanAoTheThaoC5.Controllers
{
    public class SupplierController : Controller
    {
        // GET: SupplierController1
        public async Task<IActionResult> GetList()
        {
            var Url = $"https://localhost:7001/api/Supplier";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(Url);
            var appData = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<List<Supplier>>(appData);
            return View(lst);
        }

        // GET: SupplierController1/Details/5
        //public async Task<IActionResult> Details(int id)
        //{
        //    return View();
        //}

        // GET: SupplierController1/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: SupplierController1/Create
        [HttpPost]
        public async Task<IActionResult> Create(Supplier sl)
        {
            try
            {
                var Url = $"https://localhost:7001/api/Supplier/create?SupllierCode={sl.SupllierCode}&SupplierName={sl.SupplierName}&PhoneNumber={sl.PhoneNumber}&Address={sl.Address}&Descripton={sl.Descripton}";
                HttpClient client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(sl), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Url, content);
                return RedirectToAction("GetList");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]

        // GET: SupplierController1/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var Url = $"https://localhost:7001/api/Supplier";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(Url);
            var appData = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<List<Supplier>>(appData);

            return View(lst.Find(c => c.Id == id));
        }

        // POST: SupplierController1/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Supplier sl)
        {
            try
            {
                var Url = $"https://localhost:7001/api/Supplier/update?id={sl.Id}&SupllierCode={sl.SupllierCode}&SupplierName={sl.SupplierName}&PhoneNumber={sl.PhoneNumber}&Address={sl.Address}&Descripton={sl.Descripton}";
                HttpClient client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(sl), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Url, content);
                return RedirectToAction("GetList");
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierController1/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var Url = $"https://localhost:7001/api/Supplier/delete?id={id}";
            HttpClient client = new HttpClient();
            var response = await client.DeleteAsync(Url);
            return RedirectToAction("GetList");

        }

        // POST: SupplierController1/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
