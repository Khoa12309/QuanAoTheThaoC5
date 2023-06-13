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
    public class ProductImgController : ControllerBase
    {
        private readonly IAllRepositories<ProductImg> _allrepo;
        ShoppingDbContext _context = new ShoppingDbContext();
        public ProductImgController()
        {
            _allrepo = new AllRepositroies<ProductImg>(_context, _context.ProductImgs);
        }
        // GET: api/<ColorController>
        [HttpGet]
        public IEnumerable<ProductImg> GetAllItem()
        {
            return _allrepo.GetAllItems();
        }

        // GET api/<ColorController>/5
       
        // POST api/<ColorController>
        [HttpPost("CreateProductImg")]
        public bool Create(Guid IDProduct, string URl)

        {
            ProductImg Item = new ProductImg();
            Item.Id = Guid.NewGuid();
            Item.IDProduct = IDProduct;
            Item.URl = URl;
            return _allrepo.CreateItem(Item);
        }

        // PUT api/<ColorController>/5
        [HttpPut("UpdateProductImg")]
        public bool Put(Guid id, Guid IDProduct, string URL)
        {
            ProductImg Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            Item.IDProduct = IDProduct;
            Item.URl = URL;
            return _allrepo.UpdateItem(Item);
        }

        // DELETE api/<ColorController>/5
        [HttpDelete("DeleteImg")]
        public bool Delete(Guid id)
        {
            ProductImg Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}

