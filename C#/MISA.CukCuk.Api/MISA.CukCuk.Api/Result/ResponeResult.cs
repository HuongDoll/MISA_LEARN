using MISA.CukCuk.Api.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Result
{
    public class ResponeResult
    {
        public bool isSuccess { get; set; }
        public string DevMsg { get; set; }
        public string UserMsg { get; set; }
        public ErrorCode ErrorCode { get; set; } = ErrorCode.NONE;
        /// <summary>
        /// Thêm thông tin tìm hiểu cho dev
        /// </summary>
        public string MoreInfo { get; set; }
        /// <summary>
        /// Mã lỗi trên tìm kiếm trên trang  nào đó
        /// </summary>
        public string TraceId { get; set; }
        public object Data { get; set; }
        public void OnException(ResponeResult result, Exception exception)
        {
            result.UserMsg = Resource.Message.ExceptionUser;
        }
    }
}
