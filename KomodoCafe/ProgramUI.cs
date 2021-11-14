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
                Console.WriteLine("Welcome to the menu directory!");
                Console.WriteLine("01. Show all menu items\n" +
                    "02. Add item to menu\n" +
                    "03. Delete item from menu\n");
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
                        RemoveContentFromList();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5!\n" + "Press any key to continue...");
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
                // Increment counter to display
                count++;
                Console.WriteLine($"{count}. {content.MealNumber}. {content.MealName}");
            }
            // Ask for number, take one off so it matches it's index (index starts at 0)
            int targetContentId = int.Parse(Console.ReadLine());
            int targetIndex = targetContentId - 1;
            if (targetIndex >= 0 && targetIndex < currentContent.Count)
            {
                // Get that content from that index location
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
