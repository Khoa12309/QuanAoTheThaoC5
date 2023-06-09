﻿using Microsoft.EntityFrameworkCore;
using QuanAoTheThaoC5.Models;
using System.Reflection;

namespace QuanAoTheThaoC5.ContextDataBase
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext() { }
        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-N6FK027M;Initial Catalog=QuanAoC5;Persist Security Info=True;User ID=khoaph20877;Password=123456");           

             

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetails> BillDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ProductImg> ProductImgs { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ColorDetails> ColorDetails { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }
        public DbSet<ProductMaterialDetails> ProductMaterialDetails { get; set; }

      
    }
}
