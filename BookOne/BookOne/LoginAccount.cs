using Dapper;
using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace BookOne
{
    public class LoginAccount
    {
        public static int LoginID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public static int RoleType { get; set; }
        public int Clap { get; set; }

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
                    Console.WriteLine("Lets try again");
                }
            } while (againLogin == true);
        }
        public static int GetLoginID(string username, string password) //Maybe Chainge: sp_LoginUser
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
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

        public static int GetRole(int ID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {
                    var p = new DynamicParameters();
                    p.Add("loginID", ID);
                    p.Add("RoleType", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    DataAccess.sqlconn.Query<int>("sp_GetRoleFromLoginID", p, commandType: CommandType.StoredProcedure);
                    RoleType = p.Get<int>("RoleType");
                    return RoleType;
                }
                catch (Exception ex) //ok for now
                {
                    Console.WriteLine(ex);
                }
                return 0;
            }
        }

       

        

        public static int IfUserIDExists(int loginID) //Maybe Chainge: sp_LoginUser
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {

                try
                {
                    var p = new DynamicParameters();
                    p.Add("LoginID", loginID);
                    p.Add("Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    DataAccess.sqlconn.Query<int>("sp_IfUserIDExists", p, commandType: CommandType.StoredProcedure);
                    int Result = p.Get<int>("Count");
                    return Result;
                }
                catch (Exception)
                {
                    return 0;
                }
            }



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

        public static void AddClap(int loginID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                var affectedRows = DataAccess.sqlconn.Execute("sp_AddClap",
                new
                {
                    LoginID = loginID
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public static void AddOneMoreCarriedBook(int loginID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                var affectedRows = DataAccess.sqlconn.Execute("sp_AddOneMoreCarriedBook",
                new
                {
                    LoginID = loginID
                }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

