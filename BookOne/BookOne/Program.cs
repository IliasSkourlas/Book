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

                int content = 0;

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
                            Console.SetCursorPosition(15, 0);
                            Console.Write("all the books");
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
                        Console.SetCursorPosition(0, 0);
                        Console.Write("m...info: ");
                        applicationMenu.DotsDots();
                        Console.SetCursorPosition(15, 0);
                        Console.Write("my books");
                        Console.SetCursorPosition(34, 0);
                        Console.Write("no.");
                        Book.ViewYourBooks(ID, content);
                    }

                    // books in my hand
                    if (info.KeyChar == 'h' || info.KeyChar == 'H')
                    {
                        content = 1;
                        int carrierID = ID;
                        Console.Clear();
                        applicationMenu.DotsDots();
                        Console.SetCursorPosition(0, 0);
                        Console.Write("h...info: ");
                        Console.SetCursorPosition(15, 0);
                        Console.Write("books in my hand");
                        Console.SetCursorPosition(34, 0);
                        Console.Write("no.");
                        Book.ViewBooksByCarrierID(carrierID, content);
                    }

                    // Read
                    if (info.KeyChar == 'r' || info.KeyChar == 'R')
                    {
                        content = 3;
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.Write("r...info: ");
                        applicationMenu.DotsDots();
                        Console.SetCursorPosition(13, 0);
                        Console.Write("read");
                        Console.SetCursorPosition(34, 0);
                        Console.Write("");
                        Book.GetInfoAllBooks(content);
                    }

                    // circulation
                    if (info.KeyChar == 'o' || info.KeyChar == 'O')
                    {
                        content = 4;
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.Write("o...info: ");
                        applicationMenu.DotsDots();
                        Console.SetCursorPosition(43, 0);
                        Console.Write("no.");
                        Console.SetCursorPosition(48, 0);
                        Console.Write("circulation");
                        Console.SetCursorPosition(63, 0);
                        Console.Write("date");
                        Console.SetCursorPosition(75, 0);
                        Console.Write("status");


                        Book.GetInfoAllBooks(content);
                    }

                    // Sent Signal yes
                    bool sCondition = (info.KeyChar == 's' || info.KeyChar == 'S');
                    if (LoginAccount.RoleType != 4 && sCondition)
                    {
                        content = 1;
                        Console.Clear();
                        applicationMenu.DotsDots();
                        Console.SetCursorPosition(0, 0);
                        Console.Write("s...info: ");
                        Console.SetCursorPosition(15, 0);
                        Console.Write("sent a book?");
                        Console.SetCursorPosition(34, 0);
                        Console.Write("no.");
                        int carrierID = ID;
                        Book.ViewBooksByCarrierID(carrierID, content);

                        applicationMenu.PositionQuestions();
                        Console.Write("For which book ID?: ");
                        int bookID = ApplicationMenu.intResult();
                        if (Book.GetCarrierLoginIDByBookID(bookID) == ID)
                        {
                            if (Book.GetOwnerLoginIDByBookID(bookID) == ID)
                            {
                                //Set pool of carriers
                                int owner = ID;
                                Console.Write("Do you want do add an ID to the pool? ");
                                ConsoleKeyInfo addInPool = Console.ReadKey();
                                if (addInPool.KeyChar == 'y' || addInPool.KeyChar == 'Y')
                                {
                                    Console.Write("Add ID: ");
                                    int handTo = ApplicationMenu.intResult();

                                    Book.PoolOfCarriers(owner, handTo, bookID);
                                }
                            }

                            Book.SentBookSignalYes(bookID);
                            Console.Write("Ok...your hand is on the book ");
                        }
                        else
                        {
                            Console.Write("You don't carry this book ");
                        }

                        loopInfo = true;
                    }

                    // Accept Signal Yes
                    bool aCondition = (info.KeyChar == 'a' || info.KeyChar == 'A');
                    if (LoginAccount.RoleType != 4 && aCondition)
                    {
                        bool smallLoop = true;
                        do
                        {
                            content = 1;
                            Console.Clear();
                            applicationMenu.DotsDots();
                            Console.SetCursorPosition(0, 0);
                            Console.Write("a...info: ");
                            Console.SetCursorPosition(15, 0);
                            Console.Write("accept a book?");
                            Console.SetCursorPosition(34, 0);
                            Console.Write("no.");
                            Book.GetInfoAllBooks(content);
                            Console.SetCursorPosition(0, 29);

                            applicationMenu.PositionQuestions();
                            Console.Write("For which book ID? ");
                            int bookID = ApplicationMenu.intResult();

                            if (((Book.GetSentSignal(bookID) == 1 && (Book.GetHandToByBookID(bookID) == ID)) || ((Book.GetSentSignal(bookID) == 1) && Book.GetOwnerLoginIDByBookID(bookID) == ID)))
                            {
                                int carrierID = Book.GetCarrierLoginIDByBookID(bookID);
                                Console.Write("Press...y...to accept the book or ...n...to decline the offer. ");
                                ConsoleKeyInfo offer = Console.ReadKey();

                                if (offer.KeyChar == 'y' || offer.KeyChar == 'Y')
                                {
                                    Book.ReceiveBookSignalYes(bookID);

                                    if ((Book.GetSentReceiveSignal(bookID) == 2) &&
                                        (Book.GetOwnerLoginIDByBookID(bookID) != Book.GetCarrierLoginIDByBookID(bookID)) &&
                                        (Book.GetOwnerLoginIDByBookID(bookID) == ID))
                                    {
                                        Console.Write("Do you want to give a Clap?");
                                        Console.Write("...y...for yes \n...n...for no. ");
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
                                    Console.Write(" ...you carry the book ");
                                    Book.AddCirculation(bookID);
                                    Book.ReceiveBookSignalNo(bookID);

                                    smallLoop = false;
                                }
                                else if (offer.KeyChar == 'n' || offer.KeyChar == 'N')
                                {
                                    Book.ReceiveBookSignalNo(bookID);
                                    Console.Write("you have declined this book ");
                                    smallLoop = false;
                                }
                                else
                                {
                                    smallLoop = true;
                                }
                            }
                            else
                            {
                                Console.Write("!You can't have this book right now! ");
                                smallLoop = false;
                            }
                        } while (smallLoop == true);

                        loopInfo = true;
                    }

                    // carriers of my books
                    if (info.KeyChar == 'c' || info.KeyChar == 'C')
                    {
                        content = 2;
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("c...info: ");
                        applicationMenu.DotsDots();
                        Console.SetCursorPosition(13, 0);
                        Console.WriteLine("carriers of my books");
                        Console.SetCursorPosition(34, 0);
                        Console.Write("id:");
                        Book.ViewYourBooks(ID, content);

                    }// change

                    // Write Words
                    bool wCondition = (info.KeyChar == 'w' || info.KeyChar == 'W');
                    if (LoginAccount.RoleType != 4 && wCondition)
                    {
                        content = 1;
                        int carrierID = ID;
                        Console.Clear();
                        applicationMenu.DotsDots();
                        Console.SetCursorPosition(0, 0);
                        Console.Write("w...info: ");
                        Console.SetCursorPosition(15, 0);
                        Console.Write("some words?");
                        Console.SetCursorPosition(34, 0);
                        Console.Write("no.");
                        Book.ViewBooksByCarrierID(carrierID, content);
                        applicationMenu.PositionQuestions();
                        Console.Write("For book number? ");

                        int bookID = ApplicationMenu.intResult();

                        if (Book.GetCarrierLoginIDByBookID(bookID) == ID)
                        {
                            int length = 250;
                            Console.Clear();
                            applicationMenu.D250ots();

                            string newWords = Console.ReadLine();
                            Book.Truncater(newWords, length);
                            Book.WriteWords(bookID, Book.Truncater(newWords, length));
                        }
                        else
                        {
                            System.Threading.Thread.Sleep(1000);
                            Console.Write("! You can only write on the books you carry !");
                        }
                    }

                    // Find Book from All
                    if (info.KeyChar == 'f' || info.KeyChar == 'F')
                    {
                        Console.Write("Search: ");
                        Console.Clear();
                        Book.GetBookByTitle(Console.ReadLine());
                    }

                    // Role three: Enter a book 
                    bool eCondition = (info.KeyChar == 'e' || info.KeyChar == 'E');
                    if (LoginAccount.RoleType == 3 && eCondition)
                    {

                        content = 1;
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Enter a book in the pool: ");
                        Book.GetInfoAllBooks(content);
                        applicationMenu.DotsDots();
                        applicationMenu.PositionQuestions();
                        Console.WriteLine("Title: ");
                        string title = Console.ReadLine();
                        Console.WriteLine("Author: ");
                        string author = Console.ReadLine();

                        int length = 250;
                        Console.Clear();
                        applicationMenu.D250ots();

                        string Words = Console.ReadLine();
                        string limitWords = Book.Truncater(Words, length);
                        DateTime dateOfSubmition = DateTime.Today;
                        int ownerLoginID = LoginAccount.LoginID;
                        int carrierLoginID = LoginAccount.LoginID;
                        int bookstatus = 0;
                        int sent = 0;
                        int receive = 0;

                        Book.EnterBook(title, author, limitWords, dateOfSubmition, ownerLoginID, carrierLoginID, bookstatus, sent, receive);
                        Console.Clear();

                        Console.SetCursorPosition(0, 0);
                        System.Threading.Thread.Sleep(1000);
                        Console.Write("We all have a new book");

                        Book.GetInfoAllBooks(content);

                        loopInfo = true;
                    }

                    // Enter a book 
                    if (LoginAccount.RoleType != 3 && LoginAccount.RoleType != 4 && eCondition)
                    {
                        content = 1;
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Enter a book in the pool: ");
                        Book.GetInfoAllBooks(content);
                        applicationMenu.DotsDots();
                        applicationMenu.PositionQuestions();
                        Console.WriteLine("Title: ");
                        string title = Console.ReadLine();
                        Console.WriteLine("Author: ");
                        string author = Console.ReadLine();


                        DateTime dateOfSubmition = DateTime.Today;
                        int ownerLoginID = LoginAccount.LoginID;
                        int carrierLoginID = LoginAccount.LoginID;
                        int sent = 0;
                        int receive = 0;
                        bool loopi;
                        do
                        {
                            Console.Write("Book status 0 or 1 ? ");
                            int status = ApplicationMenu.intResult();
                            if (status == 0 || status == 1)
                            {
                                int bookstatus = status;
                                int length = 250;
                                Console.Clear();
                                applicationMenu.D250ots();

                                applicationMenu.PositionQuestions();
                                string Words = Console.ReadLine();
                                string limitWords = Book.Truncater(Words, length);
                                Book.EnterBook(title, author, limitWords, dateOfSubmition, ownerLoginID, carrierLoginID, bookstatus, sent, receive);
                                loopi = false;
                            }
                            else
                            {
                                loopi = true;
                            }
                        } while (loopi == true);


                        Console.SetCursorPosition(0, 0);
                        System.Threading.Thread.Sleep(1000);
                        Console.Write("We all have a new book");

                        Book.GetInfoAllBooks(content);
                        loopInfo = true;
                    }

                    // Delete 
                    bool dCondition = (info.KeyChar == 'd' || info.KeyChar == 'D');
                    if ((LoginAccount.RoleType == 1 && dCondition) || (LoginAccount.RoleType == 2 && dCondition))
                    {
                        content = 1;
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.Write("d...info: ");
                        applicationMenu.DotsDots();
                        Console.SetCursorPosition(13, 0);
                        Console.Write("a book out of the pool");
                        Console.SetCursorPosition(34, 0);
                        Console.Write("no.");
                        Book.ViewYourBooks(ID, content);
                        applicationMenu.PositionQuestions();
                        Console.Write("Book number? ");

                        int toBeDeleted = ApplicationMenu.intResult();
                        if ((Book.GetOwnerLoginIDByBookID(toBeDeleted) == ID && (Book.GetCarrierLoginIDByBookID(toBeDeleted) == ID)))
                        {
                            Book.DeleteFromPoolByBookID(toBeDeleted);
                            Book.DeleteFromBookByBookID(toBeDeleted);

                            Console.WriteLine("your book is out of the pool ");
                        }
                        else
                        {
                            Console.WriteLine(" Is this book yours? ");
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine(" is it in your possession? ");
                        }
                        loopInfo = true;
                    }

                } while (loopInfo == true);


            } while (againMenu == true);

            Console.Clear();
            
            Console.WriteLine("Bye Bye");

            Console.ReadKey();
        }
    }
}
