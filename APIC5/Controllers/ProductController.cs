using Microsoft.AspNetCore.Mvc;
using QuanAoTheThaoC5.ContextDataBase;
using QuanAoTheThaoC5.IRepositories;
using QuanAoTheThaoC5.Models;
using QuanAoTheThaoC5.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIC5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IAllRepositories<Product> _allrepo;
        ShoppingDbContext _context = new ShoppingDbContext();
        public ProductController()
        {
            _allrepo = new AllRepositroies<Product>(_context, _context.Products);

        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> GetAllItem()
        {
            return _allrepo.GetAllItems();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var products = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return Ok();
        }

        // POST api/<ProductController>
        [HttpPost]
        public bool Create(Guid IDCategory, Guid IDSupplier, Guid IDSize, string Name, string Description, int Quantity, double Price, int Status)
        {

            Product Item = new Product();
            Item.Id = Guid.NewGuid();
            Item.IDCategory = IDCategory;
            Item.IDSupplier = IDSupplier;
            Item.IDSize = IDSize;
            Item.Description=Description;
            Item.Price=Price;
            Item.Status=Status;
            Item.Quantity=Quantity;
            Item.Name = Name;
            return _allrepo.CreateItem(Item);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, Guid IDCategory, Guid IDSupplier, Guid IDSize, string Name, string Description, int Quantity, double Price, int Status)
        {
            Product Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            Item.IDCategory = IDCategory;
            Item.IDSupplier = IDSupplier;
            Item.IDSize = IDSize;
            Item.Description = Description;
            Item.Price = Price;
            Item.Status = Status;
            Item.Quantity = Quantity;
            Item.Name = Name;
            return _allrepo.UpdateItem(Item);
        }


        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            Product Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}
