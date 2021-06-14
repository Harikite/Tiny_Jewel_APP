using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyJewelInfrastructure.Model;

namespace TinyJewelInfrastructure.DataAccess
{
    public class CustomerDBContext : DbContext
    {
            public DbSet<CustomerEntity> Customers { get; set; }

            public DbSet<CustomerTypeEntity> CustomerTypes { get; set; }

        public CustomerDBContext(DbContextOptions options) : base(options)
        {
        }

        //public void LoadCustomers()
        //{
        //    CustomerEntity customers = new() { Username = "Test", PasswordHash = "VGVzdEAxMjM=", CustomerType = "1" };
        //    Customers.Add(customers);
        //    customers = new () { Username = "Test1", PasswordHash = "VGVzdEAxMjM0", CustomerType = "2" };
        //    Customers.Add(customers);

        //    CustomerTypeEntity customerTypeEntity = new (){ CustomerTypeID = "1", Discount = 2, CustomerTypeName = "Premium" };
        //    CustomerTypes.Add(customerTypeEntity);
        //    customerTypeEntity = new() { CustomerTypeID = "2", Discount = 0, CustomerTypeName = "Normal" };
        //    CustomerTypes.Add(customerTypeEntity);
        //}

        //public List<CustomerEntity> GetCustomers()
        //{
        //    return Customers.Local.ToList<CustomerEntity>();
        //}

        //public List<CustomerTypeEntity> GetCustomersTypes()
        //{
        //    return CustomerTypes.Local.ToList<CustomerTypeEntity>();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerEntity>()
                .HasKey(e => e.Username);

            modelBuilder.Entity<CustomerEntity>().Property(e => e.Username) .HasMaxLength(50);
                
            modelBuilder.Entity<CustomerEntity>().Property(b => b.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<CustomerTypeEntity>()
               .HasKey(e => e.CustomerTypeID);

        }

    }
}
