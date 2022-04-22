using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class MenuItem_UI
    {
        private readonly MenuItem_Repository _mRepo = new MenuItem_Repository();
        public void Run()
        {
            SeedData();
            RunApplication();
        }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("Komodo Cafe Menu");
            System.Console.WriteLine("Please Make a Selection: \n"+
            "1. View All Menu Items By ID\n"+
            "2. Add New Item to Database\n"+
            "3. Delete Menu Item\n"+
            "4. Exit");
            
            var userInput = Console.ReadLine();

            switch (userInput)
            {
            case "1":
                ViewAllMenuItems ();
                break;
            case "2":
                AddMenuItemToDatabase();
                break;
            case "3":
                DeleteMenuItem();
                break;
            case "4":
                isRunning = CloseApplication ();
                break;
            default:
                System.Console.WriteLine("Invalid Selection");
                PressAnyKeyToContinue();
                break;
            }
        }
    }
    private bool CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Have a Nice Day!");
        PressAnyKeyToContinue();
        return false;
    }
    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("PressAnyKeyToContinue");
        Console.ReadKey();
    }
    private void DeleteMenuItem()
    {
        Console.Clear();
        System.Console.WriteLine("Delete Menu Item");

        var menuItems = _mRepo.GetAllMenuItems();
        foreach (MenuItem menuItem in menuItems)
        {
            DisplayMenuItemInfo(menuItem);
        }

        try
        {
            System.Console.WriteLine("Select Menu Item by ID:");
            var userInputMenuItemsID = int.Parse(Console.ReadLine());
            bool isSuccessful = _mRepo.RemoveMenuItemFromDatabase(userInputMenuItemsID);
            if (isSuccessful)
            {
                System.Console.WriteLine("Menu Item was deleted.");
            }
            else
            {
                System.Console.WriteLine("Menu Item failed to delete.");
            }
        }
        catch
        {
            System.Console.WriteLine("Invalid selection!");
        }
        PressAnyKeyToContinue();
    }
    private void AddMenuItemToDatabase()
    {
        Console.Clear();

        var newMenuItem = new MenuItem();
        System.Console.WriteLine("Menu Item Enlist Form\n");
        System.Console.WriteLine("Enter Menu Item Name: ");
        newMenuItem.Name = Console.ReadLine();
        bool isSuccessful = _mRepo.AddMenuItemToDatabase(newMenuItem);
        if (isSuccessful)
        {
            System.Console.WriteLine($"{newMenuItem.Name} - {newMenuItem.Ingredients} was added to the Database!");
        }
        else
        {
            System.Console.WriteLine("Failed to add Menu Item to Database");
        }
        PressAnyKeyToContinue();
    }
    private void ViewAllMenuItemByID()
    {
        Console.Clear();
        System.Console.WriteLine("Menu Item List");
        System.Console.WriteLine("Enter Menu Item ID");
        var userInputMenuItemID = int.Parse(Console.ReadLine());

        var menuItem = _mRepo.GetMenuItemByID(userInputMenuItemID);

        if (menuItem !=null)
        {
            DisplayMenuItemInfo(menuItem);
        }
        else
        {
            System.Console.WriteLine($"The Menu Item with the ID :{userInputMenuItemID} does not exist!");
        }
        PressAnyKeyToContinue();
    }
    private void DisplayMenuItemInfo(MenuItem menuItem)
    {
        DisplayMenuItemData(menuItem);
    }
    private void ViewAllMenuItems()
{
    Console.Clear();
    var menuItems = _mRepo.GetAllMenuItems();

    foreach (var menuItem in menuItems)
    {
        DisplayMenuItemData(menuItem);
    }
    PressAnyKeyToContinue();
}
    private void DisplayMenuItemData(MenuItem menuItem)
    {
        System.Console.WriteLine($"MenuItemID: {menuItem.ID}\n"+
        "-----------------------------------\n"+
        $"MenuItemName: {menuItem.Name}\n"+ "MenuItemIngredients: {menuItem.Ingreditent}\n" + 
        "MenuItemPrice: {menuItem.Price}\n"
        );
        foreach (var ingredient in menuItem.Ingredients)
        {
            System.Console.WriteLine(ingredient);
        }
    }
    private void SeedData()
    {
        var rice = new MenuItem("Fried Rice", "Fried Rice", 
        new List<string> 
        {
            "Mushrooms",
            "Bell Peppers",
            "Onion",
            "Chicken"
        }, 2_49);

        var chickenSandwich = new MenuItem("Cconut Crusted Chicken Sandwich", "Coconut Crusted Chicken Thigh",
        new List<string>
        {
            "Lettuce",
            "Onion",
            "Tomato",
            "YumYum Sauce"
        }, 6_99);
        _mRepo.AddMenuItemToDatabase(rice);
        _mRepo.AddMenuItemToDatabase(chickenSandwich);
    }
}
