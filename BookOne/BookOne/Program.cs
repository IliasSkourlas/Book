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
            ApplicationMenu applicationMenu = new ApplicationMenu();
            Book book = new Book();




            bool againMenu = true;
            do
            {
                Console.Clear();
                DataAccess dataAccess = new DataAccess();
                LoginAccount.Login();

                int ID = LoginAccount.LoginID;
                LoginAccount.GetRole(ID);


                //Console.SetCursorPosition(0, 0);
                //Console.WriteLine("i...info: ");

                // applicationMenu.DotsDots();

                int content = 0;
                //Book.GetInfoAllBooks(content);



                bool loopInfo = true;
                do
                {
                    content = 0;
                    ConsoleKeyInfo info = Console.ReadKey();
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("i...info: ");
                    applicationMenu.DotsDots();
                    Book.GetInfoAllBooks(content);
                    Console.SetCursorPosition(0, 29);

                    if (info.KeyChar == 'i' || info.KeyChar == 'I')
                    {
                        for (int i = 0; i < applicationMenu.InfoList().Count; i++)
                        {
                            content = 0;
                            Console.SetCursorPosition(0, i + 7);
                            Console.Write(applicationMenu.InfoList()[i]);
                        }
                        Console.WriteLine();
                        Console.SetCursorPosition(0, 29);
                        info = Console.ReadKey();

                        if (info.KeyChar == 'i' || info.KeyChar == 'I')
                        {
                            Console.Clear();
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("i...info: ");
                            applicationMenu.DotsDots();
                            Book.GetInfoAllBooks(content);
                            Console.SetCursorPosition(0, 29);
                        }
                        loopInfo = true;
                    }

                    if (info.Key == ConsoleKey.Escape)
                    {
                        loopInfo = false;
                        againMenu = false;
                    }

                    // go to back to login
                    if (info.KeyChar == 'b' || info.KeyChar == 'B')
                    {
                        Console.Clear();
                        loopInfo = false;
                        againMenu = true;
                    }

                    // My books
                    if (info.KeyChar == 'm' || info.KeyChar == 'M')
                    {
                        content = 1;
                        Console.Clear();
                        Book.ViewYourBooks(ID, content);
                    }

                    // Sent Signal yes
                    if (info.KeyChar == 's' || info.KeyChar == 'S')
                    {
                        content = 1;

                        Book.ViewYourBooks(ID, content);
                        Console.SetCursorPosition(0, 29);


                        Console.Write("For which book ID?: ");
                        int bookID = Convert.ToInt32(Console.ReadLine()); //catch //what if book not my?
                        if (Book.GetOwnerLoginIDByBookID(bookID) == ID)
                        {
                            // Book.SentBookSignalYes(bookID);
                            Book.SentBookSignalYes(bookID);
                            Console.Write(" Signal has been sent");
                        }
                        else
                        {
                            Console.Write(" is this your book?");
                        }

                        loopInfo = true;
                    }
                    // Test
                    if (info.KeyChar == 't' || info.KeyChar == 'T')
                    {
                        Console.WriteLine(ID);
                    }

                    // Accept Signal Yes
                    if (info.KeyChar == 'a' || info.KeyChar == 'A')
                    {
                        bool smallLoop = true;
                        do
                        {

                            content = 1;
                            Book.ViewYourBooks(ID, content);
                            Console.SetCursorPosition(0, 29);

                            Console.Write("For which book ID?: ");
                            int bookID = Convert.ToInt32(Console.ReadLine()); //catch
                            Console.Write("Press...y...to accept the book or ...n...to decline the offer. ");
                            ConsoleKeyInfo offer = Console.ReadKey();

                            if (offer.KeyChar == 'y' || offer.KeyChar == 'Y')
                            {

                                Book.ReceiveBookSignalYes(bookID);
                                Console.WriteLine("you have accepted this book");
                                smallLoop = false;

                            }
                            else if (offer.KeyChar == 'n' || offer.KeyChar == 'N')
                            {
                                Book.ReceiveBookSignalNo(bookID);
                                Console.WriteLine("you have declined this book");
                                smallLoop = false;

                            }
                            else
                            {
                                smallLoop = true;
                            }
                        } while (smallLoop == true);

                        loopInfo = true;
                    }
                    //Enter a book
                    if (info.KeyChar == 'e' || info.KeyChar == 'E')
                    {

                        content = 1;
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Enter a book in the pool: ");
                        Book.GetInfoAllBooks(content);
                        applicationMenu.DotsDots();
                        Console.SetCursorPosition(0, 2);
                        Console.WriteLine("Title: ");
                        string title = Console.ReadLine();
                        Console.WriteLine("Author: ");
                        string author = Console.ReadLine();
                        Console.WriteLine("Incription: ");
                        string inscription = Console.ReadLine();
                        DateTime dateOfSubmition = DateTime.Now; //now?
                        int ownerLoginID = LoginAccount.LoginID;
                        int carrierLoginID = LoginAccount.LoginID;
                        int bookstatus = 0;
                        int sent = 0;
                        int receive = 0;

                        Book.EnterBook(title, author, inscription, dateOfSubmition, ownerLoginID, carrierLoginID, bookstatus, sent, receive);

                        Console.SetCursorPosition(0, 29);
                        Console.Write("We all have a new book");
                        applicationMenu.DotsDots();

                        loopInfo = true;
                    }

                } while (loopInfo == true);











                //string choice = Console.ReadLine();
                ////View
                //if (choice == "v")
                //{
                //    Console.Clear();
                //    Book.GetInfoAllBooks();
                //    Console.ReadKey();
                //    againMenu = true;
                //}
                ////Give
                //if (choice == "g")
                //{
                //    Console.Clear();
                //    Console.WriteLine("Give a book in the pool");
                //    Console.WriteLine("With title: ");
                //    string title = Console.ReadLine();
                //    Console.WriteLine("By author: ");
                //    string author = Console.ReadLine();
                //    DateTime dateOfSubmition = DateTime.Now;
                //    Console.WriteLine("Inscription message: ");
                //    string inscription = Console.ReadLine();
                //    int ownerLoginID = LoginAccount.LoginID;
                //    int carrierLoginID = LoginAccount.LoginID;
                //    int bookstatus = 0;

                //    Book.GiveAbookInThePool(title, author, dateOfSubmition, inscription, ownerLoginID, carrierLoginID, bookstatus);
                //    //BackupFile backupFile = new BackupFile();
                //    //backupFile.Backup(message.DateOfSubmition, ID, receiver, text);
                //    Console.Clear();
                //    Console.WriteLine("your book is in the pool");
                //    Console.ReadKey();
                //    againMenu = true;
                //}
                ////Carry
                //if (choice == "c")
                //{
                //    Console.Clear();
                //    Console.WriteLine("Carrie a book from the pool");
                //    Console.WriteLine("With title: ");
                //    string title = Console.ReadLine();
                //    Book.GetBookByTitle(title);
                //    string x = book.Title;
                //    Console.WriteLine($"Do you want :{x}");

                //    Console.ReadKey();
                //    againMenu = true;
                //}

                ////List of my books

                ////call back

                ////update

                ////go to back to login
                ////if (info.KeyChar == 'b' || info.KeyChar == 'B')
                ////{
                ////    Console.Clear();
                ////    dataAccess.Conection();
                ////}
                ////esc app
                //if (choice == "e")
                //{
                //    Console.Clear();
                //    againMenu = false;
                //}
                //else
                //{
                //    againMenu = true;
                //}



            } while (againMenu == true);

            Console.Clear();

            Console.ReadKey();
        }
    }
}
