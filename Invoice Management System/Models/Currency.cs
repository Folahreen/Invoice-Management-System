using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Management_System.Models
{
    public class Currency
    {
        public int CurrencyId { get; set; }

        [DisplayName("Curreny Name")]
        [Required]
        public string CurrencyName { get; set; }

        [DisplayName("Curreny Code")]
        [Required]
        public string CurrencyCode { get; set; }
    }
}
