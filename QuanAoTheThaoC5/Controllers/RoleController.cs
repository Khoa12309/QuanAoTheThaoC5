using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;



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
		public async Task<IActionResult> CreateRole()
		{
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> CreateRole(string name)
		{
			string requestURL =
			$"https://localhost:7001/api/Role/" + $"CreateRole?Name={name}";
			var httpClient = new HttpClient(); // Tại 1 httpClient để call API
			var response = await httpClient.GetAsync(requestURL); // Lấy kết quả
																  // Đọc ra string Json
			string apiData = await response.Content.ReadAsStringAsync();
			// Lấy kết quả thu được bằng cách bóc dữ liệu Json
			List<Role> result = JsonConvert.DeserializeObject<List<Role>>(apiData);

			return RedirectToAction("RoleView");

        }
	}
}
