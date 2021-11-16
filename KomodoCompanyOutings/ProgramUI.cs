using KomodoCompanyOutings.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCompanyOutings
{
    public class ProgramUI
    {
        private static CompanyOutingsRepository _outingRepository = new CompanyOutingsRepository();
        private static Outing _outing = new Outing();

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            SeedContent();
            Run();
        }

        private static void Run()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(@"

  ____   _    _  _______  _____  _   _   _____   _____ 
 / __ \ | |  | ||__   __||_   _|| \ | | / ____| / ____|
| |  | || |  | |   | |     | |  |  \| || |  __ | (___  
| |  | || |  | |   | |     | |  | . ` || | |_ | \___ \ 
| |__| || |__| |   | |    _| |_ | |\  || |__| | ____) |
 \____/  \____/    |_|   |_____||_| \_| \_____||_____/ 
                                                       
                                                       ");
                Console.WriteLine("1. See all outings\n" +
                    "2. Add a new outing\n" +
                    "3. Total Cost by event type\n" +
                    "4. Exit");
                int userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 01:
                        ShowAllContent();
                        break;
                    case 02:
                        CreateNewItem();
                        break;
                    case 03:
                        ShowContentByEventType();
                        break;
                    case 04:
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4!\n");
                        AnyKey();
                        break;
                }
            }
        }
        private static void SeedContent()
        {
            Outing item1 = new Outing(EventType.Bowling, 7, new DateTime(2021, 11, 15), 107.42d);
            Outing item2 = new Outing(EventType.Golf, 10, new DateTime(2021, 05, 04), 570.16d);
            Outing item3 = new Outing(EventType.AmusementPark, 25, new DateTime(2021, 08, 25), 3405.74d);
            Outing item4 = new Outing(EventType.Concert, 8, new DateTime(2021, 06, 17), 625.15d);
            Outing item5 = new Outing(EventType.Golf, 12, new DateTime(2021, 06, 04), 672.62d);
            Outing item6 = new Outing(EventType.Golf, 9, new DateTime(2021, 07, 06), 516.89d);
            Outing item7 = new Outing(EventType.Bowling, 5, new DateTime(2021, 10, 06), 75.51d);
            Outing item8 = new Outing(EventType.Bowling, 9, new DateTime(2021, 11, 01), 157.63d);
            Outing item9 = new Outing(EventType.AmusementPark, 18, new DateTime(2021, 05, 25), 2468.11d);
            Outing item10 = new Outing(EventType.Concert, 14, new DateTime(2021, 08, 05), 1023.45);
            _outingRepository.AddContentToDirectory(item1);
            _outingRepository.AddContentToDirectory(item2);
            _outingRepository.AddContentToDirectory(item3);
            _outingRepository.AddContentToDirectory(item4);
            _outingRepository.AddContentToDirectory(item5);
            _outingRepository.AddContentToDirectory(item6);
            _outingRepository.AddContentToDirectory(item7);
            _outingRepository.AddContentToDirectory(item8);
            _outingRepository.AddContentToDirectory(item9);
            _outingRepository.AddContentToDirectory(item10);
        }
        private static void ShowAllContent()
        {
            Console.Clear();
            List<Outing> listOfContent = _outingRepository.GetContents();
            Console.WriteLine($"{"Event Type:",-20}" + $"{"Attendance:",-20}" + $"{"Date:",-20}" + $"{"Total Cost:",-20}" + $"{"Cost Per Person:",-20}\n\n");
            foreach (Outing content in listOfContent)
            {
                DisplayContent(content);
            }
            Console.WriteLine($"\n\nTotal Cost: {TotalCostOfOutings().ToString("C2"),-20}");
            AnyKey();
        }
        private static void DisplayContent(Outing content)
        {
            Console.WriteLine($"{content.EventType,-20}" + $"{content.Attendance,-20}" + $"{content.EventDate.ToString("MM/dd/yyyy"),-20}" + $"{content.TotalCost.ToString("C2"),-20}" + $"{Math.Round(content.CostPerPerson, 2).ToString("C2"),-19}");
        }
        private static void CreateNewItem()
        {
            Console.Clear();
            Outing content = new Outing();
            Console.WriteLine("Please select an Event Type: \n");
            Console.WriteLine("1. Golf\n" +
    "2. Bowling\n" +
    "3. Amusement Park\n" +
    "4. Concert\n");
            switch (Console.ReadLine())
            {
                case "1":
                    content.EventType = EventType.Golf;
                    break;
                case "2":
                    content.EventType = EventType.Bowling;
                    break;
                case "3":
                    content.EventType = EventType.AmusementPark;
                    break;
                case "4":
                    content.EventType = EventType.Concert;
                    break;
                default:
                    Console.WriteLine("Invalid event type.");
                    break;
            }
            Console.WriteLine("Please enter the Attendance: \n");
            content.Attendance = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Outing Date (MM/DD/YYYY): \n");
            content.EventDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Total Cost of the event: \n");
            content.TotalCost = double.Parse(Console.ReadLine());
            if (_outingRepository.AddContentToDirectory(content))
            {
                Console.WriteLine("Outing added!");
                AnyKey();
            }
            else
            {
                Console.WriteLine("Outing wasn't added!");
                AnyKey();
            }
        }
        private static void ShowContentByEventType()
        {
            Console.Clear();
            Outing content = new Outing();
            _outingRepository.GetContentByEventType(content.ToString());
            Console.WriteLine("Please select an Event Type: \n");
            Console.WriteLine("1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n");
            var totalCost = 0.0d;
            switch (Console.ReadLine())
            {
                case "1":
                    content.EventType = EventType.Golf;
                    totalCost = _outingRepository.GetTotalCostByEvent(content.EventType);
                    Console.WriteLine($"Total Cost of Golf Outings: {totalCost.ToString("C2"),-20}");
                    break;
                case "2":
                    content.EventType = EventType.Bowling;
                    totalCost = _outingRepository.GetTotalCostByEvent(content.EventType);
                    Console.WriteLine($"Total Cost of Bowling Outings: {totalCost.ToString("C2"),-20}");
                    break;
                case "3":
                    content.EventType = EventType.AmusementPark;
                    totalCost = _outingRepository.GetTotalCostByEvent(content.EventType);
                    Console.WriteLine($"Total Cost of Amusement Park Outings: {totalCost.ToString("C2"),-20}");
                    break;
                case "4":
                    content.EventType = EventType.Concert;
                    totalCost = _outingRepository.GetTotalCostByEvent(content.EventType);
                    Console.WriteLine($"Total Cost of Concert Outings: {totalCost.ToString("C2"),-20}");
                    break;
                default:
                    Console.WriteLine("Invalid event type.");
                    break;
            }
            AnyKey();
        }
        private static double TotalCostOfOutings()
        {
            double total = _outingRepository.GetTotalCost();
            return total;
        }
        private static void AnyKey()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
