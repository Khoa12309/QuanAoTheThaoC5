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



        // POST api/<ProductController>
        [HttpPost("CreateProduct")]
        public bool Createsp(Product obj)
        {
            Product Item = new Product();
            Item.Id =obj.Id;
            Item.IDCategory = obj.IDCategory;
            Item.IDSupplier = obj.IDSupplier;
            Item.IDSize = obj.IDSize;
            Item.Description = obj.Description;
            Item.Price = obj.Price;
            Item.Status = obj.Status;
            Item.Quantity = obj.Quantity;
            Item.Name = obj.Name;
            return _allrepo.CreateItem(Item);
        }

        // PUT api/<ProductController>/5
        [HttpPut("UpdateProduct")]
        public bool Put(Product obj)
        {            
            Product Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            Item.IDCategory = obj.IDCategory;
            Item.IDSupplier = obj.IDSupplier;
            Item.IDSize = obj.IDSize;
            Item.Description = obj.Description;
            Item.Price = obj.Price;
            Item.Status = obj.Status;
            Item.Quantity = obj.Quantity;
            Item.Name = obj.Name;
            return _allrepo.UpdateItem(Item);
        }


        // DELETE api/<ProductController>/5
        [HttpDelete("DeleteProduct")]
        public bool Delete(Guid id)
        {
            Product Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}
