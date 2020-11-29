using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Management_System.Models
{
    public class Clients
    {
        [Key]
        public int ClientId { get; set; }
        
        [Required]
        [DisplayName("Client Name")]
        public string ClientName { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
