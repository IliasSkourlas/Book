using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOne
{
    class Pool
    {
        public int ID { get; set; }
        public int Owner { get; set; }
        public int HandTo { get; set; }
        public int BookID { get; set; }



       // List<Pool> getHandToByBookID = new List<Pool>();

      


        // Get Hand By BookID
        public static List<int> GetHandToByBookID(int bookID, int content)
        {
            List<int> handList = new List<int>();
            DataAccess.sqlconn.ConnectionString = Helper.conectionString;
            using (DataAccess.sqlconn)
            {
                try
                {
                    var getListOfHandByBookID = DataAccess.sqlconn.Query<Pool>
                        ($"sp_GetListOfHandByBookID  @BookID={bookID}").ToList();

                    if (content == 0)
                    {
                        HandPrint(getListOfHandByBookID);
                    }
                    if (content == 1)
                    {

                        handList = HandList(getListOfHandByBookID);
                    }
                }
                catch (Exception ex) //ok for now
                {
                    Console.WriteLine(ex);
                }
            }
            return handList;
        }


        public static void HandPrint(List<Pool> getListOfHandByBookID)
        {
           
            for (int i = 0; i < getListOfHandByBookID.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                Console.SetCursorPosition(61, i + 1);
                Console.Write($"{getListOfHandByBookID[i].HandTo}  ");             
            }          
        }

        public static List<int> HandList(List<Pool> getListOfHandByBookID)
        {
            List<int> hand = new List<int>();
            for (int i = 0; i < getListOfHandByBookID.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                }
                Console.SetCursorPosition(61, i + 1);
                Console.Write($"{getListOfHandByBookID[i].HandTo}  ");
                hand.Add(getListOfHandByBookID[i].HandTo);
            }
            return hand;
        }



        public static bool IsCarrierInPool(int bookID,int id)
        {
            int content = 1;
            List<int> handList = new List<int>();
            handList = GetHandToByBookID(bookID, content);
            bool exists = handList.Exists(p => p == id);
            return exists;
            
        }
    }
}
