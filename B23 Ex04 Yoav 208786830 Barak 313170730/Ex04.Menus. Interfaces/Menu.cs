using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class Menu : MenuItem
    {
        private const string k_SeparatorLine = "---------------------------------------";
        private const string k_InvalidInputMsg = "The input you entered is invalid. Please try again: ";
        private readonly Menu r_ParentMenu;
        private readonly ICurrentMenuSetter r_CurrentMenuSetter;
        private readonly List<MenuItem> r_CurrentMenuItemsList;
        private readonly string r_ExitMassage;

        public Menu(string i_ItemDescription, Menu i_ParentMenuItem, ICurrentMenuSetter i_CurrentMenuSetter)
            : base(i_ItemDescription)
        {
            r_ParentMenu = i_ParentMenuItem;
            r_CurrentMenuSetter = i_CurrentMenuSetter;
            r_ExitMassage = getExitMassage();
            r_CurrentMenuItemsList = new List<MenuItem>();
            r_CurrentMenuItemsList.Add(i_ParentMenuItem);
        }

        public void AddNewMenuItemToChildList(MenuItem i_MenuItem)
        {
            r_CurrentMenuItemsList.Add(i_MenuItem);
        }

        private string getExitMassage()
        {
            return isMainMenu() ? "Exit" : "Back";
        }

        private bool isMainMenu()
        {
            return r_ParentMenu == null;
        }

        private void printMenu()
        {
            int currentItemIndex = 0;
            StringBuilder menuDisplayBuilder = new StringBuilder(r_CurrentMenuItemsList.Count + 1);

            menuDisplayBuilder.AppendLine($"** {ItemDescription} **");
            menuDisplayBuilder.AppendLine(k_SeparatorLine);
            foreach (MenuItem currentMenuItem in r_CurrentMenuItemsList)
            {
                if(currentItemIndex > 0)
                {
                    menuDisplayBuilder.AppendLine($"{currentItemIndex}-> {currentMenuItem.ItemDescription}");
                }

                currentItemIndex++;
            }

            menuDisplayBuilder.AppendLine($"0-> {getExitMassage()}");
            menuDisplayBuilder.AppendLine(k_SeparatorLine);
            Console.Write(menuDisplayBuilder);
        }

        private int getValidChosenItemNumberFromUserToSubMenu()
        {
            bool inputIsValid = false;
            int userInput = 0;
            int maxValue = r_CurrentMenuItemsList.Count - 1;
            int minValue = 0;

            Console.Write($"Please choose number from {minValue + 1} to {maxValue} ( 0 to {getExitMassage()}): ");
            while (!inputIsValid)
            {
                inputIsValid = int.TryParse(Console.ReadLine(), out userInput)
                               && userInput >= minValue
                               && userInput <= maxValue;

                if (!inputIsValid)
                {
                    Console.Write(k_InvalidInputMsg);
                }
            }

            return userInput;
        }

        public override void InvokeMenuItem()
        {
            int userChoice;
            MenuItem currentChooseItem;
            
            printMenu();
            userChoice = getValidChosenItemNumberFromUserToSubMenu();
            currentChooseItem = r_CurrentMenuItemsList[userChoice];
            if (currentChooseItem is Menu subMenu)
            {
                r_CurrentMenuSetter.SetCurrentDisplayingMenu(subMenu);
            }
            else if(currentChooseItem == null)
            {
                r_CurrentMenuSetter.SetCurrentDisplayingMenu(null);
            }

            Console.Clear();
            currentChooseItem?.InvokeMenuItem();
        }
    }
}
