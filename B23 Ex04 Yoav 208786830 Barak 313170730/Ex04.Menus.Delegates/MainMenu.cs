using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    class MainMenu : Menu
    {
        public MainMenu(string i_MenuItemTitle) : base(null, i_MenuItemTitle)
        {
            s_CurrentMenu = this;
        }

        public void Show()
        {
            bool programIsRunning = true;
            int menuOption;

            while(programIsRunning)
            {
                Console.Clear();
                displayCurrentMenu();
                menuOption = readUserInput(s_CurrentMenu.MenuItemsCount);
                if(menuOption == k_Back)
                {
                    if(s_CurrentMenu is MainMenu)
                    {
                        programIsRunning = false;
                    }
                    else
                    {
                        s_CurrentMenu.ReturnToParentMenu();
                    }
                }
                else
                {
                    s_CurrentMenu.EnterInputForItem(menuOption);
                }
            }
        }

        private void displayCurrentMenu()
        {
            s_CurrentMenu.PrintTitle();
            printSeparator();
            s_CurrentMenu.PrintMenuItems();
            printSeparator();
            s_CurrentMenu.PrintUserInputRequest();
        }

        private void printSeparator()
        {
            Console.WriteLine("----------");
        }

        private int readUserInput(int i_InputRange)
        {
            int userInput = -1;//TODO: Add const
            bool inputIsInvalid = true;
            while(inputIsInvalid)
            {
                int.TryParse(Console.ReadLine(), out userInput);
                if(userInput >= k_Back && userInput <= i_InputRange)
                {
                    inputIsInvalid = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input");//TODO: Add const
                }
            }

            return userInput;
        }
    }
}
