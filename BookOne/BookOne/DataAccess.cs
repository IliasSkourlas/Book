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

       
        //private string ConAgain = Properties.Settings.Default.conBook;


        public static SqlConnection sqlconn = new SqlConnection(Helper.conectionString);



        
        
    }
}
