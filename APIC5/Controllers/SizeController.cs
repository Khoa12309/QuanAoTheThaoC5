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
    public class SizeController : ControllerBase
    {
        private readonly IAllRepositories<Size> _allrepo;
        ShoppingDbContext _context = new ShoppingDbContext();
        public SizeController()
        {
            _allrepo = new AllRepositroies<Size>(_context, _context.Sizes);
        }
        // GET: api/<SizeController>
        [HttpGet]
        public IEnumerable<Size> GetAllItem()
        {
            return _allrepo.GetAllItems();
        }

        // GET api/<SizeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SizeController>
        [HttpPost]
        public bool Create(string SizeName, string Description)
        {
            Size Item = new Size();
            Item.SizeId = Guid.NewGuid();
            Item.SizeName = SizeName;
            Item.Description = Description;
            return _allrepo.CreateItem(Item);
        }

        // PUT api/<SizeController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, string SizeName, string Description)
        {
            Size Item = _allrepo.GetAllItems().FirstOrDefault(c => c.SizeId == id);
            Item.SizeName = SizeName;
            Item.Description = Description;
            return _allrepo.UpdateItem(Item);
        }

        // DELETE api/<SizeController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            Size Item = _allrepo.GetAllItems().FirstOrDefault(c => c.SizeId == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}
