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
    public class ColorDetailsController : ControllerBase
    {
        private readonly IAllRepositories<ColorDetails> _allrepo;
        ShoppingDbContext _context = new ShoppingDbContext();
        public ColorDetailsController()
        {
            _allrepo = new AllRepositroies<ColorDetails>(_context, _context.ColorDetails);

        }
        // GET: api/<ColorDetailsController>
        [HttpGet]
        public IEnumerable<ColorDetails> GetAllItem()
        {
            return _allrepo.GetAllItems();
        }

        // GET api/<ColorDetailsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ColorDetailsController>
        [HttpPost("create")]
        public bool Create(Guid ProductID, Guid ColorID, string Description)
        {

            ColorDetails Item = new ColorDetails();
            Item.Id = Guid.NewGuid();
            Item.ColorID = ColorID;
            Item.Description = Description;
            Item.ProductID = ProductID;
            return _allrepo.CreateItem(Item);
        }

        // PUT api/<ColorDetailsController>/5
        [HttpPost("update")]
        public bool Put(Guid id, Guid ProductID, Guid ColorID, string Description)
        {
            ColorDetails Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            Item.ProductID = ProductID;
            Item.ColorID = ColorID;
            Item.Description = Description;
            return _allrepo.UpdateItem(Item);
        }

        // DELETE api/<ColorDetailsController>/5
        [HttpDelete("delete")]
        public bool Delete(Guid id)
        {
            ColorDetails Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}
