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
    public class BillController : ControllerBase
    {
        private readonly IAllRepositories<Bill> _allrepo;
        ShoppingDbContext _context = new ShoppingDbContext();
        public BillController()
        {
            _allrepo = new AllRepositroies<Bill>(_context, _context.Bills);
        }
        // GET: api/<BillController>
        [HttpGet]
        public IEnumerable<Bill> GetAllItem()
        {
            return _allrepo.GetAllItems();
        }

        // GET api/<BillController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BillController>
        [HttpPost]
        public bool Create(Guid IDUser, Guid IDVoucher, DateTime CreateDate, int Status, double TotalMoney, double TransportFee, string PhoneNumber, string Address)
        {
            Bill Item = new Bill();
            Item.Id = Guid.NewGuid();
            Item.IDUser = IDUser;
            Item.IDVoucher = IDVoucher;
            Item.Status = Status;
            Item.TotalMoney = TotalMoney;
            Item.TransportFee = TransportFee;
            Item.PhoneNumber = PhoneNumber;
            Item.Address = Address;
            Item.CreateDate = CreateDate;
            return _allrepo.CreateItem(Item);
        }

        // PUT api/<BillController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, Guid IDUser, Guid IDVoucher, DateTime CreateDate, int Status, double TotalMoney, double TransportFee, string PhoneNumber, string Address)
        {
            Bill Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            Item.IDUser = IDUser;
            Item.IDVoucher = IDVoucher;
            Item.Status = Status;
            Item.TotalMoney = TotalMoney;
            Item.TransportFee = TransportFee;
            Item.PhoneNumber = PhoneNumber;
            Item.Address = Address;
            Item.CreateDate = CreateDate;
            return _allrepo.UpdateItem(Item);
        }

        // DELETE api/<BillController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            Bill Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}
