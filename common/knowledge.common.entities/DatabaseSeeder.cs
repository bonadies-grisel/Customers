#region Usings
using Microsoft.EntityFrameworkCore;
using knowledge.common.entities.Types; 
#endregion

namespace knowledge.common.entities
{
    public class DatabaseSeeder
    {
        #region Customer Seeding
        public static void SeedCustomer(ModelBuilder modelBuilder)
        {
            for (int i = 1; i <= 10; i++)
            {
                Customer seedCustomer = new Customer()
                {
                    Id = i,
                    Names = $"Name{i}",
                    Surnames = $"Surname{i}",
                    BirthDate = new DateOnly(1994,11,25).AddYears(-i),
                    CUIT = "20-37978110-2",
                    Address = $"Address{i}",
                    CellphoneNumber = "1160166647",
                    Email = $"customer.email{i}@email.com",
                    Active = true
                };

                modelBuilder.Entity<Customer>().HasData(
                    seedCustomer
                );
            }
        }
        #endregion       
    }
}
