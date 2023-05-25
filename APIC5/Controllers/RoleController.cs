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
    public class RoleController : ControllerBase
    {
        private readonly IAllRepositories<Role> _allrepo;
        ShoppingDbContext _context = new ShoppingDbContext();
        public RoleController()
        {
            _allrepo = new AllRepositroies<Role>(_context, _context.Roles);
        }
        // GET: api/<ColorController>
        [HttpGet]
        public IEnumerable<Role> GetAllItem()
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
        public bool Create( string Name)
        {
            Role Item = new Role();
            Item.Id = Guid.NewGuid();
            
            Item.Name = Name;
            return _allrepo.CreateItem(Item);
        }

        // PUT api/<ColorController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, string Name)
        {
            Role Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
         
            Item.Name = Name;
            return _allrepo.UpdateItem(Item);
        }

        // DELETE api/<ColorController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            Role Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}
