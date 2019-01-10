using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOne
{
    class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DateOfLastMove { get; set; }
        public string InscriptionMessage { get; set; }
        public string MessageData { get; set; }
        public int OwnerLoginID { get; set; }
        public int CarrierLoginID { get; set; }
        public int Status { get; set; }

        public int Circulation { get; set; }
        public int Sent { get; set; }
        public int Receive { get; set; }



        
        // all books Info acording to int content  // ++more views
        public static void GetInfoAllBooks(int content)// use the list: books
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                Book book = new Book();
                try
                {
                    var getInfoAllBooks = DataAccess.sqlconn.Query<Book>
                    ($"sp_GetInfoAllBooks").ToList();

                    if (content == 0)
                    {
                        GetTiAu(getInfoAllBooks);
                    }
                    if (content == 1)
                    {
                        GetIdTiAu(getInfoAllBooks);
                    }

                }
                catch (Exception ex) //ok for now
                {
                    Console.WriteLine(ex);
                }
            }
        }
        // Title Author
        public static void GetTiAu(List<Book> getInfoAllBooks)
        {
            for (int i = 0; i < getInfoAllBooks.Count; i++)
            {
                Console.SetCursorPosition(40, i + 1);
                Console.Write(getInfoAllBooks[i].Title);
                Console.WriteLine($"by: {getInfoAllBooks[i].Author} ");
            }
        }
        // BookID Title Author
        public static void GetIdTiAu(List<Book> getInfoAllBooks)
        {
            for (int i = 0; i < getInfoAllBooks.Count; i++)
            {
                Console.SetCursorPosition(36, i + 1);
                Console.Write(getInfoAllBooks[i].BookID);
                Console.SetCursorPosition(40, i + 1);
                Console.Write(getInfoAllBooks[i].Title);
                Console.WriteLine($"by: {getInfoAllBooks[i].Author} ");
            }
        }

        // all books Info acording to myID & int content
        public static void ViewYourBooks(int myID, int content)// use the list: books
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {
                    var viewYourBooks = DataAccess.sqlconn.Query<Book>
                        ($"sp_ViewYourBooks  @OwnerLoginID={myID}").ToList();
                    if (content == 0)
                    {
                        GetTiAu(viewYourBooks);
                    }
                    if (content == 1)
                    {
                        GetIdTiAu(viewYourBooks);
                    }

                }
                catch (Exception ex) //ok for now
                {
                    Console.WriteLine(ex);
                }
            }
        }



        public static void SentBookSignalYes(int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                var affectedRows = DataAccess.sqlconn.Execute("sp_SentBookSignalYes",
                new
                {
                    BookID = bookID
                }, commandType: CommandType.StoredProcedure);
            }
        }
        public static void ReceiveBookSignalYes(int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                var affectedRows = DataAccess.sqlconn.Execute("sp_ReceiveBookSignalYes",
                new
                {
                    BookID = bookID
                }, commandType: CommandType.StoredProcedure);
            }


        }
        public static void ReceiveBookSignalNo(int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                var affectedRows = DataAccess.sqlconn.Execute("sp_ReceiveBookSignalNo",
                new
                {
                    BookID = bookID
                }, commandType: CommandType.StoredProcedure);
            }


        }


        public static void GetBookByTitle(string title) 
        {
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
                            Console.WriteLine($" {item.Title} ");//what if 2 selections?
                            Console.WriteLine($"by:  {item.Author} ");
                            Console.WriteLine();
                        }
                    }
                }
                catch (Exception ex) //ok for now
                {
                    Console.WriteLine(ex);
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
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }//not in use
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
                catch (Exception e)
                {
                    Console.WriteLine(e);
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

        public static void PoolOfCarriers(int owner, int handTo, int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                var affectedRows = DataAccess.sqlconn.Execute("sp_PoolOfCarriers",
                new
                {
                    Owner = owner,
                    HandTo = handTo,
                    BookID = bookID
                }, commandType: CommandType.StoredProcedure);
            }
        }



        public static void ChaingeCarrier(int carrierLoginID, int bookID, DateTime dateOfLastMove)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                var affectedRows = DataAccess.sqlconn.Execute("sp_ChaingeCarrier",
                new
                {
                    CarrierLoginID = carrierLoginID,
                    DateOfLastMove = dateOfLastMove,
                    BookID = bookID
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public static void AddCirculation(int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                var affectedRows = DataAccess.sqlconn.Execute("sp_AddCirculation",
                new
                {
                    BookID = bookID
                }, commandType: CommandType.StoredProcedure);
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
            int bookstatus, int sent, int receive)
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
                            Sent = sent,
                            Receive = receive

                        }, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex) //ok for now
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
