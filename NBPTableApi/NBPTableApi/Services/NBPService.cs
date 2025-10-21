using NBPTableApi.AppDbContext;
using NBPTableApi.Models;
using System.Net.Http;

namespace NBPTableApi.Services
{
    public class NBPService : INBPService
    {
        private readonly AppDbContextSqlite dbContext;
        private readonly HttpClient httpClient;

        public NBPService(AppDbContextSqlite dbContext, HttpClient httpClient) 
        {
            this.dbContext = new AppDbContextSqlite();
            this.httpClient = httpClient;
        }

        public string GetNBPTable()
        {
            return "";
        }
    }
}
