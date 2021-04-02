using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

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
        /// CreatedBy: huongdoll (01/04/2021)
        [HttpGet]

        public IActionResult Get()
        {
            // lấy dữ liệu từ database
            var storename = $"Proc_Get{_tableName}s";
            var entities = _dbConnection.Query<MISAEntity>(storename,commandType: CommandType.StoredProcedure);
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

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Khách hàng muốn thêm mới</param>
        /// <returns>
        ///  - HttpCode: 200 nếu thêm được dữ liệu
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - HttpCode: 500 nếu có lỗi hoặc Exceotion xảy ra trên Server
        /// </returns>
        /// CreatedBy: huongdoll (01/04/2021)
        [HttpPost]
        public IActionResult Post(MISAEntity entity)
        {
            // Validate dữ liệu:
            ValidateData(entity);
            // Thực hiện lấy dữ liệu từ Database:
            var storeName = $"Proc_Insert{_tableName}";
            var storeParam = entity;
            var rowAffects = _dbConnection.Execute(storeName, param: storeParam, commandType: CommandType.StoredProcedure);
            // Kiểm tra kết quả và trả về cho Client:
            if (rowAffects == 0)
                return NoContent();
            else
                return Ok(entity);
        }

        protected virtual void ValidateData(MISAEntity entity)
        {

        }
    }
}
