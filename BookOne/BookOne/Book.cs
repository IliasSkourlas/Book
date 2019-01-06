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

        List<Book> books = new List<Book>();


        public static void GiveAbookInThePool(string title, string author, DateTime dateOfSubmition, string inscription, int ownerLoginID, int carrierLoginID, int bookstatus)
        {
            DataAccess.sqlconn.ConnectionString = DataAccess.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {
                    DataAccess.sqlconn.ConnectionString = DataAccess.conectionString;
                    using (DataAccess.sqlconn)
                    {
                        var affectedRows = DataAccess.sqlconn.Execute("sp_GiveAbookInThePool",
                        new
                        {
                            Title = title,
                            Author = author,
                            DateOfSubmition = dateOfSubmition,
                            InscriptionMessage = inscription,
                            OwnerLoginID = ownerLoginID,
                            CarrierLoginID = carrierLoginID,
                            BookStatus = bookstatus

                        }, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex) //ok for now
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public static void GetInfoAllBooks()// use the list: books
        {
            DataAccess.sqlconn.ConnectionString = DataAccess.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {
                    var getInfoAllBooks = DataAccess.sqlconn.Query<Book>
                    ($"sp_GetInfoAllBooks").ToList();

                    foreach (var item in getInfoAllBooks)
                    {
                        Console.WriteLine($"Title: {item.Title}");
                        Console.WriteLine($"Author: {item.Author}");

                    }
                }
                catch (Exception ex) //ok for now
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public static void GetBookByTitle(string title)
        {
            DataAccess.sqlconn.ConnectionString = DataAccess.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {
                    DataAccess.sqlconn.ConnectionString = DataAccess.conectionString;
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
    }

    
}
