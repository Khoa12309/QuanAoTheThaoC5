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
        public Role Get(Guid id)
        {
            return _allrepo.GetAllItems().FirstOrDefault(c=>c.Id==id);
        }

        // POST api/<ColorController>
        [HttpPost("CreateRole")]
        public bool Create( Role obj)
        {
            Role Item = new Role();
            Item.Id = Guid.NewGuid();            
            Item.Name = obj.Name;
            return _allrepo.CreateItem(Item);
        }

        // PUT api/<ColorController>/5
        [HttpPut("UpdateRole")]
        public bool UpdateRole(Role obj)
        {
            Role Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);         
            Item.Name = obj.Name;
            return _allrepo.UpdateItem(Item);
        }

        // DELETE api/<ColorController>/5
        [HttpDelete("DeleteRole")]
        public bool Delete(Guid id)
        {
            Role Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}
