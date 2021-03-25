using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Cukcuk.WebApi.Entity
{
    public class Person
    {
        public Guid CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string FullName { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid CustomerGroupId { get; set; }
        public int DebitAmount { get; set; }
        public string MemberCardCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTaxCode { get; set; }
        public bool IsStopFollow { get; set; }
        public string CustomerGroupName { get; set; }
        public string GenderName { get; set; }
        public int MISAEntityState { get; set; }

    }
}
