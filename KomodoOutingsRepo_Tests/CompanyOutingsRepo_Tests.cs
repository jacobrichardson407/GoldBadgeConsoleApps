using KomodoCompanyOutings.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoOutingsRepo_Tests
{
    [TestClass]
    public class CompanyOutingsRepo_Tests
    {
        public Outing content = new Outing();
        public CompanyOutingsRepository repo = new CompanyOutingsRepository();
        [TestMethod]
        public void AddToDirectory_ShouldAddContentToDirectory()
        {
            bool addResult = repo.AddContentToDirectory(content);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetAllContents_ShouldGetAllContents()
        {

            repo.AddContentToDirectory(content);
            List<Outing> contents = repo.GetContents();
            bool directoryHasContent = contents.Contains(content);
            Assert.IsTrue(directoryHasContent);
        }
        private Outing _item1;
        private Outing _item2;
        private Outing _item3;
        private Outing _item4;
        [TestInitialize]
        public void Arrange()
        {
            _item1 = new Outing(EventType.Bowling, 7, new DateTime(2021, 11, 15), 107.42d);
            _item2 = new Outing(EventType.Golf, 10, new DateTime(2021, 05, 04), 570.16d);
            _item3 = new Outing(EventType.AmusementPark, 25, new DateTime(2021, 08, 25), 3405.74d);
            _item4 = new Outing(EventType.Golf, 5, new DateTime(2021, 07, 06), 200.14d);

            repo.AddContentToDirectory(_item1);
            repo.AddContentToDirectory(_item2);
            repo.AddContentToDirectory(_item3);
            repo.AddContentToDirectory(_item4);
        }
        [TestMethod]
        public void GetContentsByEventType_ShouldReturnAllOutingsOfSameEvent()
        {
            Outing foundContent = repo.GetContentByEventType(EventType.AmusementPark.ToString());
            Assert.AreEqual(_item3, foundContent);
        }
        [TestMethod]
        public void GetTotalCost_ShouldReturnSumOfAllTotalCost()
        {
            double expected = _item1.TotalCost + _item2.TotalCost + _item3.TotalCost + _item4.TotalCost;
            double actual = repo.GetTotalCost();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetTotalCostByEvent_ShouldReturnSumOfAllTotalCostByEventType()
        {
            double expected = _item2.TotalCost + _item4.TotalCost;
            double actual = repo.GetTotalCostByEvent(content.EventType);
            Assert.AreEqual(expected, actual);
        }
    }
}
