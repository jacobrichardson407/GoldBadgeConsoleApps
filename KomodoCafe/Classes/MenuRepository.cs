using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe.Classes
{
    public class MenuRepository
    {
        protected readonly List<Menu> _menuDirectory = new List<Menu>();

        // CRUD basic necessities of repository pattern


        // Create
        public bool AddContentToDirectory(Menu content)
        {
            int startingCount = _menuDirectory.Count;
            _menuDirectory.Add(content);

            bool wasAdded = (_menuDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        // Read
        // Get all
        public List<Menu> GetContents()
        {
            return _menuDirectory;
        }

        // Get single
        public Menu GetContentByMealNumber(int number)
        {
            foreach (Menu content in _menuDirectory)
            {
                if (content.MealNumber == number)
                {
                    return content;
                }
            }
            return null;
        }


        // Delete
        public bool DeleteExistingContent(Menu existingContent)
        {
            bool deleteResult = _menuDirectory.Remove(existingContent);
            return deleteResult;
        }

        // Challenge, make these repo methods and test them

        // Delete By Content Title
        public bool DeleteExistingContentByMealNumber(int number)
        {
            return DeleteExistingContent(GetContentByMealNumber(number));
        }


        }
    }
