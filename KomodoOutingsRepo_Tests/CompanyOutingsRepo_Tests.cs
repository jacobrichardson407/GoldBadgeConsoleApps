using KomodoCompanyOutings.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoOutingsRepo_Tests
{
    [TestClass]
    public class CompanyOutingsRepo_Tests
    {
        [TestMethod]
        public void AddToDirectory_ShouldAddContentToDirectory()
        {
            Outing content = new Outing();
            CompanyOutingsRepository repository = new CompanyOutingsRepository();
            bool addResult = repository.AddContentToDirectory(content);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetAllContents_ShouldGetAllContents()
        {
            Outing content = new Outing();
            CompanyOutingsRepository repo = new CompanyOutingsRepository();
            repo.AddContentToDirectory(content);
            List<Outing> contents = repo.GetContents();
            bool directoryHasContent = contents.Contains(content);
            Assert.IsTrue(directoryHasContent);
        }
        private Outing _claim1;
        private Outing _claim2;
        private Outing _claim3;
        private CompanyOutingsRepository _outingDirectory;
        [TestInitialize]
        public void Arrange()
        {
            _outingDirectory = new CompanyOutingsRepository();
            _claim1 = new Outing(EventType.Bowling, 7, new DateTime(2021, 11, 15), 107.42d);
            _claim2 = new Outing(EventType.Golf, 10, new DateTime(2021, 05, 04), 570.16d);
            _claim3 = new Outing(EventType.AmusementPark, 25, new DateTime(2021, 08, 25), 3405.74d);

            _outingDirectory.AddContentToDirectory(_claim1);
            _outingDirectory.AddContentToDirectory(_claim2);
            _outingDirectory.AddContentToDirectory(_claim3);
        }
        [TestMethod]
        public void GetContentsByEventType_ShouldReturnAllOutingsOfSameEvent()
        {
            Outing foundContent = _outingDirectory.GetContentByEventType(EventType.AmusementPark.ToString());
            Assert.AreEqual(_claim3, foundContent);
        }
    }
}
