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
    public class SupplierController : ControllerBase
    {
        private readonly IAllRepositories<Supplier> _allrepo;
        ShoppingDbContext _context = new ShoppingDbContext();
        public SupplierController()
        {
            _allrepo = new AllRepositroies<Supplier>(_context, _context.Suppliers);
        }
        // GET: api/<SupplierController>
        [HttpGet]
        public IEnumerable<Supplier> GetAllItem()
        {
            return _allrepo.GetAllItems();
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SupplierController>
        [HttpPost]
        public bool Create(string SupllierCode, string SupplierName, string PhoneNumber, string Address, string Descripton)
        {
            Supplier Item = new Supplier();
            Item.Id = Guid.NewGuid();
            Item.SupllierCode = SupllierCode;
            Item.SupplierName = SupplierName;
            Item.PhoneNumber = PhoneNumber;
            Item.Address = Address;
            Item.Descripton = Descripton;
            return _allrepo.CreateItem(Item);
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, string SupllierCode, string SupplierName, string PhoneNumber, string Address, string Descripton)
        {
            Supplier Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            Item.SupllierCode = SupllierCode;
            Item.SupplierName = SupplierName;
            Item.PhoneNumber = PhoneNumber;
            Item.Address = Address;
            Item.Descripton = Descripton;
            return _allrepo.UpdateItem(Item);
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            Supplier Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}
