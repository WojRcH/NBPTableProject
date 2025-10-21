using NBPTableApi.Dtos;
using NBPTableApi.Models;

namespace NBPTableApi.Services
{
    public interface INBPService
    {
        Task<List<ExchangeRatesTable>> GetNBPTable();
        Task<List<ExchangeRateItemDto>> UpdateNBPTable();
        Task<List<ExchangeRateItemDto>> GetNBPTableFromDatabase();

    }
}
