using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class DateDisplay : IItemAction
    {
        public void ShowDate()
        {
            Console.WriteLine(DateTime.Now.ToString("d") + Environment.NewLine);
        }

        public void InvokeMenuItemAction()
        {
            ShowDate();
        }
    }
}
