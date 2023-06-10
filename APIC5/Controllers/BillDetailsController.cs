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
    public class BillDetailsController : ControllerBase
    {
        private readonly IAllRepositories<BillDetails> _allrepo;
        private readonly IAllRepositories<Product> _prod;
        ShoppingDbContext _context = new ShoppingDbContext();
        public BillDetailsController()
        {
            _allrepo = new AllRepositroies<BillDetails>(_context, _context.BillDetails);
            _prod= new AllRepositroies<Product>(_context, _context.Products);
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<BillDetails> GetAllItem()
        {
            return _allrepo.GetAllItems();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public bool Create(Guid IDBill, Guid IDProduct, int Amount)
        {
            Product product =_prod.GetAllItems().FirstOrDefault(c=>c.Id==IDProduct);
            BillDetails billDetails = _allrepo.GetAllItems().FirstOrDefault(c => c.IDProduct == product.Id && c.IDBill == IDBill);

            if (product.Quantity<Amount+billDetails.Amount)
            {
                return false;
            }
            BillDetails Item = new BillDetails();
            Item.ID = Guid.NewGuid();
            Item.IDBill = IDBill;
            Item.IDProduct = IDProduct;
            Item.Price = product.Price;          
            Item.Amount = Amount;
            product.Quantity-=Amount;
            if (_allrepo.GetAllItems().Any(c=>c.IDProduct==product.Id&&c.IDBill==IDBill))
            {
               
                billDetails.Amount+=Amount;                
                _prod.UpdateItem(product);
                return _allrepo.UpdateItem(billDetails);
            }
            _prod.UpdateItem(product);
            return _allrepo.CreateItem(Item);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id,int Amount)
        {
            BillDetails Item = _allrepo.GetAllItems().FirstOrDefault(c => c.ID == id);
            Product product = _prod.GetAllItems().FirstOrDefault(c => c.Id == Item.IDProduct);
            if (product.Quantity < Amount)
            {
                return false;
            }
            Item.Amount = Amount;
            product.Quantity -= Amount;
            _prod.UpdateItem(product);
            return _allrepo.UpdateItem(Item);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            BillDetails Item = _allrepo.GetAllItems().FirstOrDefault(c => c.ID == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}
