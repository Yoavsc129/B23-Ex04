using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    class TimeDisplay:IItemAction
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
