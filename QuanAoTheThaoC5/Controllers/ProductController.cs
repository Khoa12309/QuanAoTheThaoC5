using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;
using QuanAoTheThaoC5.Service;
using System.Text;

namespace QuanAoTheThaoC5.Controllers
{
    public class ProductController : Controller
    {
        HttpClient httpClient;
        GetdataApi<ProductImg> Limg;
        // GET: ProductController
        public ProductController()
        {

            httpClient=new HttpClient();
            Limg=new GetdataApi<ProductImg>();
        }
        public List<Size> Sizes()
        {

            string requestURL =
            $"https://localhost:7001/api/Size";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = httpClient.GetAsync(requestURL).Result; // Lấy kết quả                                                                 // Đọc ra string Json
            string apiData = response.Content.ReadAsStringAsync().Result;
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result = JsonConvert.DeserializeObject<List<Size>>(apiData);
            return result;
        }
        public List<Category> LCategory()
        {

            string requestURL =
            $"https://localhost:7001/api/Category";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = httpClient.GetAsync(requestURL).Result; // Lấy kết quả                                                                 // Đọc ra string Json
            string apiData = response.Content.ReadAsStringAsync().Result;
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result = JsonConvert.DeserializeObject<List<Category>>(apiData);
            return result;
        }
        public List<Supplier> LSupplier()
        {

            string requestURL =
            $"https://localhost:7001/api/Supplier";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = httpClient.GetAsync(requestURL).Result; // Lấy kết quả                                                                 // Đọc ra string Json
            string apiData = response.Content.ReadAsStringAsync().Result;
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result = JsonConvert.DeserializeObject<List<Supplier>>(apiData);
            return result;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductController/Details/5
       public async Task<IActionResult> ProductView()
        {
            ViewBag.Limg = Limg.GetApi("ProductImg");

            var url = $"https://localhost:7001/api/Product";
            var respones=await httpClient.GetAsync("https://localhost:7001/api/Product");
            var dataapi= await respones.Content.ReadAsStringAsync();
            List<Product> dataobj = JsonConvert.DeserializeObject<List<Product>>(dataapi);
            return View(dataobj);
        }
        public async Task<bool> Addimg(Guid idpro, string url)
        {
            var obj = new ProductImg()
            {
                IDProduct = idpro,
                URl = url
            };

            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            string requestURL =
            $"https://localhost:7001/api/ProductImg" + $"/CreateProductImg?IDProduct={obj.IDProduct}&URl={obj.URl}";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.PostAsync(requestURL , content);
            return true;
        }
        // GET: ProductController/Create
        public IActionResult CreateProduct()
        {
            ViewBag.LSize = Sizes();
            ViewBag.LCategory = LCategory();
            ViewBag.LSupplier = LSupplier();

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
  
        public async Task<IActionResult> CreateProduct(Product obj, [Bind] IFormFile imageFile)
        {

            ViewBag.LSize = Sizes();
            ViewBag.LCategory = LCategory();
            ViewBag.LSupplier = LSupplier();
            try
            {
                obj.Id = Guid.NewGuid();
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string requestURL = $"https://localhost:7001/api/Product" + $"/CreateProduct?IDCategory={obj.IDCategory}&IDSupplier={obj.IDSupplier}&IDSize={obj.Size}&Name={obj.Name}&Description={obj.Description}&Quantity={obj.Quantity}&Price={obj.Price}&Status={obj.Status}";
                var httpClient = new HttpClient(); // Tại 1 httpClient để call API
                var response = await httpClient.PostAsync($"https://localhost:7001/api/Product/CreateProduct", content); // Lấy kết quả// ]Đọc ra string Json
                string apiData = await response.Content.ReadAsStringAsync();
                var x = imageFile.FileName;
                if (imageFile != null && imageFile.Length > 0) // Không null và không trống
                {
                    //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot", "themes", "img", imageFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                        imageFile.CopyTo(stream);
                    }
                    // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
                }
                Addimg(obj.Id, imageFile.FileName);
                return RedirectToAction("ProductView");

            }
            catch
            {   

                return View();
            }
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> UpdateProduct(Guid id)
        {
            ViewBag.LSize = Sizes();
            ViewBag.LCategory = LCategory();
            ViewBag.LSupplier = LSupplier();
            var url = $"https://localhost:7001/api/Product";
            var respones = await httpClient.GetAsync("https://localhost:7001/api/Product");
            var dataapi = await respones.Content.ReadAsStringAsync();
            List<Product> dataobj = JsonConvert.DeserializeObject<List<Product>>(dataapi);
            return View(dataobj.FirstOrDefault(c=>c.Id==id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateProduct(Product obj, [Bind] IFormFile imageFile)
        {
            ViewBag.LSize = Sizes();
            ViewBag.LCategory = LCategory();
            ViewBag.LSupplier = LSupplier();
            try
            {
                
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string requestURL = $"https://localhost:7001/api/Product" + $"/CreateProduct?IDCategory={obj.IDCategory}&IDSupplier={obj.IDSupplier}&IDSize={obj.Size}&Name={obj.Name}&Description={obj.Description}&Quantity={obj.Quantity}&Price={obj.Price}&Status={obj.Status}";
                var httpClient = new HttpClient(); // Tại 1 httpClient để call API
                var response = await httpClient.PutAsync($"https://localhost:7001/api/Product/UpdateProduct", content); // Lấy kết quả// ]Đọc ra string Json
                string apiData = await response.Content.ReadAsStringAsync();
                if (imageFile != null && imageFile.Length > 0) // Không null và không trống
                {
                    //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot", "themes", "img", imageFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                        imageFile.CopyTo(stream);
                    }
                    // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
                }
                Addimg(obj.Id, imageFile.FileName);
                return RedirectToAction("ProductView");
            }
            catch
            {
                return View();
            }
        }
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            string requestURL =
            $"https://localhost:7001/api/Product";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.DeleteAsync(requestURL + "/DeleteProduct?id=" + id.ToString());

            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            return RedirectToAction("ProductView");
        }
        public async Task<IActionResult> DetailsProduct(Guid id)
        {
            ViewBag.LSize = Sizes();
            ViewBag.LCategory = LCategory();
            ViewBag.LSupplier = LSupplier();
          
            ViewBag.Limg = Limg.GetApi("ProductImg");
            var respones = await httpClient.GetAsync("https://localhost:7001/api/Product");
            var dataapi = await respones.Content.ReadAsStringAsync();
            List<Product> dataobj = JsonConvert.DeserializeObject<List<Product>>(dataapi);

            return View(dataobj.FirstOrDefault(c=>c.Id==id));
        }

       
    }
}
