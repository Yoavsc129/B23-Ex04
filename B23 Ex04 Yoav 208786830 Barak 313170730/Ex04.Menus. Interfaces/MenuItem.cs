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