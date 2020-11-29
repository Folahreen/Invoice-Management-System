using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Management_System.Models.ViewModel
{
    public class InvoiceViewModel
    {
        public IEnumerable<Currency> CurrencyList { get; set; }
        public IEnumerable<ExchangeRate> ExchangeList { get; set; }
        public IEnumerable<Clients> ClientList { get; set; }
        public InvoiceModel Invoice { get; set; }
    }
}
