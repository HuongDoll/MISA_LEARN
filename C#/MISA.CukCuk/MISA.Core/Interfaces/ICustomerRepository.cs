using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities;

namespace MISA.Core.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Guid CheckCustomerDuplicateCode(string customerCode);
        bool CheckCustomerExistID(Guid customerId);
    }
}
