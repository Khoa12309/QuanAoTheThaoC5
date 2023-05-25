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
    public class UserController : ControllerBase
    {
        private readonly IAllRepositories<User> _allrepo;
        ShoppingDbContext _context = new ShoppingDbContext();
        public UserController()
        {
            _allrepo = new AllRepositroies<User>(_context, _context.User);
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> GetAllItem()
        {
            return _allrepo.GetAllItems();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public bool Create(Guid IDRole, string Name, string Email, string Address, string Password, string PhoneNumber, int Status)
        {
            
        User Item = new User();
            Item.Id = Guid.NewGuid();
            Item.Name = Name;
            Item.Email = Email;
            Item.Address = Address;
            Item.Password = Password;
            Item.PhoneNumber = PhoneNumber;
            Item.Status = Status;
            return _allrepo.CreateItem(Item);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public bool Update(Guid id,Guid IDRole, string Name, string Email, string Address, string Password, string PhoneNumber, int Status)
        {

            User Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            
            Item.Name = Name;
            Item.Email = Email;
            Item.Address = Address;
            Item.Password = Password;
            Item.PhoneNumber = PhoneNumber;
            Item.Status = Status;
            return _allrepo.UpdateItem(Item);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            User Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}
