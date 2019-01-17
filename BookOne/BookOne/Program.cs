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
            User user = new User();


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
                    int content = 1;
                    Console.ForegroundColor = ConsoleColor.White;

                    ConsoleKeyInfo info = Console.ReadKey();
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Press...i ");
                    Console.ForegroundColor = ConsoleColor.White;

                    Book.GetInfoAllBooks(content);

                    applicationMenu.ComonRandomPatern();

                    Console.SetCursorPosition(0, 29);

                    if (info.KeyChar == 'i' || info.KeyChar == 'I')
                    {
                        for (int i = 0; i < applicationMenu.InfoList().Count; i++)
                        {
                            content = 1;

                            //applicationMenu.EptySpace();
                            //Book.GetInfoAllBooks(content);

                            Console.SetCursorPosition(36, 0);
                            // Console.WriteLine("             ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition(0, 0);
                            Console.Write($"You are: {ID}        ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(43, 0);
                            Console.Write("id ");
                            Console.SetCursorPosition(48, 0);
                            Console.Write("books in the bool ");

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

                    // esc
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
                        applicationMenu.UpdateShortcut();

                    }

                    // Read
                    if (info.KeyChar == 'r' || info.KeyChar == 'R')
                    {
                        Console.Clear();


                        content = 3;
                        //Console.SetCursorPosition(36, 0);
                        //Console.WriteLine("      ");

                        //applicationMenu.EptySpace();

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


                        applicationMenu.ComonRandomPatern();


                        Book.GetInfoAllBooks(content);
                        Console.SetCursorPosition(0, 29);

                        loopInfo = true;
                    }

                    // Write Words
                    bool wCondition = (info.KeyChar == 'w' || info.KeyChar == 'W');
                    if (myRole != 4 && wCondition)
                    {
                        Console.Clear();
                        content = 1;
                        int carrierID = ID;


                        //Console.SetCursorPosition(36, 0);
                        //Console.WriteLine("      ");
                        //applicationMenu.EptySpace();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(0, 0);
                        Console.Write("Press...i");
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
                            //applicationMenu.EptySpace();

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
                            applicationMenu.ComonRandomPatern();//
                            applicationMenu.PositionQuestions();
                            Console.ForegroundColor = ConsoleColor.Green;


                            System.Threading.Thread.Sleep(1000);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You can only write on the books you carry.");
                            System.Threading.Thread.Sleep(3000);

                            applicationMenu.ComonRandomPatern();

                        }
                    }

                    // Pool
                    if (info.KeyChar == 'p' || info.KeyChar == 'P')
                    {
                        Console.Clear();
                        
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(0, 0);
                        Console.Write("Get this book's pool");
                        Console.SetCursorPosition(43, 0);
                        Console.Write("User Id");
                        Console.SetCursorPosition(48, 0);
                        Console.Write("Books in the pool");

                        Book.GetInfoAllBooks(1);
                        Console.SetCursorPosition(0, 29);


                        applicationMenu.ComonRandomPatern();
                        applicationMenu.PositionQuestions();
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("for book id: ");
                        int bookID = ApplicationMenu.intResult();

                        Console.Clear();
                       
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(0, 0);
                        Console.Write("This book's pool");
                        Console.SetCursorPosition(61, 0);
                        Console.Write("Users Id");

                        applicationMenu.ComonRandomPatern();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Pool.GetHandToByBookID(bookID, 0);
                        Console.SetCursorPosition(0, 29);
                        Console.ForegroundColor = ConsoleColor.White;

                        loopInfo = true;
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

                        
                        applicationMenu.ComonRandomPatern();


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

                                applicationMenu.ComonRandomPatern();//
                                applicationMenu.PositionQuestions();
                                Console.ForegroundColor = ConsoleColor.Green;

                                Console.WriteLine("Do you want to add an ID to the pool?");
                                Console.WriteLine("Y_or_N? ");
                                ConsoleKeyInfo addInPool = Console.ReadKey();

                                applicationMenu.ComonRandomPatern();//
                                applicationMenu.PositionQuestions();
                                Console.ForegroundColor = ConsoleColor.Green;

                                if (addInPool.KeyChar == 'y' || addInPool.KeyChar == 'Y')
                                {
                                    applicationMenu.ComonRandomPatern();//
                                    applicationMenu.PositionQuestions();
                                    Console.ForegroundColor = ConsoleColor.Green;

                                    Console.WriteLine();
                                    Console.WriteLine("Add ID: ");
                                    int handTo = ApplicationMenu.intResult();

                                    applicationMenu.ComonRandomPatern();//
                                    applicationMenu.PositionQuestions();
                                    Console.ForegroundColor = ConsoleColor.Green;

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
                            //List<int> handList = new List<int>();
                            Console.Clear();
                           

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(0, 0);
                            Console.Write("accept a book");
                            Console.SetCursorPosition(43, 0);
                            Console.Write("Id   ");
                            Console.SetCursorPosition(48, 0);
                            Console.Write("All books        ");

                            applicationMenu.ComonRandomPatern();

                            
                            Book.GetInfoAllBooks(content);                           

                            Console.ForegroundColor = ConsoleColor.Green;
                            applicationMenu.PositionQuestions();
                            Console.Write("For which book ID? ");

                            int bookID = ApplicationMenu.intResult();


                            bool exists = Pool.IsCarrierInPool(bookID, ID); 


                            applicationMenu.ComonRandomPatern();//
                            Console.ForegroundColor = ConsoleColor.Green;


                            if (((Book.GetSentSignal(bookID) == 1 &&  exists == true) 
                                || ((Book.GetSentSignal(bookID) == 1) && Book.GetOwnerLoginIDByBookID(bookID) == ID)))
                            {
                                int carrierID = Book.GetCarrierLoginIDByBookID(bookID);
                                Console.WriteLine("do you accept this book? ");
                                Console.WriteLine("Y_or_N? ");
                                ConsoleKeyInfo offer = Console.ReadKey();

                                applicationMenu.ComonRandomPatern();//
                                applicationMenu.PositionQuestions();
                                Console.ForegroundColor = ConsoleColor.Green;

                                if (offer.KeyChar == 'y' || offer.KeyChar == 'Y')
                                {
                                    Book.ReceiveBookSignalYes(bookID);

                                    if ((Book.GetSentReceiveSignal(bookID) == 2) &&
                                        (Book.GetOwnerLoginIDByBookID(bookID) != Book.GetCarrierLoginIDByBookID(bookID)) &&
                                        (Book.GetOwnerLoginIDByBookID(bookID) == ID))
                                    {

                                        applicationMenu.PositionQuestions();
                                        Console.WriteLine();
                                        Console.WriteLine("Do you want to give a Clap?");
                                        Console.WriteLine("Y_or_N?");

                                        ConsoleKeyInfo clapFor = Console.ReadKey();

                                        applicationMenu.ComonRandomPatern();//
                                        applicationMenu.PositionQuestions();
                                        Console.ForegroundColor = ConsoleColor.Green;

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
                        content = 3;
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("carriers        ");
                        Console.SetCursorPosition(43, 0);
                        Console.Write("id");
                        Console.SetCursorPosition(48, 0);
                        Console.WriteLine("my books");
                        Console.SetCursorPosition(95, 0);
                        Console.WriteLine("TL");
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

                    //// Find Book from All                                           
                    if (info.KeyChar == 'f' || info.KeyChar == 'F')
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Search: ");
                        Book.FindBookByTitle(Console.ReadLine());
                        Console.WriteLine();
                        
                        Console.ForegroundColor = ConsoleColor.White;

                    }

                    // Role three: Enter a book 
                    bool eCondition = (info.KeyChar == 'e' || info.KeyChar == 'E');
                    if (myRole == 3 && eCondition)
                    {

                        content = 1;
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Enter a book in the pool: ");
                        Book.GetInfoAllBooks(content);

                        applicationMenu.ComonRandomPatern();

                        Console.ForegroundColor = ConsoleColor.Green;
                        applicationMenu.PositionQuestions();
                        Console.WriteLine("Title: ");
                        string title = Console.ReadLine();

                        applicationMenu.ComonRandomPatern();//
                        applicationMenu.PositionQuestions();
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("Author: ");
                        string author = Console.ReadLine();

                        applicationMenu.ComonRandomPatern();//
                        applicationMenu.PositionQuestions();
                        Console.ForegroundColor = ConsoleColor.Green;

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

                        applicationMenu.ComonRandomPatern();//

                        Book.GetInfoAllBooks(content);
                        Console.SetCursorPosition(0, 29);

                        loopInfo = true;
                    }

                    // Enter a book 
                    if (myRole != 3 && myRole != 4 && eCondition)
                    {
                        content = 1;
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Enter a book in the pool: ");
                        Book.GetInfoAllBooks(content);

                        applicationMenu.ComonRandomPatern();

                        Console.ForegroundColor = ConsoleColor.Green;
                        applicationMenu.PositionQuestions();
                        Console.WriteLine("Title: ");
                        string title = Console.ReadLine();

                        applicationMenu.ComonRandomPatern();//
                        applicationMenu.PositionQuestions();
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("Author: ");
                        string author = Console.ReadLine();

                        applicationMenu.ComonRandomPatern();//
                        applicationMenu.PositionQuestions();
                        Console.ForegroundColor = ConsoleColor.Green;


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
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("We all have a new book");

                        applicationMenu.ComonRandomPatern();//


                        Book.GetInfoAllBooks(content);
                        Console.SetCursorPosition(0, 29);

                        loopInfo = true;
                    }

                    // Delete Book
                    bool dCondition = (info.KeyChar == 'd' || info.KeyChar == 'D');
                    if ((myRole == 1 && dCondition) || (myRole == 2 && dCondition))
                    {
                        content = 1;
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(0, 0);
                        Console.Write("delete from the pool ");
                        Console.SetCursorPosition(43, 0);
                        Console.Write("id");
                        Console.SetCursorPosition(48, 0);
                        Console.Write("your books");

                        applicationMenu.randomRedDot();
                        applicationMenu.ComonRandomPaternEraser();


                        Book.ViewYourBooks(ID, content);

                        Console.ForegroundColor = ConsoleColor.Green;
                        applicationMenu.PositionQuestions();
                        Console.Write("Book number? ");

                        int toBeDeleted = ApplicationMenu.intResult();

                        applicationMenu.randomRedDot();//on
                        applicationMenu.ComonRandomPaternEraser();
                        applicationMenu.PositionQuestions();
                        Console.WriteLine("                         ");

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
                            Console.ForegroundColor = ConsoleColor.Red;
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


                        applicationMenu.ComonRandomPatern();


                        Console.SetCursorPosition(0, 0);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("delete a user ");

                        Console.SetCursorPosition(43, 0);
                        Console.Write("Id");
                        Console.SetCursorPosition(48, 0);
                        Console.Write("name");
                        Console.SetCursorPosition(56, 0);
                        Console.Write("role");
                        Console.SetCursorPosition(64, 0);
                        Console.Write("carried");
                        Console.SetCursorPosition(72, 0);
                        Console.Write("claps");



                        applicationMenu.ComonRandomPatern();
                        applicationMenu.PositionQuestions();

                        User.GetInfoAllUsers(content);
                        Console.SetCursorPosition(0, 29);

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        applicationMenu.PositionQuestions();
                        Console.Write("Delete User ID: ");
                        Console.WriteLine();
                        int userID = ApplicationMenu.intResult();


                        applicationMenu.ComonRandomPatern();
                        applicationMenu.PositionQuestions();
                        Console.ForegroundColor = ConsoleColor.Green;


                        Console.WriteLine("You might also have to delete");
                        Console.WriteLine();
                        Console.WriteLine("all the books the user carries and owns");
                        Console.WriteLine();
                        Console.WriteLine("Do you want to procced?");
                        Console.WriteLine();
                        Console.WriteLine("Y_or_N?");
                        Console.WriteLine();
                        ConsoleKeyInfo toDelete = Console.ReadKey();





                        if (toDelete.KeyChar == 'y' || toDelete.KeyChar == 'Y')
                        {
                            Book.DeleteInvolvedBooks(userID);
                            User.DeleteUser(userID);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("Bye bye");

                        }
                        if (toDelete.KeyChar == 'n' || toDelete.KeyChar == 'N')
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("Everybody is Here");

                        }
                        applicationMenu.ComonRandomPatern();//

                        loopInfo = true;
                    }

                    // Update User
                    if ((info.KeyChar == 'z' && ID == 1) || (info.KeyChar == 'Z' && ID == 1))
                    {
                        applicationMenu.UpdateShortcut();

                        Console.ForegroundColor = ConsoleColor.Green;
                        applicationMenu.PositionQuestions();
                        Console.WriteLine("Update ID: ");
                        int UserID = ApplicationMenu.intResult();

                        applicationMenu.ComonRandomPatern();//
                        applicationMenu.PositionQuestions();
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("Update user name: ");
                        string userName = Console.ReadLine();

                        applicationMenu.ComonRandomPatern();//
                        applicationMenu.PositionQuestions();
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("Update password: ");
                        string password = Console.ReadLine();

                        applicationMenu.ComonRandomPatern();//
                        applicationMenu.PositionQuestions();
                        Console.ForegroundColor = ConsoleColor.Green;

                        bool roleloop = true;
                        do
                        {
                            Console.WriteLine("role type from 1-4: ");
                            int roleInt = ApplicationMenu.intResult();
                            if (roleInt >= 1 && roleInt <= 4)
                            {
                                user.RoleType = roleInt;
                                roleloop = false;
                            }
                            else
                            {
                                roleloop = true;
                            }
                        } while (roleloop == true);

                        applicationMenu.ComonRandomPatern();//
                        applicationMenu.PositionQuestions();
                        Console.ForegroundColor = ConsoleColor.Green;

                        bool claploop = true;
                        do
                        {
                            Console.WriteLine("Update clap: ");
                            int clapInt = ApplicationMenu.intResult();
                            if (clapInt >= 0)
                            {
                                user.Clap = clapInt;
                                claploop = false;
                            }
                            else
                            {
                                claploop = true;
                            }
                            
                        } while (claploop == true);

                        applicationMenu.ComonRandomPatern();//
                        applicationMenu.PositionQuestions();
                        Console.ForegroundColor = ConsoleColor.Green;

                        
                        bool carrierloop = true;
                        do
                        {
                            Console.WriteLine("Update carrier: ");
                            int carrierInt = ApplicationMenu.intResult();

                            if (carrierInt >= 0)
                            {
                                user.Carrier = carrierInt;
                                carrierloop = false;
                            }
                            else
                            {
                                 carrierloop = true;

                            }

                        } while (carrierloop == true);

                        User.UpdateUser(UserID, userName, password, user.RoleType, user.Clap, user.Carrier);
                        Console.WriteLine("ok");
                        
                        applicationMenu.UpdateShortcut();

                    }

                    // EnterUser
                    if (info.KeyChar == '+' && ID == 1)
                    {
                        content = 0;
                        Console.Clear();




                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(0, 0);
                        Console.Write("new user");

                        applicationMenu.ComonRandomPatern();

                        Console.ForegroundColor = ConsoleColor.Green;
                        applicationMenu.PositionQuestions();
                        Console.WriteLine("Enter user name: ");
                        string userName = Console.ReadLine();

                        applicationMenu.ComonRandomPatern();//
                        applicationMenu.PositionQuestions();
                        Console.ForegroundColor = ConsoleColor.Green;


                        Console.WriteLine("Enter password: ");
                        string password = Console.ReadLine();


                        applicationMenu.ComonRandomPatern();//
                        applicationMenu.PositionQuestions();
                        Console.ForegroundColor = ConsoleColor.Green;

                        bool roleLoop = true;
                        do
                        {

                            Console.WriteLine("role form 1 to 4: ");
                            int result = ApplicationMenu.intResult();
                            if (result >= 1 && result <= 4)
                            {


                                applicationMenu.ComonRandomPatern();//
                                applicationMenu.PositionQuestions();
                                Console.ForegroundColor = ConsoleColor.Green;


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


                        applicationMenu.UpdateShortcut();


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
