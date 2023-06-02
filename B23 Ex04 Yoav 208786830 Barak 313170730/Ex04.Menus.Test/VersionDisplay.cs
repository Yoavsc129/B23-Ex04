using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    class VersionDisplay:IItemAction
    {
        private const string m_VersionText = "Version: 23.2.4.9805";
        public void ShowVersion()
        {
            Console.WriteLine(m_VersionText + Environment.NewLine);
        }

        public void InvokeMenuItemAction()
        {
            ShowVersion();
        }
    }
}
