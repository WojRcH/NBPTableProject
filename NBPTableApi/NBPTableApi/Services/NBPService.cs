using Microsoft.EntityFrameworkCore;
using NBPTableApi.AppDbContext;
using NBPTableApi.Dtos;
using NBPTableApi.Models;

namespace NBPTableApi.Services
{
    public class NBPService : INBPService
    {
        private readonly AppDbContextSqlite dbContext;
        private readonly HttpClient httpClient;
        private const string NbpApiUrl = "https://api.nbp.pl/api/exchangerates/tables/b/?format=json";

        public NBPService(AppDbContextSqlite dbContext, HttpClient httpClient) 
        {
            this.dbContext = dbContext;
            this.httpClient = httpClient;
        }

        public async Task<List<ExchangeRatesTable>> GetNBPTable()
        {
            var tables = await httpClient.GetFromJsonAsync<List<ExchangeRatesTable>>(NbpApiUrl) 
                ?? throw new Exception("Not found data from NBP");

            return tables;
        }

        public async Task<List<ExchangeRateItemDto>> UpdateNBPTable()
        {
            var tables = await httpClient.GetFromJsonAsync<List<ExchangeRatesTable>>(NbpApiUrl)
                ?? throw new Exception("Not found data from NBP");

            foreach (var table in tables)
            {
                var existing = dbContext.ExchangeRatesTableItems
                                .Include(t => t.Rates)
                                .FirstOrDefault(t => t.EffectiveDate == table.EffectiveDate);

                if (existing != null)
                    dbContext.ExchangeRatesTableItems.Remove(existing);
            }

            dbContext.ExchangeRatesTableItems.AddRange(tables);
            await dbContext.SaveChangesAsync();

            var result = tables.SelectMany(t => t.Rates)
                .Select(r => new ExchangeRateItemDto
                {
                    Code = r.Code,
                    Currency = r.Currency,
                    Mid = r.Mid
                })
                .ToList();

            return result;
        }

        public async Task<List<ExchangeRateItemDto>> GetNBPTableFromDatabase()
        {
            var rates = await dbContext.ExchangeRateItems
                .ToListAsync();

            return rates.Select(r => new ExchangeRateItemDto
            {
                Code = r.Code,
                Currency = r.Currency,
                Mid = r.Mid
            }).ToList();
        }
    }
}
