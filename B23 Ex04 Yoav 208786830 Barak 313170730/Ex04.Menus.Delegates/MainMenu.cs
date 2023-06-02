using System;

namespace Ex04.Menus.Delegates
{
    public class MainMenu : Menu
    {
        private const string k_InvalidInputMsg = "Invalid input";

        public MainMenu(string i_MenuItemTitle) : base(i_MenuItemTitle, null)
        {
            s_CurrentMenu = this;
        }

        public void Show()
        {
            bool programIsRunning = true;
            int menuOption;

            while(programIsRunning)
            {
                displayCurrentMenu();
                menuOption = readUserInput(s_CurrentMenu.MenuItemsCount);
                Console.Clear();
                if (menuOption == k_Back)
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
                    s_CurrentMenu.ChooseItemFromInput(menuOption);
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
