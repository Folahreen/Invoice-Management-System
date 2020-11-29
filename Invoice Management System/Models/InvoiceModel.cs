using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Management_System.Models
{
    public class InvoiceModel
    {
        [Key]
        [DisplayName("Invoice Number")]
        public int InvoiceId { get; set; }

        [DisplayName("Invoice Description")]
        public string InvoiceDescription { get; set; }

        [DisplayName("Invoice Amount")]
        public decimal InvoiceAmount { get; set; }

        [DisplayName("Invoice Date")]
        public DateTime InvoiceDate { get; set; }

        [DisplayName("Delivery Date")]
        public DateTime DeliveryDate { get; set; }

        [DisplayName("Settle Date")]
        public DateTime SettleDate { get; set; }

        public string VAT { get; set; }

        [DisplayName("Curreny")]
        public int CurrencyId { get; set; }

        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }

        [DisplayName("Exchange Rate")]
        public int ExchangeRateId { get; set; }

        [ForeignKey("ExchangeRateId")]
        public ExchangeRate ExchangeRate { get; set; }

        [DisplayName("Client")]
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Clients Client { get; set; }

        [DisplayName("Order Number")]
        public string OrderNumber { get; set; }

        [DisplayName("Sales Agent")]
        public string SalesAgent { get; set; }
    }
}
