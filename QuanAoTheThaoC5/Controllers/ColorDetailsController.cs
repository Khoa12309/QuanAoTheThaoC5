using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;
using System.Text;

namespace QuanAoTheThaoC5.Controllers
{

    public class ColorDetailsController : Controller
    {
        // GET: ColorDetailsController
        public List<Product> ProductList()
        {
            var Url = $"https://localhost:7001/api/Product";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(Url).Result;
            var appData = response.Content.ReadAsStringAsync().Result;
            var lst = JsonConvert.DeserializeObject<List<Product>>(appData);
            return lst;
        }

        public List<Color> ColorList()
        {
            var Url = $"https://localhost:7001/api/Color";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(Url).Result;
            var appData = response.Content.ReadAsStringAsync().Result;
            var lst = JsonConvert.DeserializeObject<List<Color>>(appData);
            return lst;
        }

        public async Task<IActionResult> GetList()
        {
            var Url = $"https://localhost:7001/api/ColorDetails";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(Url);
            var appData = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<List<ColorDetails>>(appData);
            return View(lst);
        }
        [HttpGet]
        // GET: ColorDetailsController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: ColorDetailsController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Product = ProductList();
            ViewBag.Color = ColorList();
            return View();
        }

        // POST: ColorDetailsController/Create
        [HttpPost]
        public async Task<IActionResult> Create(ColorDetails cld)
        {
            try
            {
                ViewBag.Product = ProductList();
                ViewBag.Color = ColorList();
                var Url = $"https://localhost:7001/api/ColorDetails/create?ProductID={cld.ProductID}&ColorID={cld.ColorID}&Description={cld.Description}";
                HttpClient client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(cld), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Url, content);
                return RedirectToAction("GetList");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]

        // GET: ColorDetailsController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var Url = $"https://localhost:7001/api/ColorDetails";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(Url);
            var appData = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<List<ColorDetails>>(appData);

            return View(lst.Find(c => c.Id == id));
        }

        // POST: ColorDetailsController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(ColorDetails cld)
        {
            try
            {
                var Url = $"https://localhost:7001/api/ColorDetails/update?id={cld.Id}&ProductID={cld.ProductID}&ColorID={cld.ColorID}&Description={cld.Description}";
                HttpClient client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(cld), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Url, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetList");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ColorDetailsController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var Url = $"https://localhost:7001/api/ColorDetails/delete?id={id}";
            HttpClient client = new HttpClient();
            var response = await client.DeleteAsync(Url);
            return RedirectToAction("GetList");
        }

        // POST: ColorDetailsController/Delete/5
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
