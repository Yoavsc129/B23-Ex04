using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    class ActionMenuItem : MenuItem
    {
        public event Action Chosen;

        public ActionMenuItem(string i_MenuItemTitle) : base(i_MenuItemTitle)
        {
        }

        public override void ChooseItem()
        {
            OnChosen();
        }

        protected virtual void OnChosen()
        {

        }
    }
}
