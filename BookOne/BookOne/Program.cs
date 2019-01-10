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
                        int bookID = ApplicationMenu.intResult(); //catch //what if book not my?
                        if (Book.GetCarrierLoginIDByBookID(bookID) == ID)
                        {
                            if (Book.GetOwnerLoginIDByBookID(bookID) == ID)
                            {
                                //Set pool of carriers
                                int owner = ID;
                                Console.WriteLine("Do you want do add an ID to the pool? ");
                                ConsoleKeyInfo addInPool = Console.ReadKey();
                                if (addInPool.KeyChar == 'y' || addInPool.KeyChar == 'Y')
                                {
                                    Console.WriteLine("Add ID: ");
                                    int handTo = ApplicationMenu.intResult();

                                    Book.PoolOfCarriers(owner, handTo, bookID);
                                }
                            }

                            Book.SentBookSignalYes(bookID);
                            Console.Write("Ok...your hand is on the book");
                        }
                        else
                        {
                            Console.Write("You don't carry this book ");
                        }

                        loopInfo = true;
                    }
                    // Accept Signal Yes
                    if (info.KeyChar == 'a' || info.KeyChar == 'A')
                    {
                        bool smallLoop = true;
                        do
                        {
                            content = 1;
                            // Book.ViewYourBooks(ID, content);
                            //Console.SetCursorPosition(0, 29);

                            Console.WriteLine("For which book ID? ");
                            int bookID = ApplicationMenu.intResult();  //catch

                            if (((Book.GetSentSignal(bookID) == 1 && (Book.GetHandToByBookID(bookID) == ID)) || ((Book.GetSentSignal(bookID) == 1) && Book.GetOwnerLoginIDByBookID(bookID) == ID)))
                            {
                                int carrierID = Book.GetCarrierLoginIDByBookID(bookID);
                                Console.WriteLine("Press...y...to accept the book or ...n...to decline the offer. ");
                                ConsoleKeyInfo offer = Console.ReadKey();

                                if (offer.KeyChar == 'y' || offer.KeyChar == 'Y')
                                {
                                    Book.ReceiveBookSignalYes(bookID);

                                    if ((Book.GetSentReceiveSignal(bookID) == 2) &&
                                        (Book.GetOwnerLoginIDByBookID(bookID) != Book.GetCarrierLoginIDByBookID(bookID)) &&
                                        (Book.GetOwnerLoginIDByBookID(bookID) == ID))
                                    {
                                        Console.WriteLine("Do you want to give a Clap?");
                                        Console.WriteLine("...y...for yes \n...n...for no. ");
                                        ConsoleKeyInfo clapFor = Console.ReadKey();

                                        if (clapFor.KeyChar == 'y' || clapFor.KeyChar == 'Y')
                                        {
                                            LoginAccount.AddClap(carrierID);
                                            Console.WriteLine("Clap..clap..clap..clap!");
                                        }
                                        else
                                        {
                                            Console.Write($"..mmmm...no clap for ID: {carrierID} ");
                                            // is it ok to leave it empty?
                                        }
                                    }
                                    int carrierLoginID = ID;
                                    DateTime dateOfLastMove = DateTime.Now;
                                    Book.ChaingeCarrier(carrierLoginID, bookID, dateOfLastMove);
                                    Console.Write(" ...you carry the book");
                                    Book.AddCirculation(bookID);
                                    Book.ReceiveBookSignalNo(bookID);

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
                            }
                            else
                            {
                                Console.WriteLine("!You can't have this book right now!");
                                smallLoop = false;
                            }
                        } while (smallLoop == true);

                        loopInfo = true;
                    }
                    // Hand Book
                    if (info.KeyChar == 'h' || info.KeyChar == 'H')
                    {
                        content = 1;

                        Book.ViewYourBooks(ID, content);
                        Console.SetCursorPosition(0, 29);

                        loopInfo = true;
                    }
                    // Write Words
                    if (info.KeyChar == 'w' || info.KeyChar == 'W')
                    {
                        Book.ViewYourBooks(ID, content);
                        Console.SetCursorPosition(0, 29);


                        Console.Write("For which book ID?: ");
                        int bookID = ApplicationMenu.intResult();

                        if(Book.GetCarrierLoginIDByBookID(bookID) == ID)
                        {
                            int length = 250;
                            Console.Clear();
                            Console.WriteLine("words: ");
                            Console.WriteLine("maximum of 250 characters ");
                            string newWords = Console.ReadLine();
                            Book.Truncater(newWords, length);
                            Book.WriteWords(bookID, Book.Truncater(newWords, length));
                        }
                        else
                        {
                            Console.WriteLine("! You can only write on the books you carry !");
                        }
                    }
                    // Find Book from All
                    if (info.KeyChar == 'f' || info.KeyChar == 'F')
                    {
                        Console.Write("Search: ");
                        Console.Clear(); 
                        Book.GetBookByTitle(Console.ReadLine());
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

                        Console.Clear();
                        Console.WriteLine("words: ");
                        int length = 250;
                        string Words = Console.ReadLine();
                        string limitWords = Book.Truncater(Words, length);

                        DateTime dateOfSubmition = DateTime.Now; //now?
                        int ownerLoginID = LoginAccount.LoginID;
                        int carrierLoginID = LoginAccount.LoginID;
                        int bookstatus = 0;
                        int sent = 0;
                        int receive = 0;

                        Book.EnterBook(title, author, limitWords, dateOfSubmition, ownerLoginID, carrierLoginID, bookstatus, sent, receive);

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
