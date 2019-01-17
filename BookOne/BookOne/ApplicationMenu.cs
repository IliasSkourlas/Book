using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            viewOnlyUserInfo.Add("f...find");

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
            viewEditUserInfo.Add("f...find");


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
            viewEditDeleteUserInfo.Add("f...find");


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
            superAdminInfo.Add("f...find");


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
            Console.ForegroundColor = ConsoleColor.White;

        }

        public void dotsdots()
        {

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(42, 28);
            Console.WriteLine(".");
            Console.ForegroundColor = ConsoleColor.White;



        }

        public void D250ots()
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("..........................................................................................................................................................................................................................................................");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("maximum of 250 characters ");
            Console.SetCursorPosition(0, 15);
        }



        public void randomDot()
        {
            Random r = new Random();
            //from (0,1) to (42,29)

            int rNtimes = r.Next(0, 300);
            for (int i = 0; i < rNtimes; i++)
            {
                int ry = r.Next(1, 29);
                int rx = r.Next(0, 42);
                Console.SetCursorPosition(rx, ry);
                Console.WriteLine(".");
            }
        }

        public void randomLine()
        {
            Random r = new Random();
            //from (0,1) to (42,28)

            int rNtimes = r.Next(0, 300);
            for (int i = 0; i < rNtimes; i++)
            {
                int ry = r.Next(1, 28);
                int rx = r.Next(0, 42);
                Console.SetCursorPosition(rx, ry);
                Console.WriteLine("_");
                int ryy = r.Next(1, 28);
                int rxx = r.Next(0, 42);
                Console.SetCursorPosition(rxx, ryy);
                Console.WriteLine("|");
            }
        }

        public void randomSideLine()
        {
            Random r = new Random();
            //from (0,1) to (42,28)

            int rNtimes = r.Next(0, 300);
            for (int i = 0; i < rNtimes; i++)
            {
                int ry = r.Next(1, 28);
                int rx = r.Next(0, 42);
                Console.SetCursorPosition(rx, ry);
                Console.WriteLine("/");
                int ryy = r.Next(1, 28);
                int rxx = r.Next(0, 42);
                Console.SetCursorPosition(rxx, ryy);
                Console.WriteLine("'\'");
            }
        }

        public void randomParanthesis()
        {
            Random r = new Random();
            //from (0,1) to (42,29)

            int rNtimes = r.Next(0, 300);
            for (int i = 0; i < rNtimes; i++)
            {
                int ry = r.Next(1, 29);
                int rx = r.Next(0, 42);
                Console.SetCursorPosition(rx, ry);
                Console.WriteLine("(");
                int ryy = r.Next(1, 29);
                int rxx = r.Next(0, 42);
                Console.SetCursorPosition(rxx, ryy);
                Console.WriteLine(")");
            }
        }

        public void randomRedDot()
        {
            Random r = new Random();
            //from (0,1) to (42,29)

            int rNtimes = r.Next(0, 400);
            for (int i = 0; i < rNtimes; i++)
            {
                int ry = r.Next(1, 29);
                int rx = r.Next(0, 42);
                Console.SetCursorPosition(rx, ry);
                Console.WriteLine(".");
            }
        }


        public void VisualRandomPaternFour()
        {
            Console.ForegroundColor = ConsoleColor.White;
            DotsDots();
            Console.ForegroundColor = ConsoleColor.Cyan;
            randomDot();
            Console.ForegroundColor = ConsoleColor.Magenta;
            randomDot();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ComonRandomPaternEraser()
        {
            Console.ForegroundColor = ConsoleColor.White;
            randomDot();
            Console.ForegroundColor = ConsoleColor.Cyan;
            randomDot();
            Console.ForegroundColor = ConsoleColor.Magenta;
            randomDot();
            Console.ForegroundColor = ConsoleColor.White;
        }


        public void VisualRandomPaternTwo()
        {
            DotsDots();
            Console.ForegroundColor = ConsoleColor.Blue;
            randomLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void VisualRandomPaternThree()
        {
            DotsDots();
            Console.ForegroundColor = ConsoleColor.Cyan;
            randomSideLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void VisualRandomPaternOne()
        {
            Console.ForegroundColor = ConsoleColor.White;
            DotsDots();
            Console.ForegroundColor = ConsoleColor.Red;
            randomDot();
            Console.ForegroundColor = ConsoleColor.Magenta;
            randomParanthesis();
            Console.ForegroundColor = ConsoleColor.Cyan;
            randomDot();
            Console.ForegroundColor = ConsoleColor.Blue;
            randomDot();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void EptySpace()
        {
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");



        }

        public void PositionQuestions()
        {
            Console.SetCursorPosition(0, 7);
        }


        public void UpdateShortcut(int myRole)
        {

            Console.Clear();

            VisualPaternsByMyRole(myRole);

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("all the users ");

            Console.SetCursorPosition(43, 0);
            Console.Write("Id");
            Console.SetCursorPosition(48, 0);
            Console.Write("name");
            Console.SetCursorPosition(61, 0);
            Console.Write("role");
            Console.SetCursorPosition(69, 0);
            Console.Write("carried");
            Console.SetCursorPosition(78, 0);
            Console.Write("claps");

            Console.ForegroundColor = ConsoleColor.DarkGray;// not yet implemented
            Console.SetCursorPosition(86, 0);
            Console.Write("punch");
            Console.ForegroundColor = ConsoleColor.Yellow;


            User.GetInfoAllUsers(0);
            Console.SetCursorPosition(0, 29);
        }

        public void VisualPaternsByMyRole(int myRole)
        {
            if (myRole == 4)
            {
                VisualRandomPaternFour();
            }
            if(myRole == 3)
            {
                VisualRandomPaternThree();

            }
            if(myRole == 2)
            {
                VisualRandomPaternTwo();

            }
            if(myRole == 1)
            {
                VisualRandomPaternOne();

            }
        }


        public void TwoColorsChainge(int i)
        {
            if (i % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
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
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("not a number!");
                    Console.ForegroundColor = ConsoleColor.White;

                    stringLoop = true;
                }

            } while (stringLoop == true);
            return 0;
        }


        public void TheStart()
        {
            Console.Clear();
            Console.SetCursorPosition(48, 4);
            Console.WriteLine("Hallo");
            Console.SetCursorPosition(48, 5);
            System.Threading.Thread.Sleep(4000);
        }
        public void TheEnd()
        {
            Console.Clear();
            Console.SetCursorPosition(48, 4);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("The End");
            Console.SetCursorPosition(48, 5);
            System.Threading.Thread.Sleep(4000);
        }

    }
}
