using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api
{
    public interface IDatabaseService<T>
    {
        public IEnumerable<T> Get();
    }
}
