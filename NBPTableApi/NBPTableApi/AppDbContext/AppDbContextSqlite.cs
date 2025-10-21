using Microsoft.EntityFrameworkCore;
using NBPTableApi.Models;

namespace NBPTableApi.AppDbContext
{   
    public class AppDbContextSqlite : DbContext
    {
        public AppDbContextSqlite(DbContextOptions<AppDbContextSqlite> options) : base(options){}

        public DbSet<ExchangeRatesTable> ExchangeRatesTableItems { get; set; }
        public DbSet<ExchangeRate> ExchangeRateItems { get; set; }
    }
}
