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
            LoginAccount loginAccount = new LoginAccount();
            Book book = new Book();
            BackupFile backupFile = new BackupFile();



            bool againMenu = true;
            do
            {
                Console.Clear();
                DataAccess dataAccess = new DataAccess();
                LoginAccount.Login();

                // My ID
                int ID = LoginAccount.LoginID;

                // My Role
                int myRole = User.GetRole(ID);

                applicationMenu.DotsDots();
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press...i ");
                Console.ForegroundColor = ConsoleColor.White;
                Book.GetInfoAllBooks(0);
                Console.SetCursorPosition(0, 29);

                bool loopInfo = true;
                do
                {
                    int content = 0;
                    Console.ForegroundColor = ConsoleColor.White;

                    ConsoleKeyInfo info = Console.ReadKey();
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Press...i ");
                    Console.ForegroundColor = ConsoleColor.White;

                    Book.GetInfoAllBooks(content);
                    applicationMenu.DotsDots();
                    

                    Console.SetCursorPosition(0, 29);

                    if (info.KeyChar == 'i' || info.KeyChar == 'I')
                    {
                        for (int i = 0; i < applicationMenu.InfoList().Count; i++)
                        {
                            content = 0;

                            //applicationMenu.EptySpace();
                            //Book.GetInfoAllBooks(content);

                            Console.SetCursorPosition(36, 0);
                            Console.WriteLine("             ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition(0, 0);
                            Console.Write($"You are: {ID}        ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(43, 0);
                            Console.Write("All the books                                ");
                            Console.SetCursorPosition(0, i + 7);

                            Console.Write(applicationMenu.InfoList()[i]);
                            Console.SetCursorPosition(0, 29);
                            

                        }
                        Console.WriteLine();
                        Console.SetCursorPosition(0, 29);
                        info = Console.ReadKey();

                        if (info.KeyChar == 'i' || info.KeyChar == 'I')
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.SetCursorPosition(0, 0);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("i...info: ");

                            applicationMenu.ComonRandomPatern();

                            Book.GetInfoAllBooks(content);
                            Console.ForegroundColor = ConsoleColor.White;

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

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(0, 0);
                        Console.Write("m...info: ");                        
                        Console.SetCursorPosition(43, 0);
                        Console.Write("Id");
                        Console.SetCursorPosition(48, 0);
                        Console.Write("my books");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.SetCursorPosition(38, 0);
                        Console.WriteLine("book");
                        Console.ForegroundColor = ConsoleColor.White;
                        applicationMenu.DotsDots();

                        Console.ForegroundColor = ConsoleColor.Blue;
                        applicationMenu.randomLine();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Book.ViewYourBooks(ID, content);
                        Console.SetCursorPosition(0, 29);


                    }

                    // books in my hand
                    if (info.KeyChar == 'h' || info.KeyChar == 'H')
                    {
                        content = 4;
                        int carrierID = ID;
                        Console.Clear();
                       

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(0, 0);
                        Console.Write("in my hand");
                        Console.SetCursorPosition(43, 0);
                        Console.Write("Id");
                        Console.SetCursorPosition(48, 0);
                        Console.Write("book id");
                        Console.SetCursorPosition(58, 0);
                        Console.Write("books");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.SetCursorPosition(36, 0);
                        Console.WriteLine("owners");

                        Console.ForegroundColor = ConsoleColor.White;
                        applicationMenu.DotsDots();
                        Console.ForegroundColor = ConsoleColor.Red;
                        applicationMenu.randomDot();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        applicationMenu.randomParanthesis();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        applicationMenu.randomDot();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        applicationMenu.randomDot();
                        Console.ForegroundColor = ConsoleColor.White;


                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Book.ViewBooksByCarrierID(carrierID, content);
                        Console.SetCursorPosition(0, 29);

                    }
                    // Users 
                    if (info.KeyChar == 'u' || info.KeyChar == 'U')
                    {
                        content = 0;
                        Console.Clear();
                        applicationMenu.DotsDots();
                        Console.SetCursorPosition(0, 0);

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("u...info: ");

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(10, 0);
                        Console.Write("Users");
                        Console.SetCursorPosition(43, 0);
                        Console.Write("Id");
                        Console.SetCursorPosition(48, 0);
                        Console.Write("Name");
                        Console.SetCursorPosition(64, 0);
                        Console.Write("Role");
                        Console.SetCursorPosition(72, 0);
                        Console.Write("Carried");
                        Console.SetCursorPosition(80, 0);
                        Console.Write("Claps");

                        User.GetInfoAllUsers(content);

                    }

                    // Read
                    if (info.KeyChar == 'r' || info.KeyChar == 'R')
                    {
                        content = 3;
                        Console.SetCursorPosition(36, 0);
                        Console.WriteLine("      ");

                        applicationMenu.EptySpace();
                        
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(0, 0);
                        Console.Write("press...i...again ");
                        Console.SetCursorPosition(43, 0);
                        Console.Write("Comments             ");

                        applicationMenu.ComonRandomPatern();

                        Book.GetInfoAllBooks(content);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(0, 29);                                            

                    }

                    // circulation
                    if (info.KeyChar == 'o' || info.KeyChar == 'O')
                    {
                        content = 4;
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(0, 0);
                        Console.Write("book circualation");
                        Console.SetCursorPosition(43, 0);
                        Console.Write("Id");
                        Console.SetCursorPosition(48, 0);
                        Console.Write("book id");
                        Console.SetCursorPosition(58, 0);
                        Console.Write("circ.");
                        Console.SetCursorPosition(68, 0);
                        Console.Write("status");
                        Console.SetCursorPosition(78, 0);
                        Console.Write("date");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.SetCursorPosition(36, 0);
                        Console.WriteLine("owners");
                        Console.ForegroundColor = ConsoleColor.White;


                        applicationMenu.DotsDots();

                        Book.GetInfoAllBooks(content);
                        Console.SetCursorPosition(0, 29);

                        loopInfo = true;
                    }

                    // Write Words
                    bool wCondition = (info.KeyChar == 'w' || info.KeyChar == 'W');
                    if (myRole != 4 && wCondition)
                    {
                        content = 1;
                        int carrierID = ID;
                        Console.SetCursorPosition(36, 0);
                        Console.WriteLine("      ");
                        applicationMenu.EptySpace();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(0, 0);
                        Console.Write("Press...i");
                        Console.SetCursorPosition(43, 0);
                        Console.Write("              ");
                        Console.SetCursorPosition(43, 0);
                        Console.Write("Id");
                        Console.SetCursorPosition(48, 0);
                        Console.Write("Write a comment             ");

                        applicationMenu.ComonRandomPatern();

                        Book.ViewBooksByCarrierID(carrierID, content);
                        Console.ForegroundColor = ConsoleColor.Green;
                        applicationMenu.PositionQuestions();
                        Console.WriteLine("For book id? ");

                        int bookID = ApplicationMenu.intResult();

                        if (Book.GetCarrierLoginIDByBookID(bookID) == ID)
                        {
                            int length = 250;
                            Console.Clear();
                            applicationMenu.D250ots();
                            string newWords = Console.ReadLine();
                            Book.Truncater(newWords, length);
                            Book.WriteWords(bookID, Book.Truncater(newWords, length));

                            Console.Clear();
                            applicationMenu.EptySpace();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(0, 0);
                            Console.Write("Ok..");
                            Console.SetCursorPosition(43, 0);
                            Console.Write("Comments             ");

                            applicationMenu.ComonRandomPatern();

                            Book.GetInfoAllBooks(3);
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.SetCursorPosition(0, 29);
                        }
                        else
                        {
                            System.Threading.Thread.Sleep(1000);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You can only write on the books you carry.");
                            System.Threading.Thread.Sleep(3000);

                            applicationMenu.ComonRandomPatern();

                        }
                    }

                    // Sent Signal yes
                    bool sCondition = (info.KeyChar == 's' || info.KeyChar == 'S');
                    if (myRole != 4 && sCondition)
                    {

                        content = 1;
                        int carrierID = ID;
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(0, 0);
                        Console.Write("s...info: ");
                        Console.SetCursorPosition(43, 0);
                        Console.Write("Id");
                        Console.SetCursorPosition(48, 0);
                        Console.Write("books in my hand");
                        Console.ForegroundColor = ConsoleColor.White;
                        applicationMenu.DotsDots();


                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Book.ViewBooksByCarrierID(carrierID, content);
                        Console.SetCursorPosition(0, 29);
                     

                        applicationMenu.PositionQuestions();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("For which book ID?: ");
                        int bookID = ApplicationMenu.intResult();
                        if (Book.GetCarrierLoginIDByBookID(bookID) == ID)
                        {
                            if (Book.GetOwnerLoginIDByBookID(bookID) == ID)
                            {
                                //Set pool of carriers
                                int owner = ID;
                                Console.WriteLine("Do you want to add an ID to the pool?");
                                Console.WriteLine("Y_or_N? ");
                                ConsoleKeyInfo addInPool = Console.ReadKey();
                                if (addInPool.KeyChar == 'y' || addInPool.KeyChar == 'Y')
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Add ID: ");
                                    int handTo = ApplicationMenu.intResult();

                                    Book.PoolOfCarriers(owner, handTo, bookID);
                                }
                            }

                            Book.SentBookSignalYes(bookID);
                            Console.WriteLine();
                            Console.WriteLine("Ok...your hand is on the book ");
                            System.Threading.Thread.Sleep(2000);

                            applicationMenu.ComonRandomPatern();
                            Console.SetCursorPosition(0, 29);

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("This book is out of your hands ");
                            System.Threading.Thread.Sleep(2000);

                            applicationMenu.ComonRandomPatern();
                            Console.SetCursorPosition(0, 29);


                        }

                        loopInfo = true;
                    }

                    // Accept Signal Yes
                    bool aCondition = (info.KeyChar == 'a' || info.KeyChar == 'A');
                    if (myRole != 4 && aCondition)
                    {
                        bool smallLoop = true;
                        do
                        {
                            content = 1;
                            //Console.Clear();
                            Console.SetCursorPosition(34, 0);
                            Console.WriteLine("        ");

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(0, 0);
                            Console.Write("accept a book");
                            Console.SetCursorPosition(43, 0);
                            Console.Write("Id   ");
                            Console.SetCursorPosition(48, 0);
                            Console.Write("All books        ");
                            Console.ForegroundColor = ConsoleColor.White;
                            applicationMenu.DotsDots();

                            applicationMenu.ComonRandomPatern();

                            applicationMenu.EptySpace();
                            Book.GetInfoAllBooks(content);
                            Console.SetCursorPosition(0, 29);

                            Console.ForegroundColor = ConsoleColor.Green;
                            applicationMenu.PositionQuestions();
                            Console.Write("For which book ID? ");
                            int bookID = ApplicationMenu.intResult();


                            if (((Book.GetSentSignal(bookID) == 1 && (Book.GetHandToByBookID(bookID) == ID)) || ((Book.GetSentSignal(bookID) == 1) && Book.GetOwnerLoginIDByBookID(bookID) == ID)))
                            {
                                int carrierID = Book.GetCarrierLoginIDByBookID(bookID);
                                Console.WriteLine("do you accept this book? ");
                                Console.WriteLine("Y_or_N? ");
                                ConsoleKeyInfo offer = Console.ReadKey();

                                if (offer.KeyChar == 'y' || offer.KeyChar == 'Y')
                                {
                                    Book.ReceiveBookSignalYes(bookID);

                                    if ((Book.GetSentReceiveSignal(bookID) == 2) &&
                                        (Book.GetOwnerLoginIDByBookID(bookID) != Book.GetCarrierLoginIDByBookID(bookID)) &&
                                        (Book.GetOwnerLoginIDByBookID(bookID) == ID))
                                    {

                                        Console.WriteLine();
                                        Console.WriteLine("Do you want to give a Clap?");
                                        Console.WriteLine("Y_or_N?");
                                        
                                        ConsoleKeyInfo clapFor = Console.ReadKey();

                                        if (clapFor.KeyChar == 'y' || clapFor.KeyChar == 'Y')
                                        {
                                            User.AddClap(carrierID);
                                            Console.WriteLine();
                                            Console.WriteLine("Clap..clap..clap..clap!");

                                            
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"...no clap for ID: {carrierID} ");
                                            Console.ForegroundColor = ConsoleColor.White;

                                        }


                                    }

                                    if (Book.GetOwnerByBookID(bookID) != ID)
                                    {
                                        User.AddOneMoreCarriedBook(ID);
                                    }

                                    int carrierLoginID = ID;
                                    DateTime dateOfLastMove = DateTime.Now;
                                    Book.ChaingeCarrier(carrierLoginID, bookID, dateOfLastMove);
                                    Console.WriteLine();
                                    Console.WriteLine(" ...you carry the book ");
                                    System.Threading.Thread.Sleep(2000);

                                    applicationMenu.ComonRandomPatern();
                                    Console.SetCursorPosition(0, 29);

                                    Book.AddCirculation(bookID);
                                    Book.ReceiveBookSignalNo(bookID);

                                    smallLoop = false;
                                }
                                else if (offer.KeyChar == 'n' || offer.KeyChar == 'N')
                                {
                                    Book.ReceiveBookSignalNo(bookID);
                                    Console.WriteLine("you have declined this book ");
                                    System.Threading.Thread.Sleep(2000);

                                    applicationMenu.ComonRandomPatern();
                                    Console.SetCursorPosition(0, 29);

                                    smallLoop = false;
                                }
                                else
                                {
                                    smallLoop = true;
                                }
                            }
                            else
                            {

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("!You can't have this book right now! ");

                                System.Threading.Thread.Sleep(2000);

                                applicationMenu.ComonRandomPatern();
                                Console.SetCursorPosition(0, 29);

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
                       
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("carriers        ");
                        Console.SetCursorPosition(43, 0);
                        Console.Write("id");
                        Console.SetCursorPosition(48, 0);
                        Console.WriteLine("my books");
                        Console.ForegroundColor = ConsoleColor.White;
                        applicationMenu.DotsDots();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        applicationMenu.randomSideLine();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.SetCursorPosition(35, 0);
                        Console.WriteLine("carrier");
                        Book.ViewYourBooks(ID, content);
                        Console.SetCursorPosition(0, 29);

                    }

                    //// Find Book from All                                           // Yet
                    if (info.KeyChar == 'f' || info.KeyChar == 'F')
                    {
                        Console.Clear();
                        Console.Write("Search: ");
                        Book.FindBookByTitle(Console.ReadLine());
                    }

                    // Role three: Enter a book 
                    bool eCondition = (info.KeyChar == 'e' || info.KeyChar == 'E');
                    if (myRole == 3 && eCondition)
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

                        string Words = Console.ReadLine();
                        string words = "";
                        DateTime dateOfSubmition = DateTime.Today;
                        int ownerLoginID = LoginAccount.LoginID;
                        int carrierLoginID = LoginAccount.LoginID;
                        int bookstatus = 0;
                        int circulation = 0;
                        int sent = 0;
                        int receive = 0;

                        Book.EnterBook(title, author, words, dateOfSubmition, ownerLoginID, carrierLoginID, bookstatus, circulation, sent, receive);
                        backupFile.BackupFileEnterBook(dateOfSubmition, ID, title, author, bookstatus);

                        Console.Clear();

                        Console.SetCursorPosition(0, 0);
                        System.Threading.Thread.Sleep(1000);
                        Console.Write("We all have a new book");

                        Book.GetInfoAllBooks(content);

                        loopInfo = true;
                    }

                    // Enter a book 
                    if (myRole != 3 && myRole != 4 && eCondition)
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
                            Console.WriteLine("Book status 0 or 1 ? ");
                            int status = ApplicationMenu.intResult();
                            if (status == 0 || status == 1)
                            {
                                int circulation = 0;
                                int bookstatus = status;
                                Console.Clear();



                                string Words = " ";
                                Book.EnterBook(title, author, Words, dateOfSubmition, ownerLoginID, carrierLoginID, bookstatus, circulation, sent, receive);

                                backupFile.BackupFileEnterBook(dateOfSubmition, ID, title, author, bookstatus);

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

                    // Delete Book
                    bool dCondition = (info.KeyChar == 'd' || info.KeyChar == 'D');
                    if ((myRole == 1 && dCondition) || (myRole == 2 && dCondition))
                    {
                        content = 1;
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.Write("d...info: ");
                        applicationMenu.DotsDots();
                        Console.SetCursorPosition(12, 0);
                        Console.Write("out of the pool");
                        Console.SetCursorPosition(34, 0);
                        Console.Write("no.");
                        Book.ViewYourBooks(ID, content)
                            ;
                        applicationMenu.PositionQuestions();
                        Console.Write("Book number? ");

                        int toBeDeleted = ApplicationMenu.intResult();
                        if ((Book.GetOwnerLoginIDByBookID(toBeDeleted) == ID && (Book.GetCarrierLoginIDByBookID(toBeDeleted) == ID)))
                        {
                            DateTime date = DateTime.Today;
                            Book.DeleteFromPoolByBookID(toBeDeleted);
                            Book.DeleteFromBookByBookID(toBeDeleted);

                            backupFile.BackupFileDeleteBook(date, toBeDeleted);
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

                    // Delete User
                    if (info.KeyChar == '-' && ID == 1)
                    {
                        content = 0;
                        Console.Clear();
                        applicationMenu.DotsDots();
                        Console.SetCursorPosition(0, 0);
                        Console.Write("-...info: ");
                        Console.SetCursorPosition(13, 0);
                        Console.Write("Users");
                        Console.SetCursorPosition(43, 0);
                        Console.Write("Id");
                        Console.SetCursorPosition(48, 0);
                        Console.Write("Name");
                        Console.SetCursorPosition(60, 0);
                        Console.Write("Claps");
                        Console.SetCursorPosition(72, 0);
                        Console.Write("Has carried");
                        User.GetInfoAllUsers(content);

                        applicationMenu.PositionQuestions();
                        Console.WriteLine("Delete User ID: ");
                        int user = ApplicationMenu.intResult();

                        Console.WriteLine("You might also have to\n " +
                            "delete all the books\nhe carries\nand owns ");
                        Console.WriteLine("Do you want to procced?");
                        Console.WriteLine("..y...or..n..?");
                        ConsoleKeyInfo toDelete = Console.ReadKey();

                        if (toDelete.KeyChar == 'y' || toDelete.KeyChar == 'Y')
                        {
                            Book.DeleteInvolvedBooks(user);
                            User.DeleteUser(user);
                        }
                        if (toDelete.KeyChar == 'n' || toDelete.KeyChar == 'N')
                        {
                            loopInfo = true;
                        }
                    }

                    // Update User
                    if ((info.KeyChar == 'z' && ID == 1) || (info.KeyChar == 'Z' && ID == 1))
                    {
                        content = 0;
                        Console.Clear();
                        applicationMenu.DotsDots();
                        Console.SetCursorPosition(0, 0);
                        Console.Write("u...info: ");
                        Console.SetCursorPosition(13, 0);
                        Console.Write("Users");
                        Console.SetCursorPosition(43, 0);
                        Console.Write("Id");
                        Console.SetCursorPosition(48, 0);
                        Console.Write("Name");
                        Console.SetCursorPosition(64, 0);
                        Console.Write("Role");
                        Console.SetCursorPosition(72, 0);
                        Console.Write("Carried");
                        Console.SetCursorPosition(80, 0);
                        Console.Write("Claps");

                        User.GetInfoAllUsers(content);

                        applicationMenu.PositionQuestions();
                        Console.WriteLine("Update user ID: ");
                        int UserID = ApplicationMenu.intResult();
                        Console.WriteLine("Update user name: ");
                        string userName = Console.ReadLine();
                        Console.WriteLine("Update password: ");
                        string password = Console.ReadLine();
                        Console.WriteLine("role type: ");
                        int roleType = ApplicationMenu.intResult();
                        Console.WriteLine("Update clap: ");
                        int clap = ApplicationMenu.intResult();
                        Console.WriteLine("Update carrier: ");
                        int carrier = ApplicationMenu.intResult();
                        User.UpdateUser(UserID, userName, password, roleType, clap, carrier);
                        Console.WriteLine("ok");
                    }

                    // EnterUser
                    if (info.KeyChar == '+' && ID == 1)
                    {
                        content = 0;
                        Console.Clear();
                        applicationMenu.DotsDots();
                        Console.SetCursorPosition(0, 0);
                        Console.Write("+...info: ");

                        Console.SetCursorPosition(43, 0);
                        Console.Write("new user");


                        applicationMenu.PositionQuestions();
                        Console.WriteLine("Enter user name: ");
                        string userName = Console.ReadLine();
                        Console.WriteLine("Enter password: ");
                        string password = Console.ReadLine();

                        bool roleLoop = true;
                        do
                        {

                            Console.WriteLine("role form 1 to 4: ");
                            int result = ApplicationMenu.intResult();
                            if (result >= 1 && result <= 4)
                            {
                                int roleType = result;
                                int clap = 0;
                                int carrier = 0;
                                User.EnterUser(userName, password, roleType, clap, carrier);
                                Console.WriteLine();
                                Console.WriteLine("New user is ready");
                                roleLoop = false;
                            }
                            else
                            {
                                roleLoop = true;
                            }
                            
                        } while (roleLoop == true);

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
