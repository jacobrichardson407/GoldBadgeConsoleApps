using KomodoCafe.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class ProgramUI
    {
        private static MenuRepository _menuRepository = new MenuRepository();
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            SeedContent();
            Run();
        }
        public static void SeedContent()
        {
            Menu item1 = new Menu(01, "Cheese Burger meal", "A single patty with a slice of American Cheese served on a brioche bun, comes with: onions, ketchup, mustard, dill pickle slices, and a side of fries.", "100% pure Beef patty, brioche bun, pickles, onions, garlic, ketchup, mustard", 4.99d);
            Menu item2 = new Menu(02, "Chicken Sandwich meal", "A crispy chicken patty served on a brioche bun with mayo, tomatoes, lettuce, and a side of fries.", "100% pure white meat chicken, brioche bun, mayonnaise, tomatoes, lettuce,", 3.99d);
            Menu item3 = new Menu(03, "Chicken Tender basket", "A basket of a dozen fried chicken tenders, served with a side of fries and your choice of dipping sauce.", "100% pure white meat chicken, secret blend of breading.", 5.99d);
            _menuRepository.AddContentToDirectory(item1);
            _menuRepository.AddContentToDirectory(item2);
            _menuRepository.AddContentToDirectory(item3);
        }
        public static void Run()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(@"

                         __  __  ______  _   _  _    _ 
                        |  \/  ||  ____|| \ | || |  | |
                        | \  / || |__   |  \| || |  | |
                        | |\/| ||  __|  | . ` || |  | |
                        | |  | || |____ | |\  || |__| |
                        |_|  |_||______||_| \_| \____/ 
                                                       
                                                       
      _____  _____  _____   ______  _____  _______  ____   _____ __     __
     |  __ \|_   _||  __ \ |  ____|/ ____||__   __|/ __ \ |  __ \\ \   / /
     | |  | | | |  | |__) || |__  | |        | |  | |  | || |__) |\ \_/ / 
     | |  | | | |  |  _  / |  __| | |        | |  | |  | ||  _  /  \   /  
     | |__| |_| |_ | | \ \ | |____| |____    | |  | |__| || | \ \   | |   
     |_____/|_____||_|  \_\|______|\_____|   |_|   \____/ |_|  \_\  |_|   
                                                                         
                                                                                            ");
                Console.WriteLine("1. Show all menu items\n" +
                    "2. Add item to menu\n" +
                    "3. Delete item from menu\n" +
                    "4. Exit");
                int userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        ShowAllContent();
                        break;
                    case 2:
                        CreateNewItem();
                        break;
                    case 3:
                        RemoveContentFromList();
                        break;
                    case 4:
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4!\n" + "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private static void CreateNewItem()
        {
            Console.Clear();
            Menu content = new Menu();
            Console.WriteLine("Please enter Meal Number: \n");
            content.MealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter Meal Name: \n");
            content.MealName = Console.ReadLine();
            Console.WriteLine("Please enter a Meal Description: \n");
            content.MealDescription = Console.ReadLine();
            Console.WriteLine("Please enter the Ingredients: \n");
            content.Ingredients = Console.ReadLine();
            Console.WriteLine("Please enter a Meal Price: \n");
            content.MealPrice = double.Parse(Console.ReadLine());
            if (_menuRepository.AddContentToDirectory(content))
            {
                Console.WriteLine("Content added!");
                AnyKey();
            }
            else
            {
                Console.WriteLine("Content wasn't added!");
                AnyKey();
            }
        }
        private static void ShowAllContent()
        {
            Console.Clear();
            List<Menu> listOfContent = _menuRepository.GetContents();
            foreach (Menu content in listOfContent)
            {
                DisplayContent(content);
            }
            AnyKey();
        }
        private static void DisplayContent(Menu content)
        {
            Console.WriteLine($"Meal Number: {content.MealNumber}\n" + $"Meal Name: {content.MealName}\n" + $"Meal Description: {content.MealDescription}\n" + $"Meal Ingredients: {content.Ingredients}\n" + $"Meal Price: {content.MealPrice}\n");
        }
        private static void RemoveContentFromList()
        {
            Console.Clear();
            Console.WriteLine("Which item would you like to remove? Enter a Meal Number: \n");
            List<Menu> currentContent = _menuRepository.GetContents();
            int count = 0;
            foreach (Menu content in currentContent)
            {
                count++;
                Console.WriteLine($"{count}. {content.MealName}");
            }
            int targetContentId = int.Parse(Console.ReadLine());
            int targetIndex = targetContentId - 1;
            if (targetIndex >= 0 && targetIndex < currentContent.Count)
            {
                Menu desiredContent = currentContent[targetIndex];
                if (_menuRepository.DeleteExistingContent(desiredContent))
                {
                    Console.WriteLine($"{desiredContent.MealNumber} + {desiredContent.MealName} was deleted.");
                    AnyKey();
                }
                else
                {
                    Console.WriteLine("Deletion failed.");
                    AnyKey();
                }
            }
            else
            {
                Console.WriteLine("No content with that ID.");
            }
        }
        private static void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
