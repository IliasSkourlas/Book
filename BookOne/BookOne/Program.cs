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
            dataAccess.Conection();  // Better


            bool againMenu = true;
            do
            {
                ApplicationMenu applicationMenu = new ApplicationMenu();
                applicationMenu.AccordingToRole();

                Console.WriteLine("chice..");
                string choice = Console.ReadLine();

                //View
                if (choice == "v")
                {
                    Console.Clear();
                    Book.GetInfoAllBooks();

                    Console.ReadKey();
                    againMenu = true;

                    //Give

                    //Carry

                    //List of my books

                    //call back

                    //update

                    //go to back to login
                    if (choice == "b")
                    {
                        LoginAccount.Login();
                        againMenu = true;

                    }
                    //esc app
                    if (choice == "e")
                    {
                        Console.Clear();
                        againMenu = false;
                    }
                    else
                    {
                        againMenu = true;
                    }
                }
                Console.ReadKey();
            } while (againMenu == true);
          
        }

    }
}
