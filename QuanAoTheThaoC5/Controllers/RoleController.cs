using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;
using System.Diagnostics;
using System.Text;

namespace QuanAoTheThaoC5.Controllers
{
	public class RoleController : Controller
	{
        
		public IActionResult Index()
		{
			return View();
		}
        public async Task<IActionResult> RoleView()
		{
            string requestURL =
			$"https://localhost:7001/api/Role" ;
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(requestURL); // Lấy kết quả
                                                                  // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            List<Role> result = JsonConvert.DeserializeObject<List<Role>>(apiData);
            return View(result);
		}
		[HttpGet]
		public IActionResult CreateRole()
		{
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> CreateRole(Role obj)
		{
			string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            string requestURL =
			$"https://localhost:7001/api/Role" ;
			var httpClient = new HttpClient(); // Tại 1 httpClient để call API
			var response = await httpClient.PostAsync(requestURL+ "/CreateRole", content); // Lấy kết quả// ]Đọc ra string Json
			string apiData = await response.Content.ReadAsStringAsync();
			// Lấy kết quả thu được bằng cách bóc dữ liệu Json

			return RedirectToAction("RoleView");
        }
		[HttpGet]
        public IActionResult UpdateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(Role obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            string requestURL =
            $"https://localhost:7001/api/Role";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.PutAsync(requestURL + "/UpdateRole", content); 

            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            return RedirectToAction("RoleView");
        }
      
        public async Task<IActionResult> DeleteRole(Guid id)
        {

            string requestURL =
            $"https://localhost:7001/api/Role";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.DeleteAsync(requestURL + "/DeleteRole/"+id); 

            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            return RedirectToAction("RoleView");
        }
    }
}
