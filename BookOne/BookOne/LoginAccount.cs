using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace BookOne
{
    public class LoginAccount
    {
        public static int LoginID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
       
        public LoginAccount()
        {

        }
        public LoginAccount(string username, string password)
        {
            UserName = username;
            Password = password;
        }



        public static void Login()
        {
            int ID = 0;
            LoginID = ID;
            bool againLogin;
            do
            {
                Console.Clear();
                Console.WriteLine("User name?");
                string username = Console.ReadLine();
                Console.WriteLine("Password?");
                string password = Console.ReadLine();

                ID = GetLoginID(username, password);
                if (ID >= 1)
                {
                    againLogin = false;
                }
                else
                {
                    againLogin = true;
                    Console.WriteLine("Do you want to try again");
                    Console.WriteLine("Y_or_N?");
                    ConsoleKeyInfo yesNo = Console.ReadKey();

                    if(yesNo.KeyChar == 'y' || yesNo.KeyChar == 'Y')
                    {
                        againLogin = true;
                    }
                    if (yesNo.KeyChar == 'n' || yesNo.KeyChar == 'N')
                    {
                        Console.WriteLine();
                        Console.WriteLine("Bye bye");
                        Console.ReadKey();
                        Environment.Exit(0);

                    }
                }
            } while (againLogin == true);
        }

        public static int GetLoginID(string username, string password) //Maybe Chainge: sp_LoginUser
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            //SqlConnection dbcon = new SqlConnection(conAgain);
            using (DataAccess.sqlconn)
            {
                try
                {
                    var p = new DynamicParameters();
                    p.Add("UserName", username);
                    p.Add("Password", password);
                    p.Add("logInID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    DataAccess.sqlconn.Query<int>("sp_LoginUser", p, commandType: CommandType.StoredProcedure);
                    LoginID = p.Get<int>("logInID");
                    if (LoginID >= 1)
                    {
                        return LoginID;
                    }
                }
                catch (Exception)
                {
                    return 0;
                }
                return 0;
            }
        }







      
        




        
    }
}

