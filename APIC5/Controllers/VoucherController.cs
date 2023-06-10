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
       

        // POST api/<Voucher>
        [HttpPost("create-item")]
        public bool CreateVoucher(Voucher obj)
        {
            Voucher voucher = new Voucher();
            voucher.Id = Guid.NewGuid();
            voucher.VoucherCode = obj.VoucherCode;
            voucher.Name = obj.Name;
            voucher.Description = obj.Description;
            voucher.Status = obj.Status;
            voucher.CreateDate = obj.CreateDate;
            voucher.StartDate = obj.StartDate;
            voucher.EndDate = obj.EndDate;
            voucher.DiscountValue = obj.DiscountValue;
            return _allrepo.CreateItem(voucher);
        }

        // PUT api/<Voucher>/5
        [HttpPut("put-item")]
        public bool Put(Voucher obj)
        {
            Voucher voucher = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);


            voucher.VoucherCode = obj.VoucherCode;
            voucher.Name = obj.Name;
            voucher.Description = obj.Description;
            voucher.Status = obj.Status;
            voucher.CreateDate = obj.CreateDate;
            voucher.StartDate = obj.StartDate;
            voucher.EndDate = obj.EndDate;
            voucher.DiscountValue = obj.DiscountValue;
            return _allrepo.UpdateItem(voucher);
        }

        // DELETE api/<Voucher>/5
        [HttpDelete("delete-item")]
        public bool Delete(Guid id)
        {
            Voucher voucher = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _allrepo.DeleteItem(voucher);
        }
    }
}
