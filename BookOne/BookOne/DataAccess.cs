using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOne
{
    public class DataAccess
    {

        //CONNECTION
        public static string conectionString = "SERVER = DESKTOP-MG63D0P\\SQLEXPRESS; Database = BookOne; User Id = User1; Password=User1";

        public static SqlConnection sqlconn = new SqlConnection(conectionString);

        LoginAccount loginAccount = new LoginAccount();
        public void Conection()
        {
            
            using (sqlconn)
            {
                try
                {
                    LoginAccount.GetLoginID(loginAccount.UserName, loginAccount.Password);

                    Book.ViewAllItems();


                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }

            }
        }

    }
}
