using System;

namespace Ex04.Menus.Test
{
    public class MenuTests
    {
        private const char k_Space = ' ';

        public void TestMenuWithDelegates()
        {
            Delegates.MainMenu mainMenu = buildMenuWithDelegates();
            mainMenu.Show();
        }

        private Delegates.MainMenu buildMenuWithDelegates()
        {
            Delegates.Menu mainMenu = new Delegates.Menu(null, "Delegates Main Menu");
            mainMenu.AddMenuItem(buildShowDateTimeMenu(mainMenu));
            mainMenu.AddMenuItem(buildVersionAndSpacesMenu(mainMenu));

            return new Delegates.MainMenu(mainMenu);
        }

        private Delegates.Menu buildShowDateTimeMenu(Delegates.Menu i_MainMenu)
        {
            Delegates.Menu showDateTimeMenu = new Delegates.Menu(i_MainMenu, "Show Date/Time");
            Delegates.ActionMenuItem showDateMenuItem = new Delegates.ActionMenuItem("Show Date");
            showDateMenuItem.Chosen += showDate;
            showDateTimeMenu.AddMenuItem(showDateMenuItem);
            Delegates.ActionMenuItem showTimeMenuItem = new Delegates.ActionMenuItem("Show Time");
            showTimeMenuItem.Chosen += showTime;
            showDateTimeMenu.AddMenuItem(showTimeMenuItem);

            return showDateTimeMenu;
        }

        private Delegates.Menu buildVersionAndSpacesMenu(Delegates.Menu i_MainMenu)
        {
            Delegates.Menu versionAndSpacesMenu = new Delegates.Menu(i_MainMenu, "Version and Spaces");
            Delegates.ActionMenuItem showVersionMenuItem = new Delegates.ActionMenuItem("Show Version");
            showVersionMenuItem.Chosen += showVersion;
            versionAndSpacesMenu.AddMenuItem(showVersionMenuItem);
            Delegates.ActionMenuItem countSpacesMenuItem = new Delegates.ActionMenuItem("Count Spaces");
            countSpacesMenuItem.Chosen += countSpaces;
            versionAndSpacesMenu.AddMenuItem(countSpacesMenuItem);

            return versionAndSpacesMenu;
        }

        private void showDate()
        {
            Console.WriteLine(DateTime.Now.ToString("d") + Environment.NewLine);
        }

        private void showTime()
        {
            Console.WriteLine(DateTime.Now.ToString("T") + Environment.NewLine);
        }

        private void showVersion()
        {
            Console.WriteLine("Version: 23.2.4.9805" + Environment.NewLine);
        }

        private void countSpaces()
        {
            string userSentence;
            int spaceCounter = 0;

            Console.WriteLine("Please enter your sentence");
            userSentence = Console.ReadLine();

            if(userSentence != null)
            {
                foreach(char letter in userSentence)
                {
                    if(letter == k_Space)
                    {
                        spaceCounter++;
                    }
                }
            }

            Console.WriteLine($"There are {spaceCounter} spaces in your sentence {Environment.NewLine}");
        }
    }
}
