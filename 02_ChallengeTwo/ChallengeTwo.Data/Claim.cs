using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Claim
    {
        public Claim(){}
        public Claim(ClaimType claimType, string description, DateTime ofIncident, DateTime ofClaim, decimal amount)
        {
            ClaimType = claimType;
            Description = description;
            Amount = amount;
            OfIncident = ofIncident;
            OfClaim = ofClaim;
        }
        public int ID { get; set; }
        public decimal Amount {get; set; }
        public ClaimType ClaimType { get; set; } 
        public string Description { get; set; }
        public DateTime OfIncident { get; set; }
        public DateTime OfClaim { get; set; }
        public bool IsValid 
        { 
            get
            {
                TimeSpan span = OfClaim - OfIncident;
                return span.TotalDays <=30;
            } 
        }
    }
