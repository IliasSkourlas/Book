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
        public DateTime DateOfSubmition { get; set; }
        public string InscriptionMessage { get; set; }
        public string MessageData { get; set; }
        public int OwnerLoginID { get; set; }
        public int CarrierLoginID { get; set; }
        public int Status { get; set; }

        public int Circulation { get; set; }


  

        public static void EnterBook(string title, string author, string inscription,DateTime dateOfSubmition, int ownerLoginID,int carrierLoginID,
            int bookstatus,int sent,int receive)
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
                            DateOfSubmition = dateOfSubmition,
                            InscriptionMessage = inscription,
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
        public  static void GetTiAu(List<Book> getInfoAllBooks)
        {
            for (int i = 0; i < getInfoAllBooks.Count; i++)
            {
                Console.SetCursorPosition(40, i + 1);
                Console.Write(getInfoAllBooks[i].Title);
                Console.WriteLine($"by: {getInfoAllBooks[i].Author} ");
            }
        }
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
       



        public static void GetBookByTitle(string title) // ????
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
                            Console.WriteLine($"Do you mean: {item.Title}?");//what if 2 selections?
                            Console.WriteLine($"by: {item.Author}?");
                        }
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


    }


}
