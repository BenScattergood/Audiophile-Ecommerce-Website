using AudiophileEcommerceWebsite.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudiophileEcommerceWebsite_Tests.Fixtures
{
    public static class DatabaseConnection
    {
        public static AudiophileDbContext _dbContext { get; }
        public static string idString;

        static DatabaseConnection()
        {
            if (_dbContext is null)     
            {
                var connection = new SqliteConnection("Data Source=:memory:");
                connection.Open();

                var optionsBuilder = new DbContextOptionsBuilder<AudiophileDbContext>()
                            .UseSqlite(connection);

                _dbContext = new AudiophileDbContext(optionsBuilder.Options);
                _dbContext.Database.EnsureCreated();

                idString = Guid.NewGuid().ToString();
                SeedTestData(idString);
            }
            
        }
        private static void SeedTestData(string id)
        {
            DbInitializer.Seed(_dbContext);

            var products = _dbContext.Products.Select(c => c).ToList();

            _dbContext.ShoppingBasketItems.Add(new ShoppingBasketItem()
            {
                Product = products[0],
                Quantity = 1,
                ShoppingBasketId = id,
            });
            _dbContext.ShoppingBasketItems.Add(new ShoppingBasketItem()
            {
                Product = products[2],
                Quantity = 3,
                ShoppingBasketId = id,
            });
            _dbContext.ShoppingBasketItems.Add(new ShoppingBasketItem()
            {
                Product = products[5],
                Quantity = 2,
                ShoppingBasketId = id,
            });

            _dbContext.SaveChanges();
        }

        public static void ResetDb()
        {
            _dbContext.Database.ExecuteSqlRaw($"DELETE FROM ShoppingBasketItems");
            _dbContext.Database.ExecuteSqlRaw($"DELETE FROM Orders");

            _dbContext.SaveChanges();
            SeedTestData(idString);
            Console.WriteLine();
        }
    }
}
