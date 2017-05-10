using CommonTool.Setting;
using Core.Connection.DataBaseConfig;
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
    public class CoreConnection : ICoreConnection
    {
        public IDbConnection ConnectionClien(DBString key)
        {
            SqlConnection conn = new SqlConnection(DatabaseManager.GetDatabase(key.ToString()).ConnectionString);
            conn.Open();
            return conn;
        }

    }
}
