using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace BookOne
{
    class User
    {
        public string LoginID { get; set; }
        public string UserName { get; set; }
        public int RoleType { get; set; }
        public int Clap { get; set; }
        public int Carrier { get; set; }

        public static int ThisRoleType {
            get; set; }




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
                    ThisRoleType = p.Get<int>("RoleType");
                    return ThisRoleType;
                }
                catch (Exception ex) //ok for now
                {
                    Console.WriteLine(ex);
                }
                return 0;
            }
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

        public static void DeleteUser(int loginID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {

                    var affectedRows = DataAccess.sqlconn.Execute("sp_DeleteUser",
                    new
                    {
                        LogInID = loginID
                    }, commandType: CommandType.StoredProcedure);
                    Console.WriteLine("Bye bye");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Soory ...No can do! ");
                }
            }
        }
        public static void UpdateUser(int loginID, string userName, string password, int roleType, int clap, int carrier) //Look exception
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {
                    var affectedRows = DataAccess.sqlconn.Execute("sp_UpdateUser",
                    new
                    {
                        LoginID = loginID,
                        UserName = userName,
                        Password = password,
                        RoleType = roleType,
                        Clap = clap,
                        Carrier = carrier
                    }, commandType: CommandType.StoredProcedure);
                }
                catch (DbException dbe )
                {
                    Console.WriteLine(dbe);
                    //Console.WriteLine("Are you sure? ");
                }
            }
        }
        public static void EnterUser( string userName, string password, int roleType, int clap, int carrier)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {
                    var affectedRows = DataAccess.sqlconn.Execute("sp_EnterUser",
                    new
                    {
                        UserName = userName,
                        Password = password,
                        RoleType = roleType,
                        Clap = clap,
                        Carrier = carrier
                    }, commandType: CommandType.StoredProcedure);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Are you sure? ");
                }
            }
        }


        // USER info 
        public static void GetInfoAllUsers(int content)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
               
                try
                {
                    var getInfoAllUsers = DataAccess.sqlconn.Query<User>
                    ($"sp_GetInfoAllUsers").ToList();

                    if (content == 0)
                    {
                        Get0IdNameClapCarrier(getInfoAllUsers);
                    }
                    if (content == 1)
                    {
                        Get0IdNameClapCarrier(getInfoAllUsers); // delete
                    }

                }
                catch (Exception ex) //ok for now
                {
                    Console.WriteLine(ex);
                }
            }
        }
        // User content = 0 ID NameClapCarrier
        public static void Get0IdNameClapCarrier(List<User> getInfoAllUsers)
        {
            for (int i = 0; i < getInfoAllUsers.Count; i++)
            {
                Console.SetCursorPosition(43, i + 1);
                Console.Write($"{getInfoAllUsers[i].LoginID} ");
                Console.SetCursorPosition(48, i + 1);
                Console.Write($"{getInfoAllUsers[i].UserName}  ");
                Console.SetCursorPosition(64, i + 1);
                Console.Write($"{getInfoAllUsers[i].RoleType} ");
                Console.SetCursorPosition(72, i + 1);
                Console.Write($"{getInfoAllUsers[i].Carrier} ");
                Console.SetCursorPosition(80, i + 1);
                Console.Write($"{getInfoAllUsers[i].Clap} ");
            }
        }

        // Not in Use Yet
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
        }
    }
}
