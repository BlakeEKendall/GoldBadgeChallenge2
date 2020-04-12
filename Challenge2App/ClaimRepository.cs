using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2App
{
    public class ClaimRepository
    {
        public List<Claim> _claimItems = new List<Claim>();
        

        public bool AddClaim(Claim claimToAdd)
        {
            int startingCount = _claimItems.Count;
            _claimItems.Add(claimToAdd);

            bool wasAdded = (_claimItems.Count > startingCount);
            return wasAdded;
        }


        public void DeleteClaim(Claim claimToDelete)
        {
            _claimItems.Remove(claimToDelete);
        }


        public List<Claim> GetAllClaims()
        {
            return _claimItems;
        }
    }
}
