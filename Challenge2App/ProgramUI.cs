using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Challenge2App.Claim;

namespace Challenge2App
{
    public class ProgramUI
    {
        private readonly ClaimRepository _repo = new ClaimRepository();
        //private Queue claimQueue = new Queue();

        public void Run()
        {
            SeedMenu();
            RunMenu();
        }

        private void SeedMenu()
        {
            Claim claimA = new Claim(
                12345,
                Claim.ClaimType.Car,
                "Parking lot hit and run",
                1000.00,
                "12/25/2019",
                "02/15/2020",
                false);
            Claim claimB = new Claim(
                32456,
                Claim.ClaimType.Home,
                "Basement flooded",
                12000.00,
                "3/14/2020",
                "3/20/2020",
                true);
            Claim claimC = new Claim(
                11178,
                Claim.ClaimType.Car,
                "Fenderbender in traffic",
                6000.00,
                "01/19/2020",
                "02/10/2020",
                true);
            Claim claimD = new Claim(
                12345,
                Claim.ClaimType.Theft,
                "TV stolen during break-in",
                2500.00,
                "04/01/2019",
                "05/20/2019",
                false);
            Claim claimE = new Claim(
                32457,
                Claim.ClaimType.Home,
                "Roof damage from racoons",
                30000.00,
                "06/12/2019",
                "06/29/2019",
                false);

            _repo.AddClaim(claimA);
            _repo.AddClaim(claimB);
            _repo.AddClaim(claimC);
            _repo.AddClaim(claimD);
            _repo.AddClaim(claimE);

            //claimQueue.Enqueue(claimA);
            //claimQueue.Enqueue(claimB);
            //claimQueue.Enqueue(claimC);
            //claimQueue.Enqueue(claimD);
            //claimQueue.Enqueue(claimE);


        }

        private void RunMenu()
        {
            bool programIsRunning = true;
            while (programIsRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the virtual claims menu for Komodo Insurance!\n" +
                    "Please enter the number of the option you'd like to select:\n" +
                    "1. See All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        programIsRunning = false;
                        break;
                    default:
                        break;
                }

            }

        }

        private void SeeAllClaims()
        {
            Console.Clear();

            List<Claim> claims = _repo.GetAllClaims();
            Console.WriteLine("Claim ID | Claim Type | Claim Description       | Claim Amount | DateOfIncident | DateOfClaim |  IsValid");
            foreach (Claim item in claims)
            {
                Console.WriteLine($"{item.ClaimID,-10} {item.Type,-12} {item.Description,-25} ${item.ClaimAmount, -14}" +
                    $"{item.DateOfIncident,-16} {item.DateOfClaim,-15} {item.IsValid,6}"); 
            }   

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Random rand = new Random();
            List<Claim> claims = _repo.GetAllClaims();
            int index = rand.Next(claims.Count);
            var obj = claims[index];
            Console.WriteLine($"Here are the details for the next claim to be handled:\n" +
                $"Claim ID: {obj.ClaimID}\n" +
                $"Type: { obj.Type}\n" +
                $"Description: {obj.Description}\n" +
                $"Claim Amount: {obj.ClaimAmount}\n" +
                $"DateOfAccident: {obj.DateOfIncident}\n" +
                $"DateOfClaim: {obj.DateOfClaim}\n" +
                $"Is Valid: {obj.IsValid}");
            Console.WriteLine("Do you want to deal with this claim now (Y/N)?");
            string choice = Console.ReadLine().ToUpper();
            if (choice == "Y")
            {
                Console.WriteLine("Claim will be removed from top of queue");
                _repo.DeleteClaim(obj);

            }
            else
            {
                Console.WriteLine("Come back later to deal with claim.");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();

        }

        private void EnterNewClaim()
        {
            Console.Clear();
            Console.WriteLine("Enter claim ID #:");
            int idNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter the number for the claim type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string typeChoice = Console.ReadLine();
            ClaimType type;

            switch (typeChoice)
            {
                case "1":
                    type = ClaimType.Car;
                    break;
                case "2":
                    type = ClaimType.Home;
                    break;
                case "3":
                    type = ClaimType.Theft;
                    break;
                default:
                    type = ClaimType.Unknown;
                    break;
            }

            Console.WriteLine("\nEnter claim description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter amount of damage:");
            double claimAmount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter date of incident (in format MM/DD/YYYY):");
            string incidentDate = Console.ReadLine();

            Console.WriteLine("Enter date of claim (in format MM/DD/YYYY):");
            string claimDate = Console.ReadLine();

            Console.WriteLine("Is this claim valid, true or false?:");
            bool validity = Convert.ToBoolean(Console.ReadLine());

            Claim newClaim = new Claim(idNumber, type, description, claimAmount, incidentDate, claimDate, validity);

            bool itemWasAdded = _repo.AddClaim(newClaim);
            if (itemWasAdded)
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Error, please try again.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
