using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanAoTheThaoC5.ContextDataBase;
using QuanAoTheThaoC5.IRepositories;
using QuanAoTheThaoC5.Models;
using QuanAoTheThaoC5.Repositories;

namespace APIC5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IAllRepositories<Cart> _allrepo;
        ShoppingDbContext _context = new ShoppingDbContext();
        public CartController()
        {
            _allrepo = new AllRepositroies<ProductImg>(_context, _context.Carts);
        }
        // GET: api/<ColorController>
        [HttpGet]
        public IEnumerable<Cart> GetAllItem()
        {
            return _allrepo.GetAllItems();
        }

        // GET api/<ColorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ColorController>
        [HttpPost]
        public bool Create(Guid User_ID, int Status)
        {
            Cart Item = new Cart();
            Item.Id = Guid.NewGuid();
            Item.User_ID = User_ID;
            Item.Status = Status;
            return _allrepo.CreateItem(Item);
        }

        // PUT api/<ColorController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, Guid User_ID, int Status)
        {
            Cart Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            Item.User_ID = User_ID;
            Item.Status = Status;
            return _allrepo.UpdateItem(Item);
        }

        // DELETE api/<ColorController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            Cart Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}
