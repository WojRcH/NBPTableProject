using NBPTableApi.Models;

namespace NBPTableApi.Services
{
    public interface INBPService
    {
        Task<List<ExchangeRatesTable>> GetNBPTable();
        Task<List<ExchangeRatesTable>> UpdateNBPTable();

    }
}
