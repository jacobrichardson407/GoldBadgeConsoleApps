using KomodoCafe.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoCafeRepository_Tests
{
    [TestClass]
    public class MenuRepo_Tests
    {
        [TestMethod]
        public void AddToDirectory_ShouldAddContentToDirectory()
        {
            // Arrange
            Menu content = new Menu();
            MenuRepository repository = new MenuRepository();
            // Act
            bool addResult = repository.AddContentToDirectory(content);
            // Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetAllContents_ShouldGetAllContents()
        {
            Menu content = new Menu();
            MenuRepository repo = new MenuRepository();
            repo.AddContentToDirectory(content);
            List<Menu> contents = repo.GetContents();
            bool directoryHasContent = contents.Contains(content);
            Assert.IsTrue(directoryHasContent);
        }
        private Menu _menuMeal1;
        private Menu _menuMeal2;
        private Menu _menuMeal3;
        private MenuRepository _menuRepository;
        [TestInitialize]
        public void Arrange()
        {
            _menuRepository = new MenuRepository();
            _menuMeal1 = new Menu(01, "Cheese Burger meal", "A single patty with a slice of American Cheese served on a brioche bun, comes with: onions, ketchup, mustard, dill pickle slices, and a side of fries.", "100% pure Beef patty, brioche bun, pickles, onions, garlic, ketchup, mustard", 4.99d);
            _menuMeal2 = new Menu(02, "Chicken Sandwich meal", "A crispy chicken patty served on a brioche bun with mayo, tomatoes, lettuce, and a side of fries.", "100% pure white meat chicken, brioche bun, mayonnaise, tomatoes, lettuce,", 3.99d);
            _menuMeal3 = new Menu(03, "Chicken Tender basket", "A basket of a dozen fried chicken tenders, served with a side of fries and your choice of dipping sauce.", "100% pure white meat chicken, secret blend of breading.", 5.99d);
            _menuRepository.AddContentToDirectory(_menuMeal1);
            _menuRepository.AddContentToDirectory(_menuMeal2);
            _menuRepository.AddContentToDirectory(_menuMeal3);
        }
        [TestMethod]
        public void DeleteContent_ShouldDeleteContentFromDirectory()
        {
            Menu content = _menuRepository.GetContentByMealNumber(01);
            bool removeResult = _menuRepository.DeleteExistingContent(content);
            Assert.IsTrue(removeResult);
        }
        [TestMethod]
        public void GetContentsByMealNumber_ShouldReturnCorrectContent()
        {
            Menu foundContent = _menuRepository.GetContentByMealNumber(02);
            Assert.AreEqual(_menuMeal2, foundContent);
        }
    }
}
