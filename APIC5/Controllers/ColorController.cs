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
    public class ColorController : ControllerBase
    {
        private readonly IAllRepositories<Color> _allrepo;
        ShoppingDbContext _context = new ShoppingDbContext();
        public ColorController()
        {
            _allrepo = new AllRepositroies<Color>(_context, _context.Colors);
        }
        // GET: api/<ColorController>
        [HttpGet]
        public IEnumerable<Color> GetAllItem()
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
        public bool Create(string ColerCode, string Name)
        {
            Color Item = new Color();
            Item.Id = Guid.NewGuid();
            Item.ColerCode = ColerCode;
            Item.Name = Name;
            return _allrepo.CreateItem(Item);
        }

        // PUT api/<ColorController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, string ColerCode, string Name)
        {
            Color Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            Item.ColerCode = ColerCode;
            Item.Name = Name;
            return _allrepo.UpdateItem(Item);
        }

        // DELETE api/<ColorController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            Color Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}
