using AudiophileEcommerceWebsite.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        private static readonly object _lock = new object();
        private static bool _databaseInitialized = false;
        public static byte[] idBytes;

        static DatabaseConnection()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    if (_dbContext is null)     
                    {
                        var connection = new SqliteConnection("Data Source=:memory:");
                        connection.Open();

                        var optionsBuilder = new DbContextOptionsBuilder<AudiophileDbContext>()
                                  .UseSqlite(connection);

                        _dbContext = new AudiophileDbContext(optionsBuilder.Options);
                        _dbContext.Database.EnsureCreated();

                        string idString = Guid.NewGuid().ToString();
                        idBytes = Encoding.UTF8.GetBytes(idString);
                        SeedTestData(idString);
                    }

                    _databaseInitialized = true;
                }
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
    }
}
