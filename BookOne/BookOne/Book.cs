﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace BookOne
{
    class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DateOfLastMove { get; set; }
        public string InscriptionMessage { get; set; }
        public string Words { get; set; }
        public int OwnerLoginID { get; set; }
        public int CarrierLoginID { get; set; }
        public int BookStatus { get; set; }

        public int Circulation { get; set; }
        public int Sent { get; set; }
        public int Receive { get; set; }

        public string TL { get; set; }






        // BOOK Info acording to int content  
        public static void GetInfoAllBooks(int content) //Look
        {
            // SqlCoonection ConAgain = new SqlCoonection();
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn) //using (ConAgain)

            {
                Book book = new Book();
                try
                {
                    var getInfoAllBooks = DataAccess.sqlconn.Query<Book>
                    ($"sp_GetInfoAllBooks").ToList();

                    if (content == 0)
                    {
                        Get0TiAu(getInfoAllBooks);
                    }
                    if (content == 1)
                    {
                        Get1IdTiAu(getInfoAllBooks);
                    }
                    if (content == 2)
                    {
                        Get2CaTiAu(getInfoAllBooks);
                    }
                    if (content == 3)
                    {
                        Read(getInfoAllBooks);
                    }
                    if (content == 4)
                    {
                        CirculationView(getInfoAllBooks);
                    }
                }
                catch (Exception) //ok for now
                {
                    Console.WriteLine("there seems to be a problem with connection...");
                    // Console.WriteLine(ex);
                }
            }
        }

        // BOOK Info acording to myID & int content
        public static void ViewYourBooks(int myID, int content)
        {

            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {
                    var viewYourBooks = DataAccess.sqlconn.Query<Book>
                        ($"sp_ViewBooksTLByCarrierID  @OwnerLoginID={myID}").ToList();
                    if (content == 0)
                    {
                        Get0TiAu(viewYourBooks);
                    }
                    if (content == 1)
                    {
                        Get1IdTiAu(viewYourBooks);
                    }
                    if (content == 2)
                    {
                        Get2CaTiAu(viewYourBooks);
                    }
                    if (content == 3)
                    {
                        Get3CaTiAuTL(viewYourBooks);
                    }

                }
                catch (Exception) //ok for now
                {
                    Console.WriteLine("there seems to be a problem with connection...");
                }
            }
        }


        // BOOK Info acording to carrierID & int content
        public static void ViewBooksByCarrierID(int carrierID, int content)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {
                    var viewBooksByCarrierID = DataAccess.sqlconn.Query<Book>
                        ($"sp_ViewBooksByCarrierID  @CarrierLoginID={carrierID}").ToList();
                    if (content == 0)
                    {
                        Get0TiAu(viewBooksByCarrierID);
                    }
                    if (content == 1)
                    {
                        Get1IdTiAu(viewBooksByCarrierID);
                    }
                    if (content == 2)
                    {
                        Get2CaTiAu(viewBooksByCarrierID);
                    }
                    if (content == 4)
                    {
                        Get4OwnerIdTiAu(viewBooksByCarrierID);
                    }


                }
                catch (Exception)
                {
                    Console.WriteLine("there seems to be a problem with connection...");
                }
            }
        }









        // Book content = 0 Title Author
        public static void Get0TiAu(List<Book> getInfoAllBooks)
        {
            ApplicationMenu applicationMenu = new ApplicationMenu();

            for (int i = 0; i < getInfoAllBooks.Count; i++)
            {
                applicationMenu.TwoColorsChainge(i);

                Console.SetCursorPosition(43, i + 1);
                Console.Write($"{getInfoAllBooks[i].Title}  ");
                Console.Write($"   {getInfoAllBooks[i].Author}  ");
            }
        }

        // Book content = 1 BookID Title Author
        public static void Get1IdTiAu(List<Book> getInfoAllBooks)
        {
            ApplicationMenu applicationMenu = new ApplicationMenu();

            for (int i = 0; i < getInfoAllBooks.Count; i++)
            {
                applicationMenu.TwoColorsChainge(i);

                Console.SetCursorPosition(43, i + 1);
                Console.Write($"{getInfoAllBooks[i].BookID} ");
                Console.SetCursorPosition(48, i + 1);
                Console.Write($"{getInfoAllBooks[i].Title}  ");
                Console.Write($"   {getInfoAllBooks[i].Author}  ");
            }
        }

        // Book content = 4 OwnerID Title Author
        public static void Get4OwnerIdTiAu(List<Book> getInfoAllBooks)
        {
            ApplicationMenu applicationMenu = new ApplicationMenu();

            for (int i = 0; i < getInfoAllBooks.Count; i++)
            {
                applicationMenu.TwoColorsChainge(i);

                Console.SetCursorPosition(43, i + 1);
                Console.Write($"{getInfoAllBooks[i].OwnerLoginID} ");
                Console.SetCursorPosition(48, i + 1);
                Console.Write($"{getInfoAllBooks[i].BookID}  ");
                Console.SetCursorPosition(58, i + 1);
                Console.Write($"{getInfoAllBooks[i].Title}  ");

                Console.Write($"   {getInfoAllBooks[i].Author}  ");
            }
        }

        // Book content = 2 CarrierTitleAuthor
        public static void Get2CaTiAu(List<Book> getInfoAllBooks)
        {
            ApplicationMenu applicationMenu = new ApplicationMenu();
            for (int i = 0; i < getInfoAllBooks.Count; i++)
            {
                applicationMenu.TwoColorsChainge(i);

                Console.SetCursorPosition(43, i + 1);
                Console.Write($"{getInfoAllBooks[i].CarrierLoginID} ");
                Console.SetCursorPosition(48, i + 1);
                Console.Write($"{getInfoAllBooks[i].Title}  ");
                Console.Write($"   {getInfoAllBooks[i].Author}  ");


            }
        }

        // Book content = 2 CarrierTitleAuthor
        public static void Get3CaTiAuTL(List<Book> getInfoAllBooks)
        {
            ApplicationMenu applicationMenu = new ApplicationMenu();

            for (int i = 0; i < getInfoAllBooks.Count; i++)
            {
                applicationMenu.TwoColorsChainge(i);

                Console.SetCursorPosition(43, i + 1);
                Console.Write($"{getInfoAllBooks[i].CarrierLoginID} ");
                Console.SetCursorPosition(48, i + 1);
                Console.Write($"{getInfoAllBooks[i].Title}  ");
                Console.Write($"   {getInfoAllBooks[i].Author}  ");
                Console.SetCursorPosition(95, i + 1);
                Console.Write($"{getInfoAllBooks[i].TL}  ");

            }
        }
        // read
        public static void Read(List<Book> getInfoAllBooks)
        {
            ApplicationMenu applicationMenu = new ApplicationMenu();

            for (int i = 0; i < getInfoAllBooks.Count; i++)
            {
                applicationMenu.TwoColorsChainge(i);

                Console.SetCursorPosition(43, i + 1);
                Console.Write($"{getInfoAllBooks[i].Words} ");


            }
        }
        // circulation
        public static void CirculationView(List<Book> getInfoAllBooks)
        {
            ApplicationMenu applicationMenu = new ApplicationMenu();
            for (int i = 0; i < getInfoAllBooks.Count; i++)
            {

                applicationMenu.TwoColorsChainge(i);

                Console.SetCursorPosition(43, i + 1);
                Console.Write($"{getInfoAllBooks[i].OwnerLoginID} ");
                Console.SetCursorPosition(48, i + 1);
                Console.Write($"{getInfoAllBooks[i].BookID} ");
                Console.SetCursorPosition(58, i + 1);
                Console.Write($"{getInfoAllBooks[i].Circulation} ");
                Console.SetCursorPosition(68, i + 1);
                Console.Write($"{getInfoAllBooks[i].BookStatus} ");
                Console.SetCursorPosition(78, i + 1);
                Console.Write($"{getInfoAllBooks[i].DateOfLastMove} ");
                //be careful of this hack !! here to erase time
                Console.SetCursorPosition(88, i + 1);
                Console.Write("            ");
            }
        }




        public static void SentBookSignalYes(int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {

                    var affectedRows = DataAccess.sqlconn.Execute("sp_SentBookSignalYes",
                    new
                    {
                        BookID = bookID
                    }, commandType: CommandType.StoredProcedure);
                }
                catch
                {
                    Console.WriteLine("there seems to be a problem with connection...");
                }
            }
        }
        public static void ReceiveBookSignalYes(int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {

                    var affectedRows = DataAccess.sqlconn.Execute("sp_ReceiveBookSignalYes",
                    new
                    {
                        BookID = bookID
                    }, commandType: CommandType.StoredProcedure);
                }
                catch
                {
                    Console.WriteLine("there seems to be a problem with connection...");
                }
            }


        }
        public static void ReceiveBookSignalNo(int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {

                    var affectedRows = DataAccess.sqlconn.Execute("sp_ReceiveBookSignalNo",
                    new
                    {
                        BookID = bookID
                    }, commandType: CommandType.StoredProcedure);
                }
                catch
                {
                    Console.WriteLine("there seems to be a problem with connection...");
                }
            }


        }


        public static void FindBookByTitle(string title)
        {

            Console.WriteLine("results:");
            Console.WriteLine();
            Console.WriteLine();
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {
                    DataAccess.sqlconn.ConnectionString = Helper.conectionString;
                    using (DataAccess.sqlconn)
                    {
                        var getBookByTitle = DataAccess.sqlconn.Query("sp_GetBookByTitle",
                        new
                        {

                            Title = title
                        }, commandType: CommandType.StoredProcedure);
                        foreach (var item in getBookByTitle)
                        {
                            Console.WriteLine($"ID: {item.BookID}  ");
                            Console.WriteLine($" {item.Title} ");
                            Console.WriteLine($"by:  {item.Author} ");
                            Console.WriteLine();
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("there seems to be a problem with connection...");
                }
            }
        }
        public static int GetOwnerLoginIDByBookID(int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {

                    var p = new DynamicParameters();
                    p.Add("BookID", bookID);
                    p.Add("OwnerLoginID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    DataAccess.sqlconn.Query<int>("sp_GetOwnerLoginIDByBookID", p, commandType: CommandType.StoredProcedure);
                    int ownerLoginID = p.Get<int>("OwnerLoginID");
                    return ownerLoginID;
                }
                catch (Exception)
                {
                    Console.WriteLine("Is this right?");
                    return 0;
                }
            }
        }
        public static int GetCarrierLoginIDByBookID(int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {

                    var p = new DynamicParameters();
                    p.Add("BookID", bookID);
                    p.Add("CarrierLoginID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    DataAccess.sqlconn.Query<int>("sp_GetCarrierLoginIDByBookID", p, commandType: CommandType.StoredProcedure);
                    int carrierLoginID = p.Get<int>("CarrierLoginID");
                    return carrierLoginID;
                }
                catch (Exception )
                {
                    Console.WriteLine("Is this right?");
                    return 0;
                }
            }
        }



        public static int GetSentReceiveSignal(int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {

                try
                {
                    var p = new DynamicParameters();
                    p.Add("BookID", bookID);
                    p.Add("@Total", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    DataAccess.sqlconn.Query<int>("sp_GetSentReceiveNumber", p, commandType: CommandType.StoredProcedure);
                    int Total = p.Get<int>("@Total");
                    return Total;
                }
                catch (Exception)
                {
                    return 0;
                }

            }
        }
        public static int GetSentSignal(int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {

                try
                {
                    var p = new DynamicParameters();
                    p.Add("BookID", bookID);
                    p.Add("@Sent", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    DataAccess.sqlconn.Query<int>("sp_GetSentNumber", p, commandType: CommandType.StoredProcedure);
                    int sent = p.Get<int>("@Sent");
                    return sent;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public static int GetHandToByBookID(int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {
                    var p = new DynamicParameters();
                    p.Add("BookID", bookID);
                    p.Add("@HandTo", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    DataAccess.sqlconn.Query<int>("sp_GetHandToByBookID", p, commandType: CommandType.StoredProcedure);
                    int HandTo = p.Get<int>("@HandTo");
                    return HandTo;
                }
                catch (Exception)
                {
                    return 0;
                }

            }
        }


        public static int GetOwnerByBookID(int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {
                    var p = new DynamicParameters();
                    p.Add("BookID", bookID);
                    p.Add("@OwnerLoginID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    DataAccess.sqlconn.Query<int>("sp_GetOwnerByBookID", p, commandType: CommandType.StoredProcedure);
                    int HandTo = p.Get<int>("@OwnerLoginID");
                    return HandTo;
                }
                catch (Exception)
                {
                    Console.WriteLine("Hold on a minute");
                    return 0;
                }

            }
        }


        public static void PoolOfCarriers(int owner, int handTo, int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {

                    var affectedRows = DataAccess.sqlconn.Execute("sp_PoolOfCarriers",
                    new
                    {
                        Owner = owner,
                        HandTo = handTo,
                        BookID = bookID
                    }, commandType: CommandType.StoredProcedure);
                }
                catch (Exception)
                {
                    Console.WriteLine("there seems to be a problem with connection...");
                }
            }
        }



        public static void ChaingeCarrier(int carrierLoginID, int bookID, DateTime dateOfLastMove)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {

                    var affectedRows = DataAccess.sqlconn.Execute("sp_ChaingeCarrier",
                    new
                    {
                        CarrierLoginID = carrierLoginID,
                        DateOfLastMove = dateOfLastMove,
                        BookID = bookID
                    }, commandType: CommandType.StoredProcedure);
                }
                catch (Exception)
                {
                    Console.WriteLine("there seems to be a problem with connection...");
                }
            }
        }

        public static void AddCirculation(int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {

                    var affectedRows = DataAccess.sqlconn.Execute("sp_AddCirculation",
                    new
                    {
                        BookID = bookID
                    }, commandType: CommandType.StoredProcedure);
                }
                catch (Exception)
                {
                    Console.WriteLine("there seems to be a problem with connection...");
                }
            }
        }



        public static string Truncater(string newWords, int length)
        {
            if (newWords.Length > length)
            {
                newWords = newWords.Substring(0, length);

            }
            return newWords;
        }
        public static void WriteWords(int bookID, string newWords)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                var affectedRows = DataAccess.sqlconn.Execute("sp_WriteWords",
                new
                {

                    NewWords = newWords,
                    BookID = bookID
                }, commandType: CommandType.StoredProcedure);
            }
        }


        public static void EnterBook(string title, string author, string words, DateTime dateOfLastMove, int ownerLoginID, int carrierLoginID,
            int bookstatus, int circulation, int sent, int receive)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {
                    DataAccess.sqlconn.ConnectionString = Helper.conectionString;
                    using (DataAccess.sqlconn)
                    {
                        var enterAbookInThePool = DataAccess.sqlconn.Execute("sp_EnterBook",
                        new
                        {
                            Title = title,
                            Author = author,
                            DateOfLastMove = dateOfLastMove,
                            Words = words,
                            OwnerLoginID = ownerLoginID,
                            CarrierLoginID = carrierLoginID,
                            BookStatus = bookstatus,
                            Circulation = circulation,
                            Sent = sent,
                            Receive = receive

                        }, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("there seems to be a problem with connection...");
                }
            }
        }


        public static void DeleteFromPoolByBookID(int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {

                    var affectedRows = DataAccess.sqlconn.Execute("sp_DeleteFromPoolByBookID",
                    new
                    {
                        BookID = bookID
                    }, commandType: CommandType.StoredProcedure);
                }
                catch (Exception)
                {
                    Console.WriteLine("there seems to be a problem with connection...");
                }
            }
        }
        public static void DeleteFromBookByBookID(int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {

                    var affectedRows = DataAccess.sqlconn.Execute("sp_DeleteFromBookByBookID",
                    new
                    {
                        BookID = bookID
                    }, commandType: CommandType.StoredProcedure);
                }
                catch (Exception)
                {
                    Console.WriteLine("there seems to be a problem with connection...");
                }
            }
        }
        public static void DeleteInvolvedBooks(int loginID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {

                    var affectedRows = DataAccess.sqlconn.Execute("sp_DeleteInvolvedBooks",
                    new
                    {
                        LogInID = loginID
                    }, commandType: CommandType.StoredProcedure);
                    Console.WriteLine("Bye bye");
                }
                catch (Exception )
                {
                    
                    Console.WriteLine("Soory ...No can do! ");
                }
            }
        }





    }

}
