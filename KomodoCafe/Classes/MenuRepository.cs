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
        public bool AddContentToDirectory(Menu content)
        {
            int startingCount = _menuDirectory.Count;
            _menuDirectory.Add(content);

            bool wasAdded = (_menuDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<Menu> GetContents()
        {
            return _menuDirectory;
        }
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
        public bool DeleteExistingContent(Menu existingContent)
        {
            bool deleteResult = _menuDirectory.Remove(existingContent);
            return deleteResult;
        }
        public bool DeleteExistingContentByMealNumber(int number)
        {
            return DeleteExistingContent(GetContentByMealNumber(number));
        }
    }
}