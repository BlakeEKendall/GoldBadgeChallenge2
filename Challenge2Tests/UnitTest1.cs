using System;
using Challenge2App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge2Tests
{
    [TestClass]
    public class UnitTest1
    {
        ClaimRepository repo = new ClaimRepository();

        [TestMethod]
        public void ClaimCreationTests()
        {
            Claim newClaim = new Claim();
            newClaim.ClaimID = 11178;
            newClaim.ClaimAmount = 4300.00;
            newClaim.IsValid = true;

            Console.WriteLine($"Claim # {newClaim.ClaimID} is for ${newClaim.ClaimAmount}. Validity = {newClaim.IsValid}.");
        }

        [TestMethod]
        public void AddNewClaim_GetCorrectBool()
        {
            Claim claimToday = new Claim();
            claimToday.ClaimID = 11123;

            bool wasAdded = repo.AddClaim(claimToday);
            Assert.IsTrue(wasAdded);

            Assert.AreEqual(11123, claimToday.ClaimID);
            
        }

        [TestMethod]
        public void RemoveClaim_GetCorrectCount()
        {
            Claim claimA = new Claim();
            claimA.ClaimID = 12345;
            claimA.ClaimAmount = 2000.00;

            Claim claimB = new Claim();
            claimB.ClaimID = 11123;
            claimB.ClaimAmount = 100.00;


            repo.AddClaim(claimA);
            repo.AddClaim(claimB);
            int count = repo.GetAllClaims().Count;

            repo.DeleteClaim(claimA);
            int reCount = repo.GetAllClaims().Count;

            Assert.AreNotEqual(count, reCount);
        }

        [TestMethod]
        public void GetAllClaims_GetCorrectCount()
        {
            Claim claimA = new Claim();
            claimA.ClaimID = 12345;
            claimA.ClaimAmount = 2000.00;

            Claim claimB = new Claim();
            claimB.ClaimID = 11123;
            claimB.ClaimAmount = 100.00;

            Claim claimC = new Claim();
            claimC.ClaimID = 15039;
            claimC.ClaimAmount = 4000.00;


            repo.AddClaim(claimA);
            repo.AddClaim(claimB);
            repo.AddClaim(claimC);
            int actual = repo.GetAllClaims().Count;
            int expected = 3;

            
            Assert.AreEqual(actual, expected);
        }
    }
}
