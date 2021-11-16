using KomodoClaims.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    class ProgramUI
    {
        private static ClaimRepository _claimRepository = new ClaimRepository();
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            SeedContent();
            Run();
        }
        private static void Run()
        {
            Console.SetWindowSize(170, 40);
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(@"
  _____  _                 _____  __  __   _____ 
 / ____|| |         /\    |_   _||  \/  | / ____|
| |     | |        /  \     | |  | \  / || (___  
| |     | |       / /\ \    | |  | |\/| | \___ \ 
| |____ | |____  / ____ \  _| |_ | |  | | ____) |
 \_____||______|/_/    \_\|_____||_|  |_||_____/ 
                                                                ");
                Console.WriteLine("1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");
                int userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 01:
                        ShowAllContent();
                        break;
                    case 02:
                        RemoveClaim();
                        break;
                    case 03:
                        CreateNewItem();
                        break;
                    case 04:
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4!\n" + "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private static void SeedContent()
        {
            Claim item1 = new Claim(1001, ClaimType.Car, "Rear-ended in traffic.", 350.58d, new DateTime(2021, 10, 23), new DateTime(2021, 11, 13).Date);
            Claim item2 = new Claim(1002, ClaimType.Home, "Basement flooded due to backed-up sewage line.", 5027.32d, new DateTime(2021, 10, 20).Date, new DateTime(2021, 10, 22).Date);
            Claim item3 = new Claim(1003, ClaimType.Theft, "Robbed for gold wedding band.", 755.79d, new DateTime(2021, 08, 25), new DateTime(2021, 11, 2));
            Claim item4 = new Claim(1004, ClaimType.Car, "Hit pole in parking lot", 157.89d, new DateTime(2020, 05, 25), new DateTime(2020, 05, 26));
            Claim item5 = new Claim(1005, ClaimType.Car, "Cracked windshield", 275.50d, new DateTime(2021, 03, 03), new DateTime(2021, 04, 01));
            Claim item6 = new Claim(1006, ClaimType.Car, "Robbed for gold wedding band.", 755.79d, new DateTime(2021, 08, 25), new DateTime(2021, 11, 2));
            Claim item7 = new Claim(1007, ClaimType.Theft, "Break-in stolen television", 607.44d, new DateTime(2021, 09, 02), new DateTime(2021, 09, 03));
            Claim item8 = new Claim(1008, ClaimType.Home, "Flooded bathtub", 887.02d, new DateTime(2021, 10, 05), new DateTime(2021, 10, 10));
            Claim item9 = new Claim(1009, ClaimType.Home, "exposed live-wire in wall, fire", 7304.51d, new DateTime(2021, 06, 04), new DateTime(2021, 07, 20));
            Claim item10 = new Claim(1010, ClaimType.Car, "Fender bender", 129.21d, new DateTime(2020, 06, 14), new DateTime(2021, 01, 23));
            _claimRepository.AddContentToDirectory(item1);
            _claimRepository.AddContentToDirectory(item2);
            _claimRepository.AddContentToDirectory(item3);
            _claimRepository.AddContentToDirectory(item4);
            _claimRepository.AddContentToDirectory(item5);
            _claimRepository.AddContentToDirectory(item6);
            _claimRepository.AddContentToDirectory(item7);
            _claimRepository.AddContentToDirectory(item8);
            _claimRepository.AddContentToDirectory(item9);
            _claimRepository.AddContentToDirectory(item10);
        }
        private static void ShowAllContent()
        {
            Console.Clear();
            List<Claim> listOfContent = _claimRepository.GetContents();
            Console.WriteLine($"{"Claim ID:",-20}" + $"{"Claim Type:",-20}" + $"{"Description:",-50}" + $"{"Claim Amount:",-20}" + $"{"Incident Date:",-20}" + $"{"Claim Date:",-20}" + $"{"Valid Claim?",-15}" + "\n\n");
            foreach (Claim content in listOfContent)
            {
                DisplayContent(content);
            }
            AnyKey();
        }
        private static void DisplayContent(Claim content)
        {
            Console.WriteLine($"{content.ClaimID,-20}" + $"{content.ClaimType,-20}" + $"{content.Description,-50}" + $"${content.ClaimAmount,-19}" + $"{content.IncidentDate.ToString("MM/dd/yyyy"),-20}" + $"{content.ClaimDate.ToString("MM/dd/yyyy"),-20}" + $"{content.IsValid,-15}\n\n");
        }
        private static void CreateNewItem()
        {
            Console.Clear();
            Claim content = new Claim();
            Console.WriteLine("Please enter Claim ID: \n");
            content.ClaimID = int.Parse(Console.ReadLine());
            Console.WriteLine("Please select a Claim type:\n" + "01. Car\n" + "02. Home\n" + "03. Theft\n");
            switch (Console.ReadLine())
            {
                case "1":
                    content.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    content.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    content.ClaimType = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Invalid claim type.");
                    break;
            }
            Console.WriteLine("Please enter a Description: \n");
            content.Description = Console.ReadLine();
            Console.WriteLine("Please enter the Claim Amount: \n");
            content.ClaimAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Date of the Incident (MM/DD/YYYY): \n");
            content.IncidentDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Date of the Claim (MM/DD/YYYY): \n");
            content.ClaimDate = DateTime.Parse(Console.ReadLine());
            if (_claimRepository.AddContentToDirectory(content))
            {
                Console.WriteLine("Claim added!");
                AnyKey();
            }
            else
            {
                Console.WriteLine("Claim wasn't added!");
                AnyKey();
            }
        }
        private static void RemoveClaim()
        {
            Console.Clear();
            Console.WriteLine($"{"Claim ID:",-20}" + $"{"Claim Type:",-20}" + $"{"Description:",-50}" + $"{"Claim Amount:",-20}" + $"{"Incident Date:",-20}" + $"{"Claim Date:",-20}" + $"{"Valid Claim?",-15}" + "\n\n");
            List<Claim> currentContent = _claimRepository.GetContents();
            var firstClaim = currentContent[0];
            DisplayContent(firstClaim);
            Console.WriteLine("Do you want to deal with this claim now (y/n)?");
            char answer = Console.ReadKey().KeyChar;
            if (answer == 'y' || answer == 'Y')
            {
                Claim movedContent = currentContent[0];
                currentContent.RemoveAt(0);
                Console.WriteLine("\nClaim was removed from list.");
                AnyKey();
            }
            else if (answer == 'n' || answer == 'N')
            {
                AnyKey();
            }
            else
            {
                Console.WriteLine("\nPlease enter y or n.");
            }
        }
        private static void AnyKey()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
