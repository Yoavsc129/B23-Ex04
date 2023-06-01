using System;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private const string k_InvalidInputMsg = "Invalid input";
        protected const int k_Back = 0;
        private readonly Menu r_MainMenu;

        public MainMenu(Menu i_MainMenu)
        {
            r_MainMenu = i_MainMenu;
            r_MainMenu.ChooseItem();
        }

        public void Show()
        {
            bool programIsRunning = true;
            int menuOption;
            Menu currentMenu;
            while(programIsRunning)
            {
                currentMenu = r_MainMenu.GetCurrentMenu();
                displayCurrentMenu(currentMenu);
                menuOption = readUserInput(currentMenu.MenuItemsCount);
                Console.Clear();
                if (menuOption == k_Back)
                {
                    if(currentMenu.ParentMenu == null)
                    {
                        programIsRunning = false;
                    }
                    else
                    {
                       currentMenu.ReturnToParentMenu();
                    }
                }
                else
                {
                    currentMenu.ChooseItemFromInput(menuOption);
                }
            }
        }

        private void displayCurrentMenu(Menu i_CurrentMenu)
        {
            i_CurrentMenu.PrintTitle();
            printSeparator();
            i_CurrentMenu.PrintMenuItems();
            printSeparator();
            i_CurrentMenu.PrintUserInputRequest();
        }

        private void printSeparator()
        {
            Console.WriteLine("----------");
        }

        private int readUserInput(int i_InputRange)
        {
            int userInput = 0;
            bool inputIsInvalid = true;
            bool parseSuccessful;

            while(inputIsInvalid)
            {
                parseSuccessful = int.TryParse(Console.ReadLine(), out userInput);
                if(userInput >= k_Back && userInput <= i_InputRange && parseSuccessful)
                {
                    inputIsInvalid = false;
                }
                else
                {
                    Console.WriteLine(k_InvalidInputMsg);
                }
            }

            return userInput;
        }
    }
}
