using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    class DateDisplay:IItemAction
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
