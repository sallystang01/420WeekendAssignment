using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AWsearch
{
    class SqlConnect
    {
        const string connString = "Server=PL09\\MTCDB;Database=AdventureWorks2012;Trusted_Connection=True;User ID=AdvWorks2012;Password=1234;";
        SqlConnection advConn;
        
        private bool DBConnect(string ConnectionString = "")
        {
            bool returnValue;

            if (ConnectionString.Length == 0)
                ConnectionString = connString;

            try
            {
                advConn = new SqlConnection();
                advConn.Open();
                returnValue = true;
            }
            catch (Exception ex)
            {
                returnValue = false;
                throw ex;
            }

            return returnValue;
        }
        
    }
}
