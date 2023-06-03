using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class TimeDisplay : IItemAction
    {
        public void ShowTime()
        {
            Console.WriteLine(DateTime.Now.ToString("T") + Environment.NewLine);
        }

        public void InvokeMenuItemAction()
        {
            ShowTime();
        }
    }
}
