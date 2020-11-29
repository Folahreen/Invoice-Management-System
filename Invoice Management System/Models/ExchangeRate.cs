using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Management_System.Models
{
    public class ExchangeRate
    {
        [Key]
        public int ExchangeRateId { get; set; }

        [Required]
        [DisplayName("Exchange Rate Amount")]
        public decimal ExchangeRateAmount { get; set; }

        [Required]
        [DisplayName("Exchange Rate")]
        public string ExchangeRates { get; set; }
    }
}
