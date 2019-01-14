using System;
using System.IO;

namespace BookOne
{
    class BackupFile
    {

        public void BackupFileBook(DateTime date, int ownerLoginID, string title, string author, int bookStatus)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("C:/Users/penel/Desktop/BackupFileBook.txt", true))
                {
                    writer.WriteLine();
                    writer.WriteLine($"{date}, owner: {ownerLoginID}, entered the book: {title}  by: {author} with bookStatus: {bookStatus}");
                    writer.WriteLine();

                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                Console.WriteLine("This entry has not been saved to the backup files :)");
            }
        }

    }
}
