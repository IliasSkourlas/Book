using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOne
{
    class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string DateOfSubmition { get; set; } //for now
        public string InscriptionMessage { get; set; }
        public string MessageData { get; set; }
        public int OwnerLoginID { get; set; }
        public int CarrierLoginID { get; set; }

        List<Book> books = new List<Book>();

        public static void GetInfoAllBooks()
        {
            DataAccess.sqlconn.ConnectionString = DataAccess.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {
                    var viewAllItems = DataAccess.sqlconn.Query<Book>
                    ($"sp_GetInfoAllBooks").ToList();

                    foreach (var item in viewAllItems)
                    {
                        Console.WriteLine($"Title: {item.Title}");
                        Console.WriteLine($"Author: {item.Title}");

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
