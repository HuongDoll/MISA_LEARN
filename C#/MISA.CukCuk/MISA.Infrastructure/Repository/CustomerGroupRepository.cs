using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities;
using MISA.Core.Interfaces;

namespace MISA.Infrastructure.Repository
{
    public class CustomerGroupRepository : BaseRepository<CustomerGroup>, ICustomerGroupRepository
    {
        public bool CheckCustomerGroupName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
