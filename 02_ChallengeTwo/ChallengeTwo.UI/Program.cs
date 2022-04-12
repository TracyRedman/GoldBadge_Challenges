using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Claim_Repository
    {
        private readonly Claim_Repository _cRepo = new Claim_Repository ();
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
            System.Console.WriteLine("Choose a menu item\n"+
            "1. See all claims\n"+
            "2. Take care of next claim\n"+
            "3. Enter a new claim\n" +
            "4. Close Application\n");

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
                case "4":
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
        PressAnyKeyToContinue();
        return false;
    }

    private void EnterANewClaim()
    {
        

    }

    private void TakeCareOfNextClaim()
    {
        throw new NotImplementedException();
    }

    private void SeeAllClaims()
    {
        throw new NotImplementedException();
    }

    private void SeedData()
    {
        ClaimQueue seed = new ClaimQueue();
        seed.SeedData();
    }
}