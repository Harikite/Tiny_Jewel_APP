using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyJewelInfrastructure.DataAccess;
using TinyJewelInfrastructure.Model;

namespace TinyJewelCore.Utility
{
    public class DataFeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CustomerDBContext(
            serviceProvider.GetRequiredService<DbContextOptions<CustomerDBContext>>()))
            {
                // Look for any board games.
                if (context.Customers.Any())
                {
                    return;   // Data was already seeded
                }

                context.Customers.AddRange(
                new() { Username = "Test", PasswordHash = "VGVzdEAxMjM=", CustomerType = "1" },

                new() { Username = "Test1", PasswordHash = "VGVzdEAxMjM0", CustomerType = "2" }
                );

                context.CustomerTypes.AddRange(
                 new() { CustomerTypeID = "1", Discount = 0, CustomerTypeName = "Normal" },
                new() { CustomerTypeID = "2", Discount = 2, CustomerTypeName = "Previllage" });
                


                context.SaveChanges();
            }
        }
    }
}
