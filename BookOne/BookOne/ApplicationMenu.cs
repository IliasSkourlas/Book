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


        // View acording to Roles
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
        public void SuperAdmin()
        {
            Console.WriteLine("press...v...to view");
            Console.WriteLine("press...g...to give a book");
            Console.WriteLine("press...c...to carry a book");
            Console.WriteLine("press...m...to see my books");
            Console.WriteLine("press...d...to call back\n");
            Console.WriteLine("................................");
            Console.WriteLine("type...all...to view all ????"); //yet
            Console.WriteLine("type...create...to create a new user"); //yet
            Console.WriteLine("type...delete...to delete a user"); //yet
            Console.WriteLine("type...update...to alter a roles");
            Console.WriteLine("................................");
            Console.WriteLine("press...b...to go back to login\n");
            Console.WriteLine("press...e...to esc the app");
        }



        //        public void MenuOne()    
        //        {
        //            bool againMenu = true;
        //            do
        //            {
        //                string text = message.MessageData;
        //                int receiver = message.ReceiverLoginID;
        //                int ID = dbo_Login.LoginID;
        //                int RoleType = dbo_Login.GetRole(ID);


        //                //Acording to Roles //for now with ID
        //                Console.Clear();
        //                if (RoleType == 4)
        //                {
        //                    ViewOnlyUser();
        //                }
        //                if (RoleType == 3)
        //                {
        //                    ViewEditUser();
        //                }
        //                if (RoleType == 2)
        //                {
        //                    ViewEditDeleteUser();
        //                }
        //                if (RoleType == 1)
        //                {
        //                    SuperAdmin();
        //                }

        //                //View
        //                string choice = Console.ReadLine();
        //                if (choice == "v")
        //                {
        //                    Console.Clear();
        //                    dbo_Message.ViewMessagesbyReceiverLoginID(ID);
        //                    Console.ReadKey();
        //                    againMenu = true;

        //                }
        //                //Send()
        //                if (choice == "s")
        //                {
        //                    BackupFile backupFile = new BackupFile();
        //                    Console.Clear();
        //                    Console.WriteLine("Sent text to ID?");
        //                    Console.Write("ID:");
        //                    receiver = Convert.ToInt32(Console.ReadLine());//catch leters
        //                    Console.WriteLine("text:");
        //                    text = Console.ReadLine();
        //                    dbo_Message.SendAMessage(text, ID, receiver);
        //                    backupFile.Backup(message.DateOfSubmition, ID, receiver, text);
        //                    Console.Clear();
        //                    Console.WriteLine("message has been sent successfully");
        //                    Console.ReadKey();
        //                    againMenu = true;
        //                }
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
