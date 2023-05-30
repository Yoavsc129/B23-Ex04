using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    class MenuItem
    {
        private readonly List<MenuItem> r_CurrentMenuItemsList;

        public MenuItem()
        {
            r_CurrentMenuItemsList = new List<MenuItem>();
        }

        public bool MenuItemIsLeaf()
        {
            return r_CurrentMenuItemsList.Count == 0;
        }

        public void AddMenuItemToList(IItemAction menuItemAction)
    }
}
