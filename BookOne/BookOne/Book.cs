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
        public string Words { get; set; }
        public int OwnerLoginID { get; set; }
        public int CarrierLoginID { get; set; }
        public int BookStatus { get; set; }

        public int Circulation { get; set; }
        public int Sent { get; set; }
        public int Receive { get; set; }



        // Title Author
        public static void Get0TiAu(List<Book> getInfoAllBooks)
        {
            for (int i = 0; i < getInfoAllBooks.Count; i++)
            {
                Console.SetCursorPosition(43, i + 1);
                Console.Write($"{getInfoAllBooks[i].Title}  ");
                Console.Write($"by: {getInfoAllBooks[i].Author}  ");
            }
        }
        // BookID Title Author
        public static void Get1IdTiAu(List<Book> getInfoAllBooks)
        {
            
            for (int i = 0; i < getInfoAllBooks.Count; i++)
            {
                Console.SetCursorPosition(38, i + 1);
                Console.Write($"{getInfoAllBooks[i].BookID} ");
                Console.SetCursorPosition(43, i + 1);
                Console.Write($"{getInfoAllBooks[i].Title}  ");
                Console.Write($"by: {getInfoAllBooks[i].Author}  ");
            }
        }


        // Carrier Title Author
        public static void Get2CaTiAu(List<Book> getInfoAllBooks)
        {
            
            for (int i = 0; i < getInfoAllBooks.Count; i++)
            {
                Console.SetCursorPosition(38, i + 1);
                Console.Write($"{getInfoAllBooks[i].CarrierLoginID} ");
                Console.SetCursorPosition(43, i + 1);
                Console.Write($"{getInfoAllBooks[i].Title}  ");
                Console.Write($"by: {getInfoAllBooks[i].Author}  ");
            }
        }

        // read
        public static void Read(List<Book> getInfoAllBooks)
        {
            for (int i = 0; i < getInfoAllBooks.Count; i++)
            {
                Console.SetCursorPosition(43, i + 1);
                Console.Write($"{getInfoAllBooks[i].Words} ");
            }
        }

        // circulation
        public static void CirculationView(List<Book> getInfoAllBooks)
        {
            for (int i = 0; i < getInfoAllBooks.Count; i++)
            {
                Console.SetCursorPosition(43, i + 1);
                Console.Write($"{getInfoAllBooks[i].BookID} ");
                Console.SetCursorPosition(48, i + 1);
                Console.Write($"{getInfoAllBooks[i].Circulation} ");
                Console.SetCursorPosition(53, i + 1);
                Console.Write($"{getInfoAllBooks[i].DateOfLastMove} ");
                Console.SetCursorPosition(75, i + 1);
                Console.Write($"{getInfoAllBooks[i].BookStatus} ");

            }
        }


        // all books Info acording to int content  
        public static void GetInfoAllBooks(int content)
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
                catch (Exception ex) //ok for now
                {
                    Console.WriteLine(ex);
                }
            }
        }
            
        // all books Info acording to myID & int content
        public static void ViewYourBooks(int myID, int content)
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
                        Get0TiAu(viewYourBooks);
                    }
                    if (content == 1)
                    {
                        Get1IdTiAu(viewYourBooks);
                    }
                    if(content == 2)
                    {
                        Get2CaTiAu(viewYourBooks);
                    }

                }
                catch (Exception ex) //ok for now
                {
                    Console.WriteLine(ex);
                }
            }
        }

        // all books Info acording to carrierID & int content
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
                    

                }
                catch (Exception ex) 
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
                catch (Exception e)
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


        public static void DeleteFromPoolByBookID(int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                var affectedRows = DataAccess.sqlconn.Execute("sp_DeleteFromPoolByBookID",
                new
                {
                    BookID = bookID
                }, commandType: CommandType.StoredProcedure);
            }
        }
        public static void DeleteFromBookByBookID(int bookID)
        {
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                var affectedRows = DataAccess.sqlconn.Execute("sp_DeleteFromBookByBookID",
                new
                {
                    BookID = bookID
                }, commandType: CommandType.StoredProcedure);
            }
        }

    }

}
