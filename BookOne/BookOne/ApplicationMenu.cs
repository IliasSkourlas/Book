using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOne
{
    public class ApplicationMenu
    {

        Book book = new Book();   // do i need this?


        // RoleType = List
        public List<string> InfoList()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (User.ThisRoleType == 1)
            {

                return SuperAdminInfo();
            }
            if (User.ThisRoleType == 2)
            {
                return ViewEditDeleteUserInfo();

            }
            if (User.ThisRoleType == 3)
            {
                return ViewEditUserInfo();
            }
            else
            {
                return ViewOnlyUserInfo();
            }
        }




        public List<string> ViewOnlyUserInfo()
        {
            List<string> viewOnlyUserInfo = new List<string>();
            viewOnlyUserInfo.Add("m...my books");
            viewOnlyUserInfo.Add("h...books in my hand");
            viewOnlyUserInfo.Add("c...carriers of my books");
            viewOnlyUserInfo.Add("o...circulation");
            viewOnlyUserInfo.Add("u...user info");
            viewOnlyUserInfo.Add("r...read");

            return viewOnlyUserInfo;

        }
        public List<string> ViewEditUserInfo()
        {

            List<string> viewEditUserInfo = new List<string>();
            viewEditUserInfo.Add("m...my books");
            viewEditUserInfo.Add("h...books in my hand");
            viewEditUserInfo.Add("c...carriers of my books");
            viewEditUserInfo.Add("o...circulation");
            viewEditUserInfo.Add("u...user info");
            viewEditUserInfo.Add("r...read");


            viewEditUserInfo.Add(string.Empty);
            viewEditUserInfo.Add("s...give a book");
            viewEditUserInfo.Add("a...accept a book");
            viewEditUserInfo.Add("e...enter your book");
            viewEditUserInfo.Add("w...words");
            viewEditUserInfo.Add(string.Empty);

            return viewEditUserInfo;
        }
        public List<string> ViewEditDeleteUserInfo()
        {
            List<string> viewEditDeleteUserInfo = new List<string>();
            viewEditDeleteUserInfo.Add("m...my books");
            viewEditDeleteUserInfo.Add("h...books in my hand");
            viewEditDeleteUserInfo.Add("c...carriers of my books");
            viewEditDeleteUserInfo.Add("o...circulation");
            viewEditDeleteUserInfo.Add("u...user info");
            viewEditDeleteUserInfo.Add("r...read");


            viewEditDeleteUserInfo.Add(string.Empty);
            viewEditDeleteUserInfo.Add("s...give a book");
            viewEditDeleteUserInfo.Add("a...accept a book");
            viewEditDeleteUserInfo.Add("e...enter your book");
            viewEditDeleteUserInfo.Add("w...words");
            viewEditDeleteUserInfo.Add(string.Empty);
            viewEditDeleteUserInfo.Add("d...delete your book");

            viewEditDeleteUserInfo.Add(string.Empty);
            viewEditDeleteUserInfo.Add("b...to go back to login\n");
            viewEditDeleteUserInfo.Add("Esc...to esc the app");
            return viewEditDeleteUserInfo;

        }
        public List<string> SuperAdminInfo()
        {
            List<string> superAdminInfo = new List<string>();
            superAdminInfo.Add("m...my books");
            superAdminInfo.Add("h...books in my hand");
            superAdminInfo.Add("c...carriers of my books");
            superAdminInfo.Add("o...circulation");
            superAdminInfo.Add("u...user info");
            superAdminInfo.Add("r...read");


            superAdminInfo.Add(string.Empty);
            superAdminInfo.Add("s...give a book");
            superAdminInfo.Add("a...accept a book");
            superAdminInfo.Add("e...enter your book");
            superAdminInfo.Add("w...words");
            superAdminInfo.Add(string.Empty);
            superAdminInfo.Add("d...delete your book");

            superAdminInfo.Add(string.Empty);
            superAdminInfo.Add("z...update user");
            superAdminInfo.Add("-...delete user");
            superAdminInfo.Add("+...new user");

            superAdminInfo.Add("b...to go back to login\n");
            superAdminInfo.Add("Esc...to esc the app");

            return superAdminInfo;
        }


        // The looks
        public ConsoleKeyInfo ShowHideInfoMenu()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("i...info: ");
            DotsDots();
            ConsoleKeyInfo info = Console.ReadKey();

            if (info.KeyChar == 'i')
            {
                for (int i = 0; i < InfoList().Count; i++)
                {
                    Console.SetCursorPosition(0, i + 7);
                    Console.Write(InfoList()[i]);
                }
            }
            info = Console.ReadKey();
            if (info.KeyChar == 'i' && info.KeyChar == 'I')
            {
                DotsDots();
            }
            return info;
        }

        public void DotsDots()
        {

            Console.SetCursorPosition(0, 0);
            Console.WriteLine();
            //Console.SetCursorPosition(0, 0);
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
            Console.WriteLine("...........................................");
        }
        public void dotsdots()
        {

            Console.SetCursorPosition(0, 0);
            Console.WriteLine();
            //Console.SetCursorPosition(0, 0);
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");
            Console.WriteLine("..................................");

        }
        public void D250ots()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("..........................................................................................................................................................................................................................................................");
            Console.SetCursorPosition(0, 29);
            Console.WriteLine("maximum of 250 characters ");
            Console.SetCursorPosition(0, 0);
        }

        public void PositionQuestions()
        {
            Console.SetCursorPosition(0, 7);
        }



        // avoid crash by string
        public static int intResult()
        {
            bool stringLoop;
            do
            {
                int intiger = 0;
                string input = Console.ReadLine();

                if (int.TryParse(input, out intiger))
                {
                    stringLoop = false;
                    return intiger;
                }
                else
                {
                    Console.WriteLine("not a number!");
                    stringLoop = true;
                }

            } while (stringLoop == true);
            return 0;
        }


       
    }
}
