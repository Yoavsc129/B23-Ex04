using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class VersionDisplay : IItemAction
    {
        private const string k_VersionText = "Version: 23.2.4.9805";

        public void ShowVersion()
        {
            Console.WriteLine(k_VersionText + Environment.NewLine);
        }

        public void InvokeMenuItemAction()
        {
            ShowVersion();
        }
    }
}
