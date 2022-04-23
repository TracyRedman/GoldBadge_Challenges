using Xunit;

namespace _02_ChallengeTwo_Tests;

public class ClaimTest
{
    private readonly Claim_Repository _cRepo;
    public ClaimTest()
    {
        _cRepo = new Claim_Repository();
        Seed();
    }
    [Fact]  
    public void AddClaimToQueue_ShouldHaveSameCount()
    {
        var expectedCount = 4;
        var actualCount = _cRepo.AddClaimToQueue().Count;
        Assert.Equal(expectedCount, actualCount);
    }
    [Fact]
    public void DisplayClaimData_ShouldReturnTrue()
    {
        
    }

}