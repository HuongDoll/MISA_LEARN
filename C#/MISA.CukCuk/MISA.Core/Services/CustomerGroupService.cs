using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities;
using MISA.Core.Interfaces;

namespace MISA.Core.Services
{
    public class CustomerGroupService : BaseService<CustomerGroup>, ICustomerGroupService
    {
        public CustomerGroupService(IBaseRepository<CustomerGroup> baseRepository) :base(baseRepository)
        {
        }
    }
}
