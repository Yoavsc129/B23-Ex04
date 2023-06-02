﻿using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class Menu : MenuItem
    {
        private readonly List<MenuItem> r_MenuItems;
        private readonly Menu r_ParentMenu;
        protected static Menu s_CurrentMenu;

        public Menu(string i_MenuItemTitle, Menu i_ParentMenu) : base(i_MenuItemTitle)
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

        public Menu ParentMenu
        {
            get
            {
                return r_ParentMenu;
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

            Console.WriteLine($"0 -> {(r_ParentMenu == null ? "Exit" : "Back")}");
        }

        protected internal void PrintUserInputRequest()
        {
            Console.WriteLine($"Enter your request: (1 to {r_MenuItems.Count} or press {(r_ParentMenu == null ? "Exit" : "Back")}).");
        }

        public override void ChooseItem()
        {
            s_CurrentMenu = this;
        }

        protected internal void ChooseItemFromInput(int i_UserInput)
        {
            r_MenuItems[i_UserInput - 1].ChooseItem();
        }

        public Menu GetCurrentMenu()
        {
            return s_CurrentMenu;
        }

        protected internal void ReturnToParentMenu()
        {
            s_CurrentMenu = r_ParentMenu;
        }
    }
}
