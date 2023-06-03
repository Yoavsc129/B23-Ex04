using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class SpaceCounter : IItemAction
    {
        private const char k_Space = ' ';

        public void CountSpaces()
        {
            string userSentence;
            int spaceCounter = 0;

            Console.Write("Please enter your sentence: ");
            userSentence = Console.ReadLine();
            if (userSentence != null)
            {
                foreach (char letter in userSentence)
                {
                    if (letter == k_Space)
                    {
                        spaceCounter++;
                    }
                }
            }

            Console.WriteLine($"There are {spaceCounter} spaces in your sentence {Environment.NewLine}");
        }

        public void InvokeMenuItemAction()
        {
            CountSpaces();
        }
    }
}
