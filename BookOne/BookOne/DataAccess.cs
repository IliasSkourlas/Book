using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper; 

namespace BookOne
{
    public class DataAccess
    {

        // CONNECTION 1st way
        //public static string conectionString = "SERVER = DESKTOP-MG63D0P\\SQLEXPRESS; Database = BookOne; User Id = User1; Password=User1";
        public static SqlConnection sqlconn = new SqlConnection(Helper.conectionString);

        // CONNECTION 2nd way
        //public static IDbConnection sqlconn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("BookOne"));

    }
}
