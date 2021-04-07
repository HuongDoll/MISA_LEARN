using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces;

namespace MISA.CukCuk.Controllers
{

    public class CustomerGroupController : BaseEntityController<CustomerGroup>
    {
        public CustomerGroupController(IBaseService<CustomerGroup> baseService) : base(baseService)
        {

        } 
    }
}
