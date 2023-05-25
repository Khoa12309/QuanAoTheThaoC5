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
    public class ProductMaterialController : ControllerBase
    {
        private readonly IAllRepositories<ProductMaterial> _allrepo;
        ShoppingDbContext _context = new ShoppingDbContext();
        public ProductMaterialController()
        {
            _allrepo = new AllRepositroies<ProductMaterial>(_context, _context.ProductMaterials);

        }
        // GET: api/<ProductMaterialController>
        [HttpGet]
        public IEnumerable<ProductMaterial> GetAllItem()
        {
            return _allrepo.GetAllItems();
        }

        // GET api/<ProductMaterialController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductMaterialController>
        [HttpPost]
        public bool Create(string name)
        {
            ProductMaterial Item = new ProductMaterial();
            Item.Id = Guid.NewGuid();
            Item.Name = name;
            return _allrepo.CreateItem(Item);
        }

        // PUT api/<ProductMaterialController>/5
        [HttpPut("{id}")]
        public bool Update(Guid id,string name)
        {
            ProductMaterial Item= _allrepo.GetAllItems().FirstOrDefault(c=>c.Id==id);
            Item.Name=name;
            return _allrepo.UpdateItem(Item);
        }

        // DELETE api/<ProductMaterialController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            ProductMaterial Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}
