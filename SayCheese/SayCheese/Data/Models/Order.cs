using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayCheese.Data.Models
{
    public class Order
    {
        
        public int OrderId { get; set; }

        public List<OrderDetails> OrderLines { get; set; }
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
       
        public string AddressLine1 { get; set; }
       
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }
       
        public string State { get; set; }

        public string PhoneNumber { get; set; }
        
        public decimal OrderTotal { get; set; }
        
        public DateTime OrderPlaced { get; set; }
    }
}
