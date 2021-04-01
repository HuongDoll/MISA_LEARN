using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa.api.amanh.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.api.amanh.Controllers
{
    /// <summary>
    /// Api cho đối tượng khách hàng
    /// </summary>
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Khởi tạo kết nối tới database
            string connectionString = "Host=47.241.69.179;"
                                    + "Post=3306;"
                                    + " User Id= dev;"
                                    + " PassWord=12345678;"
                                    + " Database=MF0_NVManh__CukCuk02";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            // Thực hiện lấy dữ liệu từ database
            //var customers = dbConnection.Query<Customer>("SELECT * FROM Customer");
            var customers = dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);


            //Kiểm tra kq trả về cho client
            if (customers.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(200, customers);
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public IActionResult Get(Guid customerId)
        {
            // Khởi tạo kết nối tới database
            string connectionString = "Host=47.241.69.179;"
                                    + "Post=3306;"
                                    + " User Id= dev;"
                                    + " PassWord=12345678;"
                                    + " Database=MF0_NVManh__CukCuk02";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            // Thực hiện lấy dữ liệu từ database
            //var customers = dbConnection.Query<Customer>("SELECT * FROM Customer");
            var storeName = "Proc_GetCustomerById";
            var storeParam = new
            {
                CustommerId = customerId
            };
            var customer = dbConnection.Query<Customer>(storeName, param: storeParam, commandType: CommandType.StoredProcedure);


            //Kiểm tra kq trả về cho client
            if (customer == null)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(200, customer);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public IActionResult Post()
        {
            //Khởi tạo kết nối đén database
            string connectionString = "Host=47.241.69.179;"
                                    + "Post=3306;"
                                    + " User Id= dev;"
                                    + " PassWord=12345678;"
                                    + " Database=MF0_NVManh__CukCuk02";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //Kiểm tra xem có khác hàng nào có mã tương tự không
            var sqlCheckExitCode = "Select CustomerCode from Customer Where CustomerCode = @CustomerCode";
            
            //Thực hiện lấy dữ liệu từ database

            //kiểm tra kết quả trả về cho client

            return StatusCode(200);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpPut("{customerId}")]
        public IActionResult put(CustomerController customer, Guid customerId)
        {

            

            return StatusCode(200);
        }
        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="customerId">Khóa chính</param>
        /// <returns>
        /// - Httpcode: 200 nếu
        /// 
        /// 
        /// </returns>
        [HttpDelete("{customerId}")]
        public IActionResult delete( Guid customerId)
        {
            return StatusCode(200);
        }

    }
}
