using System;
using System.IO;
using System.Text;

namespace BookOne
{
    class BackupFile
    {

        public void BackupFileEnterBook(DateTime date, int ownerLoginID, string title, string author, int bookStatus)
        {
            string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
            string backUpOne = Path.Combine(path, "BackupEnterBook.txt");

            if (!File.Exists(backUpOne))
            {
                using (FileStream fs = File.Create(backUpOne))
                {
                    Byte[] info =
                        new UTF8Encoding(true).GetBytes($"backup file created on {date}\n");

                    fs.Write(info, 0, info.Length);
                }
            }
            if (File.Exists(backUpOne))
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(backUpOne, true))
                    {
                        writer.WriteLine();
                        writer.WriteLine($"{date}, owner: {ownerLoginID}, entered the book: {title}  by: {author} with bookStatus: {bookStatus}");
                        writer.WriteLine();
                    }
                }
                catch (DirectoryNotFoundException e)
                {
                    //Console.WriteLine(e);
                    Console.WriteLine("This entry has not been saved to the backup files :)");
                }

            }
        }

        public void BackupFileDeleteBook(DateTime date, int bookID)
        {
            string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
            string backUpTwo = Path.Combine(path, "BackupDeleteBook.txt");

            if (!File.Exists(backUpTwo))
            {
                using (FileStream fs = File.Create(backUpTwo))
                {
                    Byte[] info =
                        new UTF8Encoding(true).GetBytes($"backup file created on {date}\n");

                    fs.Write(info, 0, info.Length);
                }
            }
            if (File.Exists(backUpTwo))
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(backUpTwo, true))
                    {
                        writer.WriteLine();
                        writer.WriteLine($"{date},      bookID: {bookID}, has been deleted from the bool");
                        writer.WriteLine();
                    }
                }
                catch (DirectoryNotFoundException e)
                {
                    //Console.WriteLine(e);
                    Console.WriteLine("This action has not been saved to the backup files :)");
                }

            }
        }
    }
}
