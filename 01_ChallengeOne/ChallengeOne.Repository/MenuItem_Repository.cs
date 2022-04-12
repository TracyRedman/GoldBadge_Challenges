using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class MenuItem_Repository
    {
        private readonly List<MenuItem> _menuItemDatabase = new List<MenuItem>();
        private int _count = 0;
        public bool AddMenuItemToDatabase(MenuItem menuItem)
        {
            if (menuItem !=null)
            {
                _count++;
                menuItem.ID = _count;
                _menuItemDatabase.Add(menuItem);
                return true;
            }
            else
            {
                return false;
            }
        }
    public List<MenuItem> GetAllMenuItems()
        {
            return _menuItemDatabase;
        }
    public MenuItem GetMenuItemByID(int id)
    {
        foreach (MenuItem menuItem in _menuItemDatabase)
        {
            if (menuItem.ID == id)
            {
                return menuItem;
            }
        }
        return null;
    }
    public bool UpdateMenuItemData(int menuItemID, MenuItem newMenuItemData)
    {
        MenuItem oldMenuItemData = GetMenuItemByID(menuItemID);
        if (oldMenuItemData !=null)
        {
            oldMenuItemData.Description = newMenuItemData.Description;
            oldMenuItemData.ID = newMenuItemData.ID;
            oldMenuItemData.Ingredients = newMenuItemData.Ingredients;
            oldMenuItemData.Name = newMenuItemData.Name;
            oldMenuItemData.Price = newMenuItemData.Price;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool RemoveMenuItemFromDatabase(int id)
    {
        var menuItem = GetMenuItemByID(id);
        if (menuItem !=null)
        {
            _menuItemDatabase.Remove(menuItem);
            return true;
        }
        else
        {
            return false;
        }
    }
}