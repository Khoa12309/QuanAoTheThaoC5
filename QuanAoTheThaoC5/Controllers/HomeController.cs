
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;
using QuanAoTheThaoC5.Service;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace QuanAoTheThaoC5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GetdataApi<Product> LproApi;
        private readonly GetdataApi<ProductImg> LproImgApi;
        
        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
            LproApi = new GetdataApi<Product>();
            LproImgApi = new GetdataApi<ProductImg>();
        }
        public List<Product> GetApiAsync()
        {
            var url = $"https://localhost:7001/api/Product";
            var httpClient = new HttpClient();
            var respones =  httpClient.GetAsync(url).Result;
            var dataapi = respones.Content.ReadAsStringAsync().Result;
            var dataobj = JsonConvert.DeserializeObject<List<Product>>(dataapi);
            return dataobj;
        }
        public IActionResult Index()
        {
            ViewBag.Lproduct = GetApiAsync();
            var img=LproImgApi.GetApi("ProductImg");

           

            return View(img);
        }
        public async Task<bool> CreateBill(Bill obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            string requestURL =
            $"https://localhost:7001/api/Bill";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.PostAsync(requestURL + "/CreateBill", content); // Lấy kết quả// ]Đọc ra string Json
            if (response.IsSuccessStatusCode==false)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> CreateBillDetails(BillDetails obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            string requestURL =
            $"https://localhost:7001/api/BillDetails";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.PostAsync(requestURL + "/CreateBillDetails", content); // Lấy kết quả// ]Đọc ra string Json
            if (response.IsSuccessStatusCode == false)
            {
                return false;
            }
            return true;
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public Product Product(Guid id)
        {
            
            var httpClient=new HttpClient();
            var respones =  httpClient.GetAsync("https://localhost:7001/api/Product").Result;
            var dataapi =  respones.Content.ReadAsStringAsync().Result;
            List<Product> dataobj = JsonConvert.DeserializeObject<List<Product>>(dataapi);
            return dataobj.FirstOrDefault(c=>c.Id==id);
        }

        //Cart
        public async Task<IActionResult> Cart()
        {
            ViewBag.product = SessionService.GetObjFromSession(HttpContext.Session, "Cart");
            var img = LproImgApi.GetApi("ProductImg");

            return View(img);
        }
        public async Task<IActionResult> AddToCart(Guid id, int SoLuong)
        {
            var product = Product(id);
            product.Quantity = SoLuong;
            var products = SessionService.GetObjFromSession(HttpContext.Session, "Cart");
           
            if (products.Count==0)
            {

                products.Add(product);
                SessionService.SetObjToJson(HttpContext.Session, "Cart", products);

            }
            else
            {
                if (!SessionService.CheckProductInCart(id, products)) // SP chưa nằm trong cart
                {
                    products.Add(product); 

                    SessionService.SetObjToJson(HttpContext.Session, "Cart", products);
                }
                else
                {
                    var productcart = products.FirstOrDefault(c => c.Id == id);
                    productcart.Quantity += SoLuong;
                    products.Remove(productcart);
                    products.Add(productcart);
                    SessionService.SetObjToJson(HttpContext.Session, "Cart", products);

                }
            }
            return RedirectToAction("Cart");
        }
        public IActionResult DeleteCartItem(Guid id)
        {
            var products = SessionService.GetObjFromSession(HttpContext.Session, "Cart");
            var p = products.Find(c => c.Id == id);
            products.Remove(p);
            SessionService.SetObjToJson(HttpContext.Session, "Cart", products);

            return RedirectToAction("Cart");
        }
        public IActionResult Muahang(Guid id)
        {
            var product = SessionService.GetObjFromSession(HttpContext.Session, "Cart");
            ViewBag.img = LproImgApi.GetApi("ProductImg").FirstOrDefault(c=>c.IDProduct==id);
            ViewBag.data = product.FirstOrDefault(c => c.Id == id);
            return View();
        }

        public IActionResult Thanhtoan(Guid id) {
            var product = SessionService.GetObjFromSession(HttpContext.Session, "Cart").FirstOrDefault(c=>c.Id==id);
            var bill = new Bill()
            {
                Id = new Guid(),
                CreateDate = DateTime.Now,
                Address = "09090909",
                IDUser = Guid.Empty ,
                IDVoucher = Guid.Empty,
                PhoneNumber = "0909090909",
                Status = 1,
                TotalMoney = product.Price*product.Quantity,
                 TransportFee = 0,                  
            };
            CreateBill(bill);
            var billdetails = new BillDetails()
            {
                IDBill=bill.Id,
                 Amount=product.Quantity,
                   IDProduct=product.Id,
                    Price=product.Price,
            };
            CreateBillDetails(billdetails);
            var producttt = SessionService.GetObjFromSession(HttpContext.Session, "Cart");
            var a = LproApi.GetApi("Product").FirstOrDefault(c => c.Id == id);
            producttt.Clear();
            SessionService.SetObjToJson(HttpContext.Session, "Cart", producttt);

            return RedirectToAction("Cart");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}