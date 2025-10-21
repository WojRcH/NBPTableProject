using NBPTableApi.AppDbContext;
using NBPTableApi.Models;

namespace NBPTableApi.Services
{
    public class NBPService : INBPService
    {
        private readonly AppDbContextSqlite dbContext;
        private readonly HttpClient httpClient;

        public NBPService(AppDbContextSqlite dbContext, HttpClient httpClient) 
        {
            this.dbContext = dbContext;
            this.httpClient = httpClient;
        }

        public async Task<List<ExchangeRatesTable>> GetNBPTable()
        {
            var url = "https://api.nbp.pl/api/exchangerates/tables/b/?format=json";
            var tables = await httpClient.GetFromJsonAsync<List<ExchangeRatesTable>>(url);
            return tables ?? new List<ExchangeRatesTable>();
        }
    }
}
