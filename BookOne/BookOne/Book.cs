﻿using Dapper;
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



        public static void ViewAllItems()
        {
            var viewAllItems = DataAccess.sqlconn.Query<Book>
                    ($"sp_AllBooks").ToList();

            foreach (var item in viewAllItems)
            {
                Console.WriteLine($"Title: {item.Title}");
            }
        }



    }
}
