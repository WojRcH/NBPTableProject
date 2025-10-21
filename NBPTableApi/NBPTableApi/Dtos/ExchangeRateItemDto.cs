namespace NBPTableApi.Dtos
{
    public class ExchangeRateItemDto
    {
        public required string Code { get; set; }
        public required string Currency { get; set; }
        public decimal Mid { get; set; }
    }
}
