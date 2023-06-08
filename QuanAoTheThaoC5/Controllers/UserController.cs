using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;
using System.Text;

namespace QuanAoTheThaoC5.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public ActionResult Index()
        {

          return View();
        }
        public List<Role> roles()
        {

            string requestURL =
            $"https://localhost:7001/api/Role";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = httpClient.GetAsync(requestURL).Result; // Lấy kết quả                                                                 // Đọc ra string Json
            string apiData = response.Content.ReadAsStringAsync().Result;
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result = JsonConvert.DeserializeObject<List<Role>>(apiData);
            return result;
        }
        public async Task<IActionResult> UserView()
        {
            string requestURL =
            $"https://localhost:7001/api/User";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(requestURL); // Lấy kết quả
                                                                  // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result = JsonConvert.DeserializeObject<List<User>>(apiData);
            return View(result);
        }


        [HttpGet]
        public ActionResult CreateUser()
        {
            ViewBag.role = roles();
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(User obj)
        {
            ViewBag.role = roles();
            obj.Id = Guid.NewGuid();    
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.PostAsync("https://localhost:7001/api/User/createUser", content);
            return RedirectToAction("UserView");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {

            string requestURL =
             $"https://localhost:7001/api/User";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(requestURL); // Lấy kết quả
                                                                  // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result = JsonConvert.DeserializeObject<List<User>>(apiData);

            ViewBag.role = roles();

            return View(result.Find(c => c.Id == id));
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                string requestURL =
                $"https://localhost:7001/api/User";
                var httpClient = new HttpClient(); // Tại 1 httpClient để call API
                var response = await httpClient.PutAsync("https://localhost:7001/api/User/UpdateUser", content);
                string apiData = await response.Content.ReadAsStringAsync();
                ViewBag.role = roles();

                return RedirectToAction("UserView");
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {

            string requestURL =
            $"https://localhost:7001/api/User";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.DeleteAsync(requestURL + "/deleteUser?id=" + id.ToString());
            string apiData = await response.Content.ReadAsStringAsync();

            return RedirectToAction("UserView");
        }
    }
}
