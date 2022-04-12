using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Claim_Repository
    {
    private readonly _claimTypeDB  
    private int _count =0;
    public bool AddClaimToDatabase(Claim claim)
    {
        return AddClaimToDatabase(AssignClaimID(claimType));
    }
    private bool AddToDatabase (Claim_Repository claim)
    {
        _claimTypeDB.Add(claim);
            return true;
    }
    private Claim AssignClaimID (Claim_Repository claim)
    {
        _count++;
        claim.ID= _count;
        return claim;
    }
}


