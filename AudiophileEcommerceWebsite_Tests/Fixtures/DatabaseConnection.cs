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

        static DatabaseConnection()
        {
            //check if enters...
            if (_dbContext is null)
            {
                var connection = new SqliteConnection("Data Source=:memory:");
                connection.Open();

                var optionsBuilder = new DbContextOptionsBuilder<AudiophileDbContext>()
                            .UseSqlite(connection);

                _dbContext = new AudiophileDbContext(optionsBuilder.Options);
                _dbContext.Database.EnsureCreated();
            }
        }
    }
}
