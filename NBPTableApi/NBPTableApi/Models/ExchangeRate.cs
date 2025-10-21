using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBPTableApi.Models
{
    public class ExchangeRate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Currency { get; set; }

        [Required]
        public required string Code { get; set; }

        [Required]
        public decimal Mid { get; set; }

        public int ExchangeRatesTableId { get; set; }

        [ForeignKey("ExchangeRatesTableId")]
        public ExchangeRatesTable ExchangeRatesTable { get; set; }
    }
}
