using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOne
{
    public class ApplicationMenu
    {

        Book book = new Book();   // do i need this?

        // lists for different Roles
        public List<string> InfoList()
        {
            if (LoginAccount.RoleType == 1)
            {
                return SuperAdminInfo();
            }
            if (LoginAccount.RoleType == 2)
            {
                return ViewEditDeleteUserInfo();

            }
            if (LoginAccount.RoleType == 3)
            {
                return ViewEditUserInfo();
            }
            else
            {
                return ViewOnlyUserInfo();
            }
        }

        public List<string> ViewOnlyUserInfo()
        {
            List<string> viewOnlyUserInfo = new List<string>();
            viewOnlyUserInfo.Add("m...my books");
            viewOnlyUserInfo.Add("h...books in my hand");
            viewOnlyUserInfo.Add("c...carriers of my books");
            viewOnlyUserInfo.Add("o...circulation");
            viewOnlyUserInfo.Add("u...user info");
            viewOnlyUserInfo.Add("r...read");

            return viewOnlyUserInfo;

        }
        public List<string> ViewEditUserInfo()
        {

            List<string> viewEditUserInfo = new List<string>();
            viewEditUserInfo.Add("m...my books");
            viewEditUserInfo.Add("h...books in my hand");
            viewEditUserInfo.Add("c...carriers of my books");
            viewEditUserInfo.Add("o...circulation");
            viewEditUserInfo.Add("u...user info");
            viewEditUserInfo.Add("r...read");


            viewEditUserInfo.Add(string.Empty);
            viewEditUserInfo.Add("s...give a book");
            viewEditUserInfo.Add("a...accept a book");
            viewEditUserInfo.Add("e...enter your book");
            viewEditUserInfo.Add("w...words");
            viewEditUserInfo.Add(string.Empty);

            return viewEditUserInfo;
        }
        public List<string> ViewEditDeleteUserInfo()
        {
            List<string> viewEditDeleteUserInfo = new List<string>();
            viewEditDeleteUserInfo.Add("m...my books");
            viewEditDeleteUserInfo.Add("h...books in my hand");
            viewEditDeleteUserInfo.Add("c...carriers of my books");
            viewEditDeleteUserInfo.Add("o...circulation");
            viewEditDeleteUserInfo.Add("u...user info");
            viewEditDeleteUserInfo.Add("r...read");


            viewEditDeleteUserInfo.Add(string.Empty);
            viewEditDeleteUserInfo.Add("s...give a book");
            viewEditDeleteUserInfo.Add("a...accept a book");
            viewEditDeleteUserInfo.Add("e...enter your book");
            viewEditDeleteUserInfo.Add("w...words");
            viewEditDeleteUserInfo.Add(string.Empty);
            viewEditDeleteUserInfo.Add("d...delete your book");

            viewEditDeleteUserInfo.Add(string.Empty);
            viewEditDeleteUserInfo.Add("z...update user");
            viewEditDeleteUserInfo.Add("x...delete user");
            viewEditDeleteUserInfo.Add("b...to go back to login\n");
            viewEditDeleteUserInfo.Add("Esc...to esc the app");
            return viewEditDeleteUserInfo;

        }
        public List<string> SuperAdminInfo()
        {
            List<string> superAdminInfo = new List<string>();
            superAdminInfo.Add("m...my books");
            superAdminInfo.Add("h...books in my hand");
            superAdminInfo.Add("c...carriers of my books"); 
            superAdminInfo.Add("o...circulation");
            superAdminInfo.Add("u...user info");
            superAdminInfo.Add("r...read"); 
            

            superAdminInfo.Add(string.Empty);
            superAdminInfo.Add("s...give a book");
            superAdminInfo.Add("a...accept a book");
            superAdminInfo.Add("e...enter your book");
            superAdminInfo.Add("w...words");
            superAdminInfo.Add(string.Empty);
            superAdminInfo.Add("d...delete your book");

            superAdminInfo.Add(string.Empty);
            superAdminInfo.Add("z...update user");
            superAdminInfo.Add("x...delete user");
            superAdminInfo.Add("b...to go back to login\n");
            superAdminInfo.Add("Esc...to esc the app");
            return superAdminInfo;
        }


        // The looks
        public ConsoleKeyInfo ShowHideInfoMenu()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("i...info: ");
            DotsDots();
            ConsoleKeyInfo info = Console.ReadKey();

            if (info.KeyChar == 'i')
            {
                for (int i = 0; i < InfoList().Count; i++)
                {
                    Console.SetCursorPosition(0, i + 7);
                    Console.Write(InfoList()[i]);
                }
            }
            info = Console.ReadKey();
            if (info.KeyChar == 'i' && info.KeyChar == 'I')
            {
                DotsDots();
            }
            return info;
        }

        public void DotsDots()
        {
            
            Console.SetCursorPosition(0, 0);
            Console.WriteLine();
            //Console.SetCursorPosition(0, 0);
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
        }


        public void dotsdots()
        {
            
            Console.SetCursorPosition(0, 0);
            Console.WriteLine();
            //Console.SetCursorPosition(0, 0);
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            
        }

        public void D250ots()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("..........................................................................................................................................................................................................................................................");
            Console.SetCursorPosition(0, 29);
            Console.WriteLine("maximum of 250 characters ");
            Console.SetCursorPosition(0, 0);
        }

        // avoid crash by string
        public static int intResult()
        {
            bool stringLoop;
            do
            {
                int intiger = 0;
                string input = Console.ReadLine();

                if (int.TryParse(input, out intiger))
                {
                    stringLoop = false;
                    return intiger;
                }
                else
                {
                    Console.WriteLine("not a number!");
                    stringLoop = true;
                }
                    
            } while (stringLoop == true);
            return  0;
        }

        public void PositionQuestions ()
        {
            Console.SetCursorPosition(0, 7);
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





        // ShowHideInfoMenu  includes InfoList & DotsDots


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
