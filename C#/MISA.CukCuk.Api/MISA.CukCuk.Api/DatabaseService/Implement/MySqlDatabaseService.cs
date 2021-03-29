using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api
{
    public class MySqlDatabaseService<T> : IDatabaseService<T>
    {
        public IEnumerable<T> Get()
        {
            throw new NotImplementedException();
        }
    }
}
