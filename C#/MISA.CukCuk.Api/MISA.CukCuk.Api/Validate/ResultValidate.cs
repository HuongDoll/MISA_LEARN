using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Api.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultValidate
    {
        public string ValidateInfo { get; set; }
        public string ValidateInfoDev { get; set; }
        public ErrorCode ErrorCode { get; set; }
        public bool IsValidate { get; set; }

        public Guid IdDuplicate { get; set; }
    }
}
