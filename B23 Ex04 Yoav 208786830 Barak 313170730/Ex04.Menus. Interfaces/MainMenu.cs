using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : ICurrentMenuSetter
    {
        private Menu m_CurrentMenuItem;

        public MainMenu(string i_MenuItemTitle)
        {
            Menu = new Menu("Interfaces Main Menu", null, this);
            m_CurrentMenuItem = Menu;
        }

        public void AddMenuItemToMenu(MenuItem i_MenuItem)
        {
            Menu.AddNewMenuItemToChildList(i_MenuItem);
        }

        public Menu Menu { get; }

        public void Show()
        {
            while (m_CurrentMenuItem != null)
            {
                m_CurrentMenuItem.InvokeMenuItem();
            }
        }

        void ICurrentMenuSetter.SetCurrentDisplayingMenu(Menu i_MenuItem)
        {
            m_CurrentMenuItem = i_MenuItem;
        }
    }
}