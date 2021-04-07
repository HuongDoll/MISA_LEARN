using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using MySqlConnector;

namespace MISA.Infrastructure.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public Guid CheckCustomerDuplicateCode(string customerCode)
        {
            
            //Validate dữ liệu:
            //-check trùng mã:
            // Kiểm tra xem có khách hàng nào có mã tương tự hay không ?:
            var sqlCheckExitCode = "Select CustomerCode from Customer Where CustomerCode = @CustomerCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerCode", customerCode);
            var customerExitsCode = _dbConnection.Query<Customer>(sqlCheckExitCode, dynamicParameters).FirstOrDefault();
            if (customerExitsCode != null)
            {
                return customerExitsCode.CustomerId;
            }
            else return Guid.Empty;
        }

        public bool CheckCustomerExistID(Guid customerId)
        {
           
            //Validate dữ liệu:
            //-check trùng mã:
            // Kiểm tra xem có khách hàng nào có mã tương tự hay không ?:
            var sqlCheckExistId = "Select CustomerId from Customer Where CustomerId = @CustomerId";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", customerId);
            var customerExistId = _dbConnection.Query<Customer>(sqlCheckExistId, dynamicParameters).FirstOrDefault();
            if (customerExistId != null)
            {
                return true;
            }
            else return false;
        }
    }
}
