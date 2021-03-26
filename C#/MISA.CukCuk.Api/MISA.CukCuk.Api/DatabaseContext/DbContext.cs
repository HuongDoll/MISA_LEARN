using MISA.CukCuk.Api.Enumeration;
using MISA.CukCuk.Api.Model;
using MISA.CukCuk.Api.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api
{
    /// <summary>
    /// lỚp triển khai thao tác với database
    /// created by huongdoll
    /// </summary>
    public class DbContext
    {
        public static List<Customer> Customers = new List<Customer>()
        {
            new Customer()
            {
                CustomerID = Guid.NewGuid(),
                CustomerCode = "123",
                FullName = "Hoang thi Thu Huong",
                Gender = (int)Gender.FEMAIL,
            },
            new Customer()
            {
                CustomerID = Guid.NewGuid(),
                CustomerCode = "124",
                FullName = "Huong Doll",
                Gender = (int)Gender.FEMAIL,
            }
        };
        public static List<Customer> GetCustomers()
        {
            return Customers;
        }
        public static Customer GetCustomers(Guid customerId)
        {
            return Customers.Where(c => c.CustomerID == customerId).FirstOrDefault();
        }
        public static ResponeResult InsertCustomer(Customer customer)
        {
            var res = new ResponeResult();
            // to do
            //validate customer
            var validateCustomer = ValidateCustomer(customer);
            if (validateCustomer.IsValidate)
            {
                customer.CustomerID = Guid.NewGuid();
                Customers.Add(customer);
                res.Data = customer;
            }
            else
            {
                res.IsSuccess = false;
                res.Data = "";
            }

            res.DevMsg = validateCustomer.ValidateInfoDev;
            res.ErrorCode = validateCustomer.ErrorCode;
            res.UserMsg = validateCustomer.ValidateInfo;

            return res;
        }

        public static ResultValidate ValidateCustomer(Customer customer)
        {
            var res = new ResultValidate();
            if (customer == null)
            {
                res.IsValidate = false;
                res.ValidateInfo = Resource.Message.ExceptionUser;
                res.ErrorCode = ErrorCode.ERR;
                res.ValidateInfoDev = Resource.Message.ExceptionValidateQuery;
            }
            else
            {

                var findCustomer = Customers
                    .Where(c => c.CustomerCode == customer.CustomerCode)
                     .FirstOrDefault();

                if(findCustomer == null)
                {
                    res.IsValidate = true;
                    res.ErrorCode = ErrorCode.NONE;
                    res.ValidateInfo = Resource.Message.AddCustomerSuccess;
                }
                else
                {
                    //trả ra lỗi đã tồn tại
                    res.IsValidate = false;
                    res.ErrorCode = ErrorCode.DUPLICATE;
                    res.ValidateInfo = Resource.Message.ExceptionDuplicate;

                }

            }
            return res;
        }

        public static ResponeResult UpdateCustomer(Guid customerID, Customer customer)
        {
            
        }
        public static ResponeResult DeleteCustomer(Guid customerID)
        {
            var res = new ResponeResult();
            var findCustomer = Customers
                    .Where(c => c.CustomerID == customerID)
                     .FirstOrDefault();
            if (findCustomer == null)
            {
                //ko tim thay nguoi dung
                res.ErrorCode = ErrorCode.NOTFOUND;
                res.UserMsg = Resource.Message.NotFound;
                res.DevMsg = Resource.Message.NotFound;
            }
            else
            {
                Customers.Remove(findCustomer);
                res.UserMsg = Resource.Message.RemoveSuccess;
                res.DevMsg = Resource.Message.RemoveSuccess;
            }
            return res;
        }
    }
}
