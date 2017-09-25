using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialView.DAL
{
    public static class sqlConnection
    {
        public static string Conn(string connectionString = "")
        {
            string strConn = "";

            if (ConfigurationManager.ConnectionStrings[connectionString] != null)
            {
                strConn = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
            }

            return strConn;
        }
    }
}
