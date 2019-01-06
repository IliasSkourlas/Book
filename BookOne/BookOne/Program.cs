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

                Book book = new Book();
                Console.Clear();
                applicationMenu.AccordingToRole();
                string choice = Console.ReadLine();

                //View
                if (choice == "v")
                {
                    Console.Clear();
                    Book.GetInfoAllBooks();
                    Console.ReadKey();
                    againMenu = true;
                }
                //Give
                if (choice == "g")
                {
                    Console.Clear();
                    Console.WriteLine("Give a book in the pool");
                    Console.WriteLine("With title: ");
                    string title = Console.ReadLine();
                    Console.WriteLine("By author: ");
                    string author = Console.ReadLine();
                    DateTime dateOfSubmition = DateTime.Now;
                    Console.WriteLine("Inscription message: ");
                    string inscription = Console.ReadLine();
                    int ownerLoginID = LoginAccount.LoginID;
                    int carrierLoginID = LoginAccount.LoginID;
                    int bookstatus = 0;

                    Book.GiveAbookInThePool(title, author, dateOfSubmition, inscription, ownerLoginID, carrierLoginID, bookstatus);
                    //BackupFile backupFile = new BackupFile();
                    //backupFile.Backup(message.DateOfSubmition, ID, receiver, text);
                    Console.Clear();
                    Console.WriteLine("your book is in the pool");
                    Console.ReadKey();
                    againMenu = true;
                }
                //Carry
                if (choice == "c")
                {
                    Console.Clear();
                    Console.WriteLine("Carrie a book from the pool");
                    Console.WriteLine("With title: ");
                    string title = Console.ReadLine();
                    Book.GetBookByTitle(title);
                    string x = book.Title;
                    Console.WriteLine($"Do you want :{x}");

                    Console.ReadKey();
                    againMenu = true;
                }

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



            } while (againMenu == true);

                Console.ReadKey();
        }
    }
}
