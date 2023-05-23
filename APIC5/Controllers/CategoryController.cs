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
    public class CategoryController : ControllerBase
    {
        private readonly IAllRepositories<Category> _allrepo;
        ShoppingDbContext _context = new ShoppingDbContext();
        public CategoryController()
        {
            _allrepo = new AllRepositroies<Category>(_context, _context.Categories);
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> GetAllItem()
        {
            return _allrepo.GetAllItems();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryController>
        [HttpPost]
        public bool Create(string CategoryName, string Description)
        {
            Category Item = new Category();
            Item.CategoryId = Guid.NewGuid();
            Item.CategoryName = CategoryName;
            Item.Description = Description;
            return _allrepo.CreateItem(Item);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, string CategoryName, string Description)
        {
            Category Item = _allrepo.GetAllItems().FirstOrDefault(c => c.CategoryId == id);
            Item.CategoryName = CategoryName;
            Item.Description = Description;
            return _allrepo.UpdateItem(Item);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            Category Item = _allrepo.GetAllItems().FirstOrDefault(c => c.CategoryId == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}
