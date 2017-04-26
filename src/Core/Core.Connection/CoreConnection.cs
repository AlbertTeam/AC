using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Connection
{

    [Export(typeof(ICoreConnection))]
    public class CoreConnection: ICoreConnection
    {
        public IDbConnection ConnectionClien()
        {
            SqlConnection conn = new SqlConnection();
            conn.Open();
            return conn;
        }
    }
}
