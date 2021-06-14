using System;

namespace TinyJewelInfrastructure.Model
{
    public class CustomerEntity
    {

        public string Username { get; set; }
        public string CustomerType { get; set; }
        public string PasswordHash { get; set; }
        public double Discount { get; set; }

    }
}
