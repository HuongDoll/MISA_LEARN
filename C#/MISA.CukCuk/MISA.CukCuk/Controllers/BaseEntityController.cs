using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces;
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
        IBaseService<MISAEntity> _baseService;
        public BaseEntityController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
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

            var entities = _baseService.GetEntities();
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
        public IActionResult Get(Guid entityId)
        {
            // lấy dữ liệu từ database
            var entitie = _baseService.GetById(entityId);
            // Kiểm tra dữ liệu trả về
            if (entitie == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(entitie);
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
            var row = _baseService.Insert(entity);
            // Kiểm tra dữ liệu trả về
            if (row == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(row);
            }
        }

        [HttpPut("{entityId}")]
        public IActionResult Put(MISAEntity entity, Guid entityId)
        {
            var row = _baseService.UpDate(entity, entityId);
            // Kiểm tra dữ liệu trả về
            if (row == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(row);
            }
        }

        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            var row = _baseService.Delete(entityId);
            // Kiểm tra dữ liệu trả về
            if (row == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(row);
            }
        }
    }
}
