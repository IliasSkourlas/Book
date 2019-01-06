using System.IO;

namespace BookOne
{
    class BackupFile
    {

        public void Backup(string date, int myID, int reseiverID, string messageData)
        {
            using (StreamWriter writer = new StreamWriter("C:/Users/penel/source/repos/ProjectOne2/ProjectOne2/BackupFile.txt", true))
            {
                writer.WriteLine();
                writer.WriteLine($"On {date} ID: {myID} sents to  ID: {reseiverID} the message:");
                writer.WriteLine();
                writer.WriteLine($"{ messageData}");
                writer.WriteLine("............................................................");
            }
        }

    }
}
