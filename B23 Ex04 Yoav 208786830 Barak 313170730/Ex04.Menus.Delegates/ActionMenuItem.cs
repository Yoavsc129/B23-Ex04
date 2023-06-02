using System;

namespace Ex04.Menus.Delegates
{
    public class ActionMenuItem : MenuItem
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
            Chosen?.Invoke();
            Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
        }
    }
}
