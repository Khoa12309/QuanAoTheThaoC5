﻿namespace QuanAoTheThaoC5.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid IDRole { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Status { get; set; }

        public virtual Role? Roles { get; set; }
    }
}
