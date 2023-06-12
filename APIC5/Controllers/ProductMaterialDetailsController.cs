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
    public class ProductMaterialDetailsController : ControllerBase
    {
        private readonly IAllRepositories<ProductMaterialDetails> _allrepo;
        ShoppingDbContext _context = new ShoppingDbContext();
        public ProductMaterialDetailsController()
        {
            _allrepo = new AllRepositroies<ProductMaterialDetails>(_context, _context.ProductMaterialDetails);
        }
        // GET: api/<ProductMaterialDetailsController>
        [HttpGet]
        public IEnumerable<ProductMaterialDetails> GetAllItem()
        {
            return _allrepo.GetAllItems();
        }

        // GET api/<ProductMaterialDetailsController>/5
        [HttpGet("{id}")]
        public ProductMaterialDetails Get(Guid id)
        {
            return _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
        }
        // POST api/<ProductMaterialDetailsController>
        [HttpPost("CreateProductMaterialDetails")]
        public bool Create(ProductMaterialDetails item)
        {
           
            ProductMaterialDetails Item = new ProductMaterialDetails();
            Item.Id = item.Id;
            Item.Description = item.Description;
            Item.IDProduct = item.IDProduct;
            Item.IDProductMaterial = item.IDProductMaterial;
            return _allrepo.CreateItem(Item);
        }

        // PUT api/<ProductMaterialDetailsController>/5
        [HttpPut("UpdateProductMaterialDetails")]
        public bool Post(ProductMaterialDetails item)
        {
            ProductMaterialDetails Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == item.Id);

            Item.Description = item.Description;
            Item.IDProduct = item.IDProduct;
            Item.IDProductMaterial = item.IDProductMaterial;

            return _allrepo.UpdateItem(Item);
            //
        }

        // DELETE api/<ProductMaterialDetailsController>/5
        [HttpDelete("DeleteProductMaterialDetails")]
        public bool Delete(Guid id)
        {
            ProductMaterialDetails Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}
