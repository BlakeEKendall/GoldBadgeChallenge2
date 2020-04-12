using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2App
{
    
    public class Claim
    {
        public int ClaimID { get; set; }
        public enum ClaimType { Car=1, Home, Theft, Unknown}
        public ClaimType Type { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }

        public string DateOfIncident { get; set; }
        public string DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        

        public Claim() { }

        public Claim(
            int claimID,
            ClaimType type,
            string description,
            double claimAmount,
            string dateOfIncident,
            string dateOfClaim,
            bool isValid)
        {
            ClaimID = claimID;
            Type = type;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }

        //public bool CheckClaim()
        //{
        //    if (DateTime.Compare(DateOfIncident, DateOfClaim) > 30)
        //    {
        //        Console.WriteLine("Claim is over 30 days and is not valid");
        //        return false;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Claim is under 30 days and is valid!");
        //        return true;
        //    }
        //}
    }
}
