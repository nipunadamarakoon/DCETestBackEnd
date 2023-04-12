using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCETest.DataAccessService.SqlDataService
{
    public abstract class IDataService : IDisposable
    {
        public abstract DbDataReader ExecuteReader(string spName, DbParameter[] sqlParameters, int? timeout = null);
        public abstract void Dispose();
    }
}
