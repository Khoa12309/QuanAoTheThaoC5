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
    public class CartDetailsController : ControllerBase
    {
        private readonly IAllRepositories<CartDetails> _allrepo;
        ShoppingDbContext _context = new ShoppingDbContext();
        public CartDetailsController()
        {
            _allrepo = new AllRepositroies<CartDetails>(_context, _context.CartDetails);
        }
        // GET: api/<ColorController>
        [HttpGet]
        public IEnumerable<CartDetails> GetAllItem()
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
        public bool Create(Guid id ,Guid Product_ID, Guid Cart_ID, int Status, int Quantity)
        {
            CartDetails Item = new CartDetails();
            Item.Id = id;
            Item.Product_ID = Product_ID;
            Item.Cart_ID = Cart_ID;
            Item.Quantity=Quantity;
            return _allrepo.CreateItem(Item);
        }

        // PUT api/<ColorController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, Guid Product_ID, Guid Cart_ID, int Status, int Quantity)
        {
            CartDetails Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            Item.Product_ID = Product_ID;
            Item.Cart_ID = Cart_ID;
            Item.Quantity = Quantity;
            return _allrepo.UpdateItem(Item);
        }

        // DELETE api/<ColorController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            CartDetails Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}