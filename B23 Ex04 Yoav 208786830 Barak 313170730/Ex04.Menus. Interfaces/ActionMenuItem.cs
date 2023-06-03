using System;

namespace Ex04.Menus.Interfaces
{
    public class ActionMenuItem : MenuItem
    {
        private readonly IItemAction r_ItemAction;

        public ActionMenuItem(string i_ItemDescription, IItemAction i_ItemAction)
            : base(i_ItemDescription)
        {
            r_ItemAction = i_ItemAction;
        }

        public override void InvokeMenuItem()
        {
            r_ItemAction.InvokeMenuItemAction();
            Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
        }
    }
}
