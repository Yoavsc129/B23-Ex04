namespace Ex04.Menus.Delegates
{
    public abstract class MenuItem
    {
        protected readonly string r_MenuItemTitle;

        protected MenuItem(string i_MenuItemTitle)
        {
            r_MenuItemTitle = i_MenuItemTitle;
        }

        public string MenuItemTitle
        {
            get
            {
                return r_MenuItemTitle;
            }
        }

        public abstract void ChooseItem();

    }
}
