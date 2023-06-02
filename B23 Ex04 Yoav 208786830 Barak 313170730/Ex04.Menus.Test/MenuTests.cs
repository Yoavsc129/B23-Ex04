using System;
using Ex04.Menus;


namespace Ex04.Menus.Test
{
    public class MenuTests
    {

        private readonly DateDisplay r_DateDisplay= new DateDisplay();
        private readonly SpaceCounter r_SpaceCounter = new SpaceCounter();
        private readonly TimeDisplay r_TimeDisplay = new TimeDisplay();
        private readonly VersionDisplay r_VersionDisplay = new VersionDisplay();

        public void TestMenuWithDelegates()
        {
            Delegates.MainMenu delegatesMainMenu = buildMenuWithDelegates();
            Interfaces.MainMenu interfacesMainMenu = buildMenuWithInterfaces();

            delegatesMainMenu.Show();
            interfacesMainMenu.Show();


        }

        private Interfaces.MainMenu buildMenuWithInterfaces()
        {
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu("Interfaces Main Menu");

            mainMenu.AddMenuItemToMenu(buildShowDateTimeMenuInterfaces(mainMenu));
            mainMenu.AddMenuItemToMenu(buildVersionAndSpacesMenuInterfaces(mainMenu));

            return mainMenu;
        }

     
        private Delegates.MainMenu buildMenuWithDelegates()
        {
            Delegates.Menu mainMenu = new Delegates.Menu(null, "Delegates Main Menu");
            mainMenu.AddMenuItem(buildShowDateTimeMenu(mainMenu));
            mainMenu.AddMenuItem(buildVersionAndSpacesMenu(mainMenu));

            return new Delegates.MainMenu(mainMenu);
            mainMenu.AddMenuItem(buildShowDateTimeMenuDelegates(mainMenu));
            mainMenu.AddMenuItem(buildVersionAndSpacesMenuDelegates(mainMenu));

            return mainMenu;
        }

        private Delegates.Menu buildShowDateTimeMenuDelegates(Delegates.MainMenu i_MainMenu)
        {
            Delegates.Menu showDateTimeMenu = new Delegates.Menu("Show Date/Time", i_MainMenu);
            Delegates.ActionMenuItem showDateMenuItem = new Delegates.ActionMenuItem("Show Date");
            showDateMenuItem.Chosen += r_DateDisplay.ShowDate;
            showDateTimeMenu.AddMenuItem(showDateMenuItem);
            Delegates.ActionMenuItem showTimeMenuItem = new Delegates.ActionMenuItem("Show Time");
            showTimeMenuItem.Chosen += r_TimeDisplay.ShowTime;
            showDateTimeMenu.AddMenuItem(showTimeMenuItem);

            return showDateTimeMenu;
        }

        private Delegates.Menu buildVersionAndSpacesMenuDelegates(Delegates.MainMenu i_MainMenu)
        {
            Delegates.Menu versionAndSpacesMenu = new Delegates.Menu( "Version and Spaces", i_MainMenu);
            Delegates.ActionMenuItem showVersionMenuItem = new Delegates.ActionMenuItem("Show Version");
            showVersionMenuItem.Chosen += r_VersionDisplay.ShowVersion;
            versionAndSpacesMenu.AddMenuItem(showVersionMenuItem);
            Delegates.ActionMenuItem countSpacesMenuItem = new Delegates.ActionMenuItem("Count Spaces");
            countSpacesMenuItem.Chosen += r_SpaceCounter.CountSpaces;
            versionAndSpacesMenu.AddMenuItem(countSpacesMenuItem);

            return versionAndSpacesMenu;
        }


        private Interfaces.Menu buildVersionAndSpacesMenuInterfaces(Interfaces.MainMenu i_MainMenu)
        {
            Interfaces.Menu showDateTimeMenu ;
            Interfaces.ActionMenuItem showDateMenuItem;
            Interfaces.ActionMenuItem showTimeMenuItem;

            showDateTimeMenu = new Interfaces.Menu( "Show Date/Time", i_MainMenu.Menu, i_MainMenu);
            showDateMenuItem = new Interfaces.ActionMenuItem("Show Date",r_DateDisplay);
            showDateTimeMenu.AddNewMenuItemToChildList(showDateMenuItem);
            showTimeMenuItem = new Interfaces.ActionMenuItem("Show Time",r_TimeDisplay);
        
            showDateTimeMenu.AddNewMenuItemToChildList(showTimeMenuItem);

            return showDateTimeMenu;
        }

        private Interfaces.Menu buildShowDateTimeMenuInterfaces(Interfaces.MainMenu i_MainMenu)
        {
            Interfaces.Menu versionAndSpacesMenu;
            Interfaces.ActionMenuItem showVersionMenuItem;
            Interfaces.ActionMenuItem countSpacesMenuItem;

            versionAndSpacesMenu = new Interfaces.Menu( "Version and Spaces", i_MainMenu.Menu, i_MainMenu);
            showVersionMenuItem = new Interfaces.ActionMenuItem("Show Version", r_VersionDisplay);
            versionAndSpacesMenu.AddNewMenuItemToChildList(showVersionMenuItem);
            countSpacesMenuItem = new Interfaces.ActionMenuItem("Count Spaces", r_SpaceCounter);
            versionAndSpacesMenu.AddNewMenuItemToChildList(countSpacesMenuItem);

            return versionAndSpacesMenu;
        }




    }
}
