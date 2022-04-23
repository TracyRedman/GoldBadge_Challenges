using System.Collections.Generic;
using Xunit;

namespace _01_ChallengeOne_Tests;

public class MenuItem_Test
{
    [Fact]
    public void AddMenuItem_ShouldReturnTrue()
    {
        //AAA

        //Arrange
        var rice = new MenuItem("Rice", "Fried Rice", 
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
        //Act
        MenuItem_Repository _mRepo = new MenuItem_Repository();
        
        //Assert
        var isSuccessful = _mRepo.AddMenuItemToDatabase(rice);
        
        Assert.True(isSuccessful);
    }

    [Fact]
    public void GetAllMenuItems_ShouldReturnTwo()
    {
         //AAA

        //Arrange
        var rice = new MenuItem("Rice", "Fried Rice", 
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
        

        //Act
        MenuItem_Repository _mRepo = new MenuItem_Repository();
        _mRepo.AddMenuItemToDatabase(rice);
        _mRepo.AddMenuItemToDatabase(chickenSandwich);
        var itemsInRepository = _mRepo.GetAllMenuItems();
        var expected = 2;
        var actual = itemsInRepository.Count;
        //Assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void GetMenuItemByID_ShouldReturnCorrectID_True()
    {
        var rice = new MenuItem("Rice");
        _mRepo.GetMenuItemByID(1);
        var menuItem = _mRepo.GetMenuItemByID(2);
        var actual = menuItem.ID;
        var expected = 2;
        Assert.Equal(expected, actual);
    }
}


