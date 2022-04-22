using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Claim_Repository
{
    private readonly Queue<Claim> _claimDb = new Queue<Claim>();
    private int _count;

    //add claim to Queue
    public bool AddClaimToQueue(Claim claim)
    {
        if (claim is null)
        {
            return false;
        }
        _count++;
        claim.ID = _count;
        _claimDb.Enqueue(claim);
        return true;
    }
    // see all Claims
    public Queue<Claim> ClaimsInDatabase()
    {
        return _claimDb;
    }
    //see only current claim
    public Claim GetCurrentClaim()
    {
        if (_claimDb.Count >0)
        {
            var firstInLine = _claimDb.Peek();
            return firstInLine;
        }
        return null;
    }
//remove claim from Queue
    public bool RemoveClaim()
    {
        if (_claimDb.Count>0)
        {
            _claimDb.Dequeue();
            return true;
        }
        return false;
    }


    //two datetimes (parameters)
    //DateTime timeOfDay = new DateTime(2022,04,14); initial setup....
    //you can cmd+leftClick => To see metadata
    // public bool IsValidClaim(DateTime dateOfIncident, DateTime dateOfClaim)
    // {
    //     TimeSpan span = dateOfClaim - dateOfIncident;
    //     return span.TotalDays <=30;
    // }

}


