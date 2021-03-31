using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Api.Enumeration;
using MISA.CukCuk.Api.Model;
using MISA.CukCuk.Api.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            var res = new ResponeResult();

            try
            {
                res.Data = DbContext.GetCustomers();
            }
            catch (Exception ex)
            {
                res.OnException(res, ex);
                //log
            }

            return Ok(res);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] string id)
        {
            var res = new ResponeResult();

            try
            {
                Guid.TryParse(id, out Guid customerId);
                if (customerId != null && customerId != Guid.Empty)
                {
                    res.Data = DbContext.GetCustomers(customerId);
                }
                else
                {
                    res.OnBadRequest(res);

                    return BadRequest(res);
                }

            }
            catch (Exception ex)
            {
                res.OnException(res, ex);
                //log
            }

            return Ok(res);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            var res = new ResponeResult();
            try
            {
                res = DbContext.InsertCustomer(customer);
            }
            catch (Exception ex)
            {
                res.OnException(res, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, res);
                // log
            }
            return StatusCode(StatusCodes.Status201Created, res);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ResponeResult Put([FromRoute] string id, [FromBody] Customer customer)
        {
            var res = new ResponeResult();
            Guid.TryParse(id, out Guid customerId);
            if (customerId != null && customerId != Guid.Empty)
            {
                try
                {
                    res = DbContext.UpdateCustomer(customerId, customer);
                }
                catch (Exception ex)
                {
                    res.OnException(res, ex);
                    //log
                }
            }
            else
            {
                res.IsSuccess = false;
                res.UserMsg = Resource.Message.ExceptionUser;
                res.DevMsg = Resource.Message.ExceptionUser;
            }

            return res;
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ResponeResult Delete([FromRoute] string id)
        {
            var res = new ResponeResult();
            try
            {
                Guid.TryParse(id, out Guid customerId);
                if (customerId != null && customerId != Guid.Empty)
                {
                    res = DbContext.DeleteCustomer(customerId);
                    if (res.ErrorCode != ErrorCode.NONE)
                    {
                        res.IsSuccess = false;
                    }
                }
                else
                {
                    res.IsSuccess = false;
                    res.UserMsg = Resource.Message.ExceptionUser;
                    res.DevMsg = Resource.Message.ExceptionUser;
                }
            }
            catch (Exception ex)
            {
                res.OnBadRequest(res);
                //log
            }
            return res;
        }
    }
}
