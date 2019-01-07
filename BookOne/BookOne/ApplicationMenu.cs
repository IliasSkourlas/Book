using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOne
{
    public class ApplicationMenu
    {

        Book book = new Book();

        // different Menus for different Roles
        public void ViewOnlyUser()
        {
            Console.WriteLine("press...v...to view");

            Console.WriteLine("press...b...to go back to login\n");
            Console.WriteLine("press...e...to esc the app");


        }
        public void ViewEditUser()
        {
            Console.WriteLine("press...v...to view");
            Console.WriteLine("press...g...to give a book");
            Console.WriteLine("press...c...to carry a book");

            Console.WriteLine("press...b...to go back to login\n");
            Console.WriteLine("press...e...to esc the app");

        }
        public void ViewEditDeleteUser()
        {
            Console.WriteLine("press...v...to view");
            Console.WriteLine("press...g...to give a book");
            Console.WriteLine("press...c...to carry a book");
            Console.WriteLine("press...m...to see my books");
            Console.WriteLine("press...d...to call back\n");

            Console.WriteLine("press...b...to go back to login\n");
            Console.WriteLine("press...e...to esc the app");

        }

        public List<string> SuperAdmin()
        {
            List<string> superAdminInfo = new List<string>();
            superAdminInfo.Add("v...view");
            superAdminInfo.Add("w...words");
            superAdminInfo.Add("n...who has this book now?");
            superAdminInfo.Add("o...circulation");
            superAdminInfo.Add("my...my ID");
            superAdminInfo.Add("h...hand this book");
            superAdminInfo.Add(string.Empty);

            return superAdminInfo;
        }

       
        //public void SuperAdmin()
        //{
        //    List<string> superAdminInfo = new List<string>();
        //    superAdminInfo.Add("v...view");
        //    superAdminInfo.Add("w...words");
        //    superAdminInfo.Add("n...who has this book now?");
        //    superAdminInfo.Add("o...circulation");
        //    superAdminInfo.Add("my...my ID");
        //    superAdminInfo.Add("h...hand this book");
        //    superAdminInfo.Add(string.Empty);

        //    bool loopInfo = true;
        //    do
        //    {
        //        Console.SetCursorPosition(0, 0);
        //        Console.WriteLine("i...info: ");
        //        ConsoleKeyInfo info = Console.ReadKey();

        //        if (info.Key == ConsoleKey.Escape)
        //        {
        //            loopInfo = false;
        //        }

        //        if (info.KeyChar == 'i')
        //        {
        //            for (int i = 0; i < superAdminInfo.Count; i++)
        //            {
        //                Console.SetCursorPosition(0, i+7);
        //                Console.Write(superAdminInfo[i]);
        //            }
        //        }
        //        else;

        //    } while (loopInfo == true);



        //    //Console.WriteLine("press:");
        //    //Console.WriteLine("...i...for info");
        //    //Console.WriteLine("...v...to view");
        //    //Console.WriteLine("...w...for words");
        //    //Console.WriteLine("...n...who has this book now?");
        //    //Console.WriteLine("...o...circulation");
        //    //Console.WriteLine("...my...for my ID");
        //    //Console.WriteLine("...h...hand this book");

        //    //Console.WriteLine("...g...to give a book");
        //    //Console.WriteLine("...c...to carry a book");
        //    //Console.WriteLine("...m...for my books");
        //    //Console.WriteLine("...d...to call back\n");
        //    //Console.WriteLine("................................");
        //    //Console.WriteLine("...all...to view all ????"); //yet
        //    //Console.WriteLine("...create...to create a new user"); //yet
        //    //Console.WriteLine("...delete...to delete a user"); //yet
        //    //Console.WriteLine("...update...to alter a roles");
        //    //Console.WriteLine("................................");
        //    //Console.WriteLine("...b...to go back to login\n");
        //    //Console.WriteLine("...e...to esc the app");

        //}

        // select View according to RoleType
        public void SelectView()
        {
            if (LoginAccount.RoleType == 4)
            {
                ViewOnlyUser();
            }
            if (LoginAccount.RoleType == 3)
            {
                ViewEditUser();
            }
            if (LoginAccount.RoleType == 2)
            {
                ViewEditDeleteUser();
            }
            if (LoginAccount.RoleType == 1)
            {
                SuperAdmin();
            }
        }

        public void AccordingToRole()
        {
            int ID = LoginAccount.LoginID;
            LoginAccount.GetRole(ID);
            SelectView();
        }







        //        public void MenuOne()    
        //        {
        //            bool againMenu = true;
        //            do
        //            {
        //                

        //                
        //                
        //                
        //                
        //                //Delete()
        //                if (choice == "d")
        //                {
        //                    Console.Clear();
        //                    dbo_Message.DeleteAllOfMyMessages(ID);
        //                    Console.Clear();
        //                    Console.WriteLine("messages have been deleted");
        //                    Console.ReadKey();
        //                    againMenu = true;
        //                }
        //                //Create()
        //                if (choice == "create") //yet
        //                {
        //                    Console.Clear();
        //                    dbo_Message.DeleteAllOfMyMessages(ID);
        //                    //Console.Clear();
        //                    //Console.WriteLine("messages have been deleted");
        //                    //Console.ReadKey();
        //                    againMenu = true;
        //                }
        //                //Update role
        //                if (choice == "update")
        //                {
        //                    string exit;
        //                    int fromRoleID;
        //                    int newRoleType;
        //                    do
        //                    {
        //                        //Try Catch
        //                        try
        //                        {
        //                            do
        //                            {
        //                                Console.Clear();
        //                                dbo_Login.ViewAllRoles();
        //                                Console.Write("Choose a RoleID:");
        //                                fromRoleID = Convert.ToInt32(Console.ReadLine());
        //                                Console.Write("Update to RoleType:");
        //                                newRoleType = Convert.ToInt32(Console.ReadLine());
        //                                if (newRoleType < 1 || newRoleType > 4)
        //                                {
        //                                    int milliseconds = 500;
        //                                    Thread.Sleep(milliseconds);
        //                                    Console.WriteLine("Wrong input...please try again\n");
        //                                    Console.ReadKey();
        //                                }
        //                                else
        //                                {
        //                                    dbo_Login.UpdateRoleTypeByRoleId(fromRoleID, newRoleType);
        //                                    Console.Clear();
        //                                    dbo_Login.ViewAllRoles();

        //                                }
        //                            } while (newRoleType < 1 || newRoleType > 4);
        //                        }
        //#pragma warning disable CS0168 // The variable 'e' is declared but never used
        //                        catch (Exception e)
        //#pragma warning restore CS0168 // The variable 'e' is declared but never used
        //                        {
        //                            int milliseconds = 500;
        //                            Thread.Sleep(milliseconds);
        //                            Console.WriteLine("Wrong input...");
        //                        }
        //                        finally
        //                        {
        //                            Console.WriteLine("Press...enter...to update");
        //                            Console.WriteLine("Press...e...to esc");
        //                            exit = Console.ReadLine();
        //                        }
        //                    } while (exit != "e");

        //                    againMenu = true;
        //                }
        //                //go to back to login
        //                if (choice == "b")
        //                {
        //                    dbo_Login.Login();
        //                    againMenu = true;

        //                }
        //                //esc app
        //                if (choice == "e")
        //                {
        //                    Console.Clear();
        //                    againMenu = false;
        //                }
        //                else
        //                {
        //                    againMenu = true;
        //                }
        //            } while (againMenu == true);



        //            Console.ReadLine();
        //        }
    }
}
