using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Interfaces;

namespace MISA.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ICustomerRepository customerRepository, ICustomerGroupRepository customerGroupRepository)
        {
            Customer = customerRepository;
            GroupCustomer = customerGroupRepository;
        }
        public ICustomerRepository Customer { get; }

        public ICustomerGroupRepository GroupCustomer { get; }
    }
}
