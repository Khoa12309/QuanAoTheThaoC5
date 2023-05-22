﻿using Microsoft.AspNetCore.Mvc;
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductMaterialDetailsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductMaterialDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductMaterialDetailsController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            ProductMaterialDetails Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}