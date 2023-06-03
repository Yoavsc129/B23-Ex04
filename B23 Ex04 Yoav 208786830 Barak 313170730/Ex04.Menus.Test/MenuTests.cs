namespace Ex04.Menus.Test
{
    internal class MenuTests
    {
        private readonly DateDisplay r_DateDisplay = new DateDisplay();
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

            mainMenu.AddMenuItemToMenu(buildVersionAndSpacesMenuInterfaces(mainMenu));
            mainMenu.AddMenuItemToMenu(buildShowDateTimeMenuInterfaces(mainMenu));

            return mainMenu;
        }

        private Delegates.MainMenu buildMenuWithDelegates()
        {
            Delegates.Menu mainMenu = new Delegates.Menu("Delegates Main Menu", null);

            mainMenu.AddMenuItem(buildShowDateTimeMenuDelegates(mainMenu));
            mainMenu.AddMenuItem(buildVersionAndSpacesMenuDelegates(mainMenu));

            return new Delegates.MainMenu(mainMenu);
        }

        private Delegates.Menu buildShowDateTimeMenuDelegates(Delegates.Menu i_MainMenu)
        {
            Delegates.Menu showDateTimeMenu = new Delegates.Menu("Show Date/Time", i_MainMenu);
            Delegates.ActionMenuItem showDateMenuItem = new Delegates.ActionMenuItem("Show Date");
            Delegates.ActionMenuItem showTimeMenuItem = new Delegates.ActionMenuItem("Show Time");

            showDateMenuItem.Chosen += r_DateDisplay.ShowDate;
            showDateTimeMenu.AddMenuItem(showDateMenuItem);
            showTimeMenuItem.Chosen += r_TimeDisplay.ShowTime;
            showDateTimeMenu.AddMenuItem(showTimeMenuItem);

            return showDateTimeMenu;
        }

        private Delegates.Menu buildVersionAndSpacesMenuDelegates(Delegates.Menu i_MainMenu)
        {
            Delegates.Menu versionAndSpacesMenu = new Delegates.Menu("Version and Spaces", i_MainMenu);
            Delegates.ActionMenuItem showVersionMenuItem = new Delegates.ActionMenuItem("Show Version");
            Delegates.ActionMenuItem countSpacesMenuItem = new Delegates.ActionMenuItem("Count Spaces");

            showVersionMenuItem.Chosen += r_VersionDisplay.ShowVersion;
            versionAndSpacesMenu.AddMenuItem(showVersionMenuItem);
            countSpacesMenuItem.Chosen += r_SpaceCounter.CountSpaces;
            versionAndSpacesMenu.AddMenuItem(countSpacesMenuItem);

            return versionAndSpacesMenu;
        }

        private Interfaces.Menu buildVersionAndSpacesMenuInterfaces(Interfaces.MainMenu i_MainMenu)
        {
            Interfaces.Menu showDateTimeMenu = new Interfaces.Menu("Show Date/Time", i_MainMenu.Menu, i_MainMenu);
            Interfaces.ActionMenuItem showDateMenuItem = new Interfaces.ActionMenuItem("Show Date", r_DateDisplay);
            Interfaces.ActionMenuItem showTimeMenuItem = new Interfaces.ActionMenuItem("Show Time", r_TimeDisplay);

            showDateTimeMenu.AddNewMenuItemToChildList(showDateMenuItem);
            showDateTimeMenu.AddNewMenuItemToChildList(showTimeMenuItem);

            return showDateTimeMenu;
        }

        private Interfaces.Menu buildShowDateTimeMenuInterfaces(Interfaces.MainMenu i_MainMenu)
        {
            Interfaces.Menu versionAndSpacesMenu = new Interfaces.Menu("Version and Spaces", i_MainMenu.Menu, i_MainMenu);
            Interfaces.ActionMenuItem showVersionMenuItem = new Interfaces.ActionMenuItem("Show Version", r_VersionDisplay);
            Interfaces.ActionMenuItem countSpacesMenuItem = new Interfaces.ActionMenuItem("Count Spaces", r_SpaceCounter);

            versionAndSpacesMenu.AddNewMenuItemToChildList(showVersionMenuItem);
            versionAndSpacesMenu.AddNewMenuItemToChildList(countSpacesMenuItem);

            return versionAndSpacesMenu;
        }
    }
}
