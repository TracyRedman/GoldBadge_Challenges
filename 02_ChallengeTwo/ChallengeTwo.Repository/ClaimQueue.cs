public class ClaimQueue
{
    public void SeedData()
    {
        Queue<Claim> claimsInLine = new Queue<Claim>();

        var claim1 = new Claim
        {
            ID = 1,
            ClaimType = ClaimType.Car,
            Description = "Car accident on 465.",
            Amount = 400_00m,
            OfIncident = new DateTime(2018, 04, 25),
            OfClaim = new DateTime(2018, 04, 27),
            IsValid = true
        };

        var claim2 = new Claim
        {
            ID = 2,
            ClaimType = ClaimType.Home,
            Description = "House fire in Kitchen.",
            Amount = 4000_00m,
            OfIncident = new DateTime(2018, 04, 11),
            OfClaim = new DateTime(2018, 04, 12),
            IsValid = true
        };

        var claim3 = new Claim
        {
            ID = 3,
            ClaimType = ClaimType.Theft,
            Description = "Stolen Pancakes.",
            Amount = 4_00m,
            OfIncident = new DateTime(2018, 04, 27),
            OfClaim = new DateTime(2018, 06, 01),
            IsValid = false
        };

        claimsInLine.Enqueue(claim1);
        claimsInLine.Enqueue(claim2);
        claimsInLine.Enqueue(claim3);

        foreach (Claim claim in claimsInLine)
        {
            System.Console.WriteLine(claim.ClaimType);
        }

        var nextInLine = claimsInLine.Peek();
        System.Console.WriteLine($"Next In Line: {nextInLine.ClaimType}");

        claimsInLine.Dequeue();
        nextInLine = claimsInLine.Peek();
        System.Console.WriteLine($"Next In Line: {nextInLine.ClaimType}");
    }
}