using System;
using System.Collections.Generic;
using Xunit;

namespace _03_ChallengeThree_Tests;

public class BadgeTest
{
    private readonly Badge_Repository _bRepo;
    public BadgeTest()
    {
        _bRepo = new Badge_Repository();
        Seed();
    }
    [Fact]
    public void AddBadgeToDatabase_ShouldRetrunTrue()
    {
        //Act
        Badge badgeD = new Badge("12373", new List<string> { "A1", "A2" });
        Assert.True(_bRepo.AddBadgeToDatabase(badgeD));
    }
    [Fact]
    public void GetBadges_ShouldHaveSameCount()
    {
        var expectedCount = 3;
        var actualCount = _bRepo.GetBadges().Count;
        Assert.Equal(expectedCount, actualCount);
    }
    [Fact]
    public void GetBadgeByKey_ShouldRetrunEqual()
    {
        var expectedName = "12345";
        var actual = _bRepo.GetBadgeByKey(1);
        Assert.Equal(expectedName, actual.Name);
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
}