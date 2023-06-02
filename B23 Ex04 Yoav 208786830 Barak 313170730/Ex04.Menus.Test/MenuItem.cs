using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public abstract class MenuItem
    {
        
        public string ItemDescription { get; }

        public MenuItem(string i_ItemDescription)
        {
            ItemDescription = i_ItemDescription;

        }

        public abstract void InvokeMenuItem();



    }
}
