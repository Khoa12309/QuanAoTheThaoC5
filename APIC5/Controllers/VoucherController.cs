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
    public class VoucherController : ControllerBase
    {
        private readonly IAllRepositories<Voucher> _allrepo;
        ShoppingDbContext _context = new ShoppingDbContext();
        public VoucherController()
        {
            _allrepo = new AllRepositroies<Voucher>(_context, _context.Vouchers);
        }
        // GET: api/<Voucher>
        [HttpGet]
        public IEnumerable<Voucher> GetAllItem()
        {
            return _allrepo.GetAllItems();
        }

        // GET api/<Voucher>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Voucher>
        [HttpPost("create-item")]


        public bool Create(string Name, string VoucherCode, string Description, int Status, DateTime CreateDate, DateTime StartDate, DateTime EndDate, int DiscountValue)
        {
            Voucher voucher = new Voucher();
            voucher.Id = Guid.NewGuid();
            voucher.VoucherCode = VoucherCode;
            voucher.Name = Name;
            voucher.Description = Description;
            voucher.Status = Status;
            voucher.CreateDate = CreateDate;
            voucher.StartDate = StartDate;
            voucher.EndDate = EndDate;
            voucher.DiscountValue = DiscountValue;
            return _allrepo.CreateItem(voucher);
        }

        // PUT api/<Voucher>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, string Name, string VoucherCode, string Description, int Status, DateTime CreateDate, DateTime StartDate, DateTime EndDate, int DiscountValue)
        {
            Voucher voucher = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);


            voucher.VoucherCode = VoucherCode;
            voucher.Name = Name;
            voucher.Description = Description;
            voucher.Status = Status;
            voucher.CreateDate = CreateDate;
            voucher.StartDate = StartDate;
            voucher.EndDate = EndDate;
            voucher.DiscountValue = DiscountValue;
            return _allrepo.UpdateItem(voucher);
        }

        // DELETE api/<Voucher>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            Voucher voucher = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _allrepo.DeleteItem(voucher);
        }
    }
}
