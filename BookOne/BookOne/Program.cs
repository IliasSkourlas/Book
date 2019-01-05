using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOne
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();
            ApplicationMenu applicationMenu = new ApplicationMenu();

            // Login
            dataAccess.AccesGetLoginID();

           // LoginAccount.GetRole(LoginAccount.RoleID);

            bool againMenu = true;
            do
            {
                // Menu Acording to Roles 
                Console.Clear();
                if (LoginAccount.RoleType == 4)
                {
                    applicationMenu.ViewOnlyUser();
                }
                if (LoginAccount.RoleType == 3)
                {
                    applicationMenu.ViewEditUser();
                }
                if (LoginAccount.RoleType == 2)
                {
                    applicationMenu.ViewEditDeleteUser();
                }
                if (LoginAccount.RoleType == 1)
                {
                    applicationMenu.SuperAdmin();
                }



                string choice = Console.ReadLine();

                //View
                if (choice == "v")
                {
                    Console.Clear();
                    Book.ViewAllItems();

                    Console.ReadKey();
                    againMenu = true;

                    //Give

                    //Carry

                    //List of my books

                    //call back

                    //update

                    //esc

                    //back

                }
                Console.ReadKey();

            } while (againMenu == true);
        }

    }
}
