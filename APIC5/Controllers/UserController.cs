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
    public class UserController : ControllerBase
    {
        private readonly IAllRepositories<User> _allrepo;
        ShoppingDbContext _context = new ShoppingDbContext();
        public UserController()
        {
            _allrepo = new AllRepositroies<User>(_context, _context.User);
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> GetAllItem()
        {
            return _allrepo.GetAllItems();
        }

        // GET api/<UserController>/5
    

        // POST api/<UserController>
        [HttpPost("createUser")]
        public bool CreateUser(User obj)
        {
            
            User Item = new User();
            Item.Id = Guid.NewGuid();
            Item.Name = obj.Name;
            Item.Email = obj.Email;
            Item.Address = obj.Address;
            Item.Password = obj.Password;
            Item.PhoneNumber = obj.PhoneNumber;
            Item.Status = obj.Status;
            Item.IDRole = obj.IDRole;
            return _allrepo.CreateItem(Item);
        }

        // PUT api/<UserController>/5
        [HttpPut("UpdateUser")]
        public bool Update(User obj)
        {

            User Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);           
            Item.Name = obj.Name;
            Item.Email = obj.Email;
            Item.Address = obj.Address;
            Item.Password = obj.Password;
            Item.PhoneNumber = obj.PhoneNumber;
            Item.Status = obj.Status;
            Item.IDRole = obj.IDRole;
            return _allrepo.UpdateItem(Item);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("deleteUser")]
        public bool Delete(Guid id)
        {
            User Item = _allrepo.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _allrepo.DeleteItem(Item);
        }
    }
}
