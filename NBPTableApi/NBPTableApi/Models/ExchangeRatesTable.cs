using System.ComponentModel.DataAnnotations;

namespace NBPTableApi.Models
{
    public class ExchangeRatesTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Table { get; set; }
        [Required]
        public required string No { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        public required ICollection<ExchangeRate> Rates { get; set; }
    }
}
