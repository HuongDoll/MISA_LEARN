﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.api.amanh.Model
{
    /// <summary>
    /// 
    /// 
    /// </summary>
    public class Customer: BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public Guid CustomerId { get; set; }

        public string CustomerCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public int? Gender { get; set; }

        public string Address { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Guid? CustomerGroupId { get; set; }

        public double DebitAmount { get; set; }

        public string MemberCardCode { get; set; }

        public bool? IsStopFollow { get; set; }

        public string CompanyName { get; set; }

        public string CompanyTaxCode { get; set; }
    }
}
