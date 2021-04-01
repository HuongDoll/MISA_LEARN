using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace MISA.CukCuk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseEntityController<MISAEntity> : ControllerBase
    {
        protected string _tableName = string.Empty;
        protected string _connectionString = "" +
               "Host=47.241.69.179; " +
               "Port=3306;" +
               "User Id= dev; " +
               "Password=12345678;" +
               "Database= MF0_NVManh_CukCuk02";
        protected IDbConnection _dbConnection;
        public BaseEntityController()
        {
            _tableName = typeof(MISAEntity).Name;
            _dbConnection = new MySqlConnection(_connectionString);
        }


        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Nếu có dữ liệu: trả vễ HttpCode 200; 204 nếu không có dữ liệu</returns>
        /// CreatedBy: NVMANH (01/04/2021)
        [HttpGet]

        public IActionResult Get()
        {
            // lấy dữ liệu từ database
            var storename = $"Proc_Get{_tableName}s";
            var entities = _dbConnection.Query<MISAEntity>(storename, commandType: CommandType.StoredProcedure);
            // Kiểm tra dữ liệu trả về
            if (entities.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entities);
            }
        }

        [HttpGet("{entityId}")]
        public IActionResult Get(string entityId)
        {
            // lấy dữ liệu từ database
            var storeName = $"Proc_Get{_tableName}ById";
            var entities = _dbConnection.Query<MISAEntity>(storeName, commandType: CommandType.StoredProcedure);
            // Kiểm tra dữ liệu trả về
            if (entities.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entities);
            }
        }

    }
}
