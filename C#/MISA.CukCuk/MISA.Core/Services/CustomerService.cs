using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MISA.Core.Entities;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces;

namespace MISA.Core.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository;
        public CustomerService( ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public override int UpDate(Customer customer, Guid customerId)
        {
            if (_customerRepository.CheckCustomerExistID(customerId))
            {
                customer.CustomerId = customerId;
                //validate
                ValidateEntity(customer, "update");
                //them moi
                var row = _customerRepository.UpDate(customer, customerId);
                return row;
            }
            return 0;
        }

        public override bool ValidateEntity(Customer customer, string fun)
        {
            //check customer
            if (customer.CustomerCode == null)
            {
                return false;
                throw new ValidateExceptions("Mã khách hàng không được để trống");
            }

            if (customer.FullName == null)
            {
                return false;
                throw new ValidateExceptions("Họ và tên không được để trống");
            }

            if (customer.PhoneNumber == null)
            {
                return false;
                throw new ValidateExceptions("Số điện thoại không được để trống");
            }

            if (!Regex.Match(customer.PhoneNumber, @"^(\+[0-9]{9})$").Success)
            {
                return false;
                throw new ValidateExceptions("Số điện thoại không đúng");
            }


            //check duplicate customerCode
            var checkCustomerDuplicateCode = _customerRepository.CheckCustomerDuplicateCode(customer.CustomerCode);
            if(fun == "insert")
            {
                if (checkCustomerDuplicateCode != Guid.Empty)
                {
                    return false;
                }
            }
            else
            {
                if (checkCustomerDuplicateCode != Guid.Empty && checkCustomerDuplicateCode != customer.CustomerId)
                {
                    return false;
                }
            }
            
            
            return true;
        }
        public override int Delete(Guid entityId)
        {
            if (_customerRepository.CheckCustomerExistID(entityId))
            {
                var row = _customerRepository.Delete(entityId);
                return row;
            }
            return 0;
        }
    }
}
