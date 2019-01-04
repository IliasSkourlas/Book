using Dapper;
using System;
using System.Data;
using System.Linq;

namespace BookOne
{
    public class LoginAccount
    {
        public static int LoginID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public int RoleID { get; set; }
        public int RoleType { get; set; }

        public LoginAccount()
        {

        }
        public LoginAccount(string username, string password)
        {
            UserName = username;
            Password = password;
        }


        public static int GetLoginID(string username, string password) //Maybe Chainge: sp_LoginUser
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
            catch(Exception )
            {
                return 0;
            }
            return 0;
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
                    Console.Clear();
                    Console.WriteLine("!!Lets Play!!\a");
                    Console.ReadKey();
                }
                else
                {
                    againLogin = true;
                    Console.WriteLine("Lets try again");
                }
            } while (againLogin == true);
        }



        //public static int GetRole(int ID)
        //{
        //    dbo_Login dbo_login = new dbo_Login();

        //    DataAccess.sqlconn.ConnectionString = Helper.conectionString;
        //    using (DataAccess.sqlconn)
        //    {
        //        try
        //        {
        //            var p = new DynamicParameters();
        //            p.Add("loginID", ID);
        //            p.Add("RoleType", dbType: DbType.Int32, direction: ParameterDirection.Output);
        //            DataAccess.sqlconn.Query<int>("sp_GetRoleFromLoginID", p, commandType: CommandType.StoredProcedure);
        //            dbo_login.RoleType = p.Get<int>("RoleType");
        //            return dbo_login.RoleType;
        //        }
        //        catch (Exception ex) //ok for now
        //        {
        //            Console.WriteLine(ex);
        //        }
        //        return 0;
        //    }
        //}



        //public static void ViewAllRoles()
        //{

        //    {
        //        DataAccess.sqlconn.ConnectionString = Helper.conectionString;
        //        using (DataAccess.sqlconn)
        //        {
        //            var viewAllRoles = DataAccess.sqlconn.Query<dbo_Login>
        //                ($"sp_ViewAllRoles").ToList();

        //            foreach (var item in viewAllRoles)
        //            {
        //                Console.WriteLine($"RoleID: {item.RoleID}");
        //                Console.WriteLine($"UserName: {item.UserName}");
        //                Console.WriteLine($"RoleType: {item.RoleType}");
        //                Console.WriteLine(".......");
        //            }
        //        }
        //    }
        //}



        //public static void UpdateRoleTypeByRoleId(int roleID, int roleType)
        //{
        //    {

        //        DataAccess.sqlconn.ConnectionString = Helper.conectionString;
        //        using (DataAccess.sqlconn)
        //        {
        //            var updateRoleTypeByRoleId = DataAccess.sqlconn.Query<dbo_Login>
        //                ($"sp_UpdateRoleTypeByRoleId @RoleID = {roleID}, @RoleType = {roleType}").ToList();
        //        }
        //    }
        //}
    }
}

