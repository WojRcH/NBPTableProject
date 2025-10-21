using Microsoft.EntityFrameworkCore;
using NBPTableApi.Models;
namespace NBPTableApi.AppDbContext
{   
    public class AppDbContextSqlite : DbContext
    {
        public DbSet<ExchangeRatesTable> ExchangeRatesTableItems { get; set; }
        public DbSet<ExchangeRate> ExchangeRateItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=NBPTableProjectDatabase.db");
    }

}
