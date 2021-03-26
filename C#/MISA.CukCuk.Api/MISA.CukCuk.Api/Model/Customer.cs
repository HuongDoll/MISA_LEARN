using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Model
{
    public class Customer
    {
        public Guid CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string FullName { get; set; }
        public int? Gender { get; set; }
        public string Address { get; set; }
    }
}
