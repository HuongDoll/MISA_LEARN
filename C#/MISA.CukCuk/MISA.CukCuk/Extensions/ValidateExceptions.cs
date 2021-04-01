using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Extensions
{
    public class ValidateExceptions: Exception
    {
        public ValidateExceptions(string msg) : base(msg)
        {

        }

    }
}
