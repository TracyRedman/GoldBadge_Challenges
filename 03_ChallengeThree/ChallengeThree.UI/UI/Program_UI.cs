using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program_UI
{
    //making an istance where the badge_repo to access the repo methods!
    private readonly Badge_Repository _bRepo = new Badge_Repository();
    public void Run()
    {
        Seed();
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("Hello Security Admin!");
            System.Console.WriteLine("What would you like to do?\n" +
            "1. Add a badge\n" +
            "2. Edit a badge\n" +
            "3. List all badges\n" +
            "4. Remove all badges\n" +
            "5. Exit\n");

            var userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    AddBadgeToDictionary();
                    break;
                case 2:
                    EditBadge();
                    break;
                case 3:
                    ListAllBadgesInDictionary();
                    break;
                case 4:
                    RemoveBadgeFromDictionary();
                    break;
                case 5:
                    isRunning = Exit();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selection");
                    PressAnyKeyToContinue();
                    break;
            }
        }
    }
    private bool Exit()
    {
        Console.Clear();
        System.Console.WriteLine("Bye");
        PressAnyKeyToContinue();
        return false;
    }
    private void AddBadgeToDictionary()
    {
        Console.Clear();
        Badge badge = new Badge();
        System.Console.WriteLine("Please intput Name");
        var userInput = Console.ReadLine();
        badge.Name = userInput;
        //we want a variable of type bool to use as an on/off switch
        bool hasAssignedDoors = false;
        //use a whle loop to add doors
        while (!hasAssignedDoors)
        {
            System.Console.WriteLine("Please input door name: ");
            var userInputDoorName = Console.ReadLine();
            //we need to add this door to the badge list of doors
            badge.Doors.Add(userInputDoorName);
            System.Console.WriteLine("Would you like to add another door? y/n");
            var userInputAddDoor = Console.ReadLine();
            if (userInputAddDoor == "Y".ToLower())
            {
                continue;
            }
            else
            {
                hasAssignedDoors = true;
            }
        }
        bool success = _bRepo.AddBadgeToDatabase(badge);
        if (success)
        {
            System.Console.WriteLine("Door Added");
        }
        else
        {
            System.Console.WriteLine("Door Failed to be Added");
        }
        PressAnyKeyToContinue();
    }
    private void DisplayBadgeInfo(Badge badge)
    {
        System.Console.WriteLine($"Badge ID: {badge.ID}\n" +
        $"Door Access : \n" +
        "----------------------------\n"
        );
        foreach (var door in badge.Doors)
        {
            System.Console.WriteLine(door);
        }
    }
    private void EditBadge()
    {
        Console.Clear();

        var availBadges = _bRepo.GetBadges();
        // foreach (var badge in availBadges.Values)
        // {
        //     DisplayBadgeInfo(badge);
        // }
        System.Console.WriteLine("Please enter a valid Badge ID to update:");
        var userKeyInput = int.Parse(Console.ReadLine());
        var userSelectedBadge = _bRepo.GetBadgeByKey(userKeyInput);

        if (userSelectedBadge != null)
        {
            Console.Clear();
            //  var newBadge = new Badge();
            //  var currentDoors = _bRepo.GetDoors();

            //   System.Console.WriteLine("Please enter a Badge Name");
            //  newBadge.Name = Console.ReadLine();

            //    bool hasAssignedDoors = false;
            //  while (!hasAssignedDoors)
            //   {
            Console.Clear();
            //   System.Console.WriteLine("${userKeyInput} has access to doors {userInputDoors}");

            System.Console.WriteLine("What would you like to update?\n" +
            "1. Add door\n" +
            "2. Remove door\n" +
            "3. Main Menu\n");
            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddDoor();
                    break;
                case "2":
                    RemoveDoor();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selection");
                    PressAnyKeyToContinue();
                    break;
            }
        }
        else
        {
            System.Console.WriteLine($"Sorry the Badge with the ID: {userKeyInput} does not exist");
        }

        PressAnyKeyToContinue();
    }
    private void ListAllBadgesInDictionary()
    {
        Console.Clear();
        var badges = _bRepo.GetBadges();
        foreach (var badge in badges.Values)
        {
            DisplayBadgeInfo(badge);
        }
        PressAnyKeyToContinue();
    }
    private void RemoveBadgeFromDictionary()
    {
        Console.Clear();

        var badges = _bRepo.GetBadges();
        foreach (var badge in badges.Values)
        {
            DisplayBadgeInfo(badge);
        }
        try
        {
            System.Console.WriteLine("Please select Badge by its ID:");
            var userKeyInput = int.Parse(Console.ReadLine());
            bool isSuccessful = _bRepo.DeleteBadgeData(userKeyInput);
            if (isSuccessful)
            {
                System.Console.WriteLine("Badge was successfully deleted.");
            }
            else
            {
                System.Console.WriteLine("Failed to delete Badge.");
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry, invalid selection.");
        }
        PressAnyKeyToContinue();
    }
    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press Any Key To Continue");
        Console.ReadKey();
    }
    private void Seed()
    {
        Console.Clear();

        Badge badgeA = new Badge("12345", new List<string> { "A1", "A2" });
        Badge badgeB = new Badge("22345", new List<string> { "A1", "A2", "B3" });
        Badge badgeC = new Badge("32345", new List<string> {"A4", "A5"});
        //we need to connect these to the badge repo
        _bRepo.AddBadgeToDatabase(badgeA);
        _bRepo.AddBadgeToDatabase(badgeB);
        _bRepo.AddBadgeToDatabase(badgeC);
    }
    private void AddDoor()
    {
        Console.Clear();
        System.Console.WriteLine("Enter a vaild Badge ID");
        int badgeID = int.Parse(Console.ReadLine());
        System.Console.WriteLine("Please Enter the name of the door you want to add:");
        string userInputDoorName = Console.ReadLine();
        var success = _bRepo.AddDoor(badgeID, userInputDoorName);
        if (success)
        {
            System.Console.WriteLine($"{badgeID} has access to door {userInputDoorName}");
        }
        else
        {
            System.Console.WriteLine("Failed");
        }
        System.Console.WriteLine("Press Any Key To Continue");
        Console.ReadKey();
    }
    private void RemoveDoor()
    {
        System.Console.WriteLine("Enter a vaild Badge ID");
        int badgeID = int.Parse(Console.ReadLine());
        System.Console.WriteLine("What door would you like to remove?");
        string userInputRemoveDoor = Console.ReadLine();
        var success = _bRepo.RemoveDoor(badgeID, userInputRemoveDoor);
        if (success)
        {
            System.Console.WriteLine("Success");
        }
        else
        {
            System.Console.WriteLine("Failed");
        }
        Console.ReadKey();
    }
}


