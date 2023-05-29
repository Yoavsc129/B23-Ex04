using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    class Menu : MenuItem
    {
        private readonly List<MenuItem> r_MenuItems;
        private readonly Menu r_ParentMenu;
        protected const int k_Back = 0;
        protected static Menu s_CurrentMenu;

        public Menu(Menu i_ParentMenu, string i_MenuItemTitle) : base(i_MenuItemTitle)
        {
            r_MenuItems = new List<MenuItem>();
            r_ParentMenu = i_ParentMenu;
        }

        public int MenuItemsCount
        {
            get
            {
                return r_MenuItems.Count;
            }
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(i_MenuItem);
        }

        protected internal void PrintTitle()
        {
            Console.WriteLine($"** {r_MenuItemTitle}**");
        }

        protected internal void PrintMenuItems()
        {
            for (int i = 0; i < r_MenuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1} -> {r_MenuItems[i].MenuItemTitle}");
            }
        }

        protected internal void PrintUserInputRequest()
        {
            Console.WriteLine($"Enter your request: (1 to {r_MenuItems.Count} or press {(this is MainMenu ? "Exit" : "Back")}).");
        }

        public override void ChooseItem()
        {
            s_CurrentMenu = this;
        }

        protected internal void EnterInputForItem(int i_UserInput)//TODO: Change to better name
        {
            r_MenuItems[i_UserInput - 1].ChooseItem();
        }

        protected internal void ReturnToParentMenu()
        {
            s_CurrentMenu = r_ParentMenu;
        }
    }
}
