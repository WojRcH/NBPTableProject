using NBPTableApi.Models;

namespace NBPTableApi.Services
{
    public interface INBPService
    {
        Task<List<ExchangeRatesTable>> GetNBPTable();
    }
}
