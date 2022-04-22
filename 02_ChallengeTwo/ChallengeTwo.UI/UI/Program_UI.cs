using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program_UI
{
    private readonly Claim_Repository _cRepo = new Claim_Repository();
    public void run()
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
            System.Console.WriteLine("Komodo Claims Department");
            System.Console.WriteLine("Choose a menu item\n" +
            "1. See all claims\n" +
            "2. Take care of next claim\n" +
            "3. Enter a new claim\n" +
            "50. Close Application\n");
            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    SeeAllClaims();
                    break;
                case "2":
                    TakeCareOfNextClaim();
                    break;
                case "3":
                    EnterANewClaim();
                    break;
                case "50":
                    isRunning = CloseApplication();
                    PressAnyKeyToContinue();
                    break;
            }
        }
    }
    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press Any Key To Continue");
        Console.ReadLine();
    }
    private bool CloseApplication()
    {
        Console.Clear();
        return false;
    }
    private void EnterANewClaim()
    {
        Console.Clear();
        Claim claim = new Claim();
        System.Console.WriteLine("Please Enter Claim Type\n" +
        "1. Car\n" +
        "2. Home\n" +
        "3. Theft\n");
        int userInputClaimNumber = int.Parse(Console.ReadLine());
        claim.ClaimType = (ClaimType)userInputClaimNumber;
        System.Console.WriteLine("Please Enter Description");
        claim.Description = Console.ReadLine();
        System.Console.WriteLine("Please Enter Claim Amount");
        claim.Amount = int.Parse(Console.ReadLine());
        System.Console.WriteLine("Please Enter Date of Incident YYYY-MM-DD");
        claim.OfIncident = Convert.ToDateTime(Console.ReadLine());
        System.Console.WriteLine("Please Enter Date of Claim YYYY-MM-DD");
        claim.OfClaim = Convert.ToDateTime(Console.ReadLine());
        if (_cRepo.AddClaimToQueue(claim))
        {
            System.Console.WriteLine("Add successful");
        }
        else
        {
            System.Console.WriteLine("Add failed");
        }
        PressAnyKeyToContinue();
    }
    private void TakeCareOfNextClaim()
    {
        Console.Clear();
        var claim = _cRepo.GetCurrentClaim();
        if (claim !=null)
        {
            DisplayClaimData(claim);
            System.Console.WriteLine("Take Care of Next Claim? y/n");
            var userInput = Console.ReadLine();
            if (userInput == "Y".ToLower() || userInput == "Y")
            {
                if(_cRepo.RemoveClaim())
                {
                    System.Console.WriteLine("Here is the next claim");
                }
                else
                {
                    System.Console.WriteLine("Invalid");
                }
            }
        }
        else
        {
            System.Console.WriteLine("There are no more claims");
        
        PressAnyKeyToContinue();
        }
    }
    private void SeeAllClaims()
    {
    Console.Clear();
    var claims = _cRepo.ClaimsInDatabase();
    foreach (var claim in claims)
    {
        DisplayClaimData(claim);
    }
        PressAnyKeyToContinue();
    }
    private void DisplayClaimData(Claim claim)
    {
        System.Console.WriteLine($"ClaimID: {claim.ID}\n" +
        $"ClaimType: {claim.ClaimType}\n" +
        $"Description: {claim.Description}\n" +
        $"Amount: {claim.Amount}\n" +
        $"Date Of Incident: {claim.OfIncident}\n" +
        $"Date of Claim: {claim.OfClaim}\n" +
        $"Is Valid: {claim.IsValid}\n" +
        "----------------------------\n"
        );
    }
    private void SeedData()
    {
        ClaimQueue seed= new ClaimQueue();
        foreach(var claim in seed.SeedData())
        {
            _cRepo.AddClaimToQueue(claim);
        }
        
    }
}
//seed data method grabbing a queue collection from another file 
