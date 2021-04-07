using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces;

namespace MISA.CukCuk.Controllers
{
    /// <summary>
    /// Api cho đối tượng khách hàng
    /// </summary>
    public class CustomerController : BaseEntityController<Customer>
    {
        public CustomerController(ICustomerService baseService) : base(baseService)
        {

        }
      
    }
}
