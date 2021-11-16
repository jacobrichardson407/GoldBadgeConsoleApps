using KomodoClaims.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoClaimsRepository_Tests
{
    [TestClass]
    public class ClaimsRepo_Tests
    {
        [TestMethod]
        public void AddToDirectory_ShouldAddContentToDirectory()
        {
            Claim content = new Claim();
            ClaimRepository repository = new ClaimRepository();
            bool addResult = repository.AddContentToDirectory(content);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetAllContents_ShouldGetAllContents()
        {
            Claim content = new Claim();
            ClaimRepository repo = new ClaimRepository();
            repo.AddContentToDirectory(content);
            List<Claim> contents = repo.GetContents();
            bool directoryHasContent = contents.Contains(content);
            Assert.IsTrue(directoryHasContent);
        }
        private Claim _claim1;
        private Claim _claim2;
        private Claim _claim3;
        private ClaimRepository _claimDirectory;
        [TestInitialize]
        public void Arrange()
        {
            _claimDirectory = new ClaimRepository();
            _claim1 = new Claim(1001, ClaimType.Car, "Rear-ended in traffic.", 350.58d, new DateTime(2021, 10, 23), new DateTime(2021, 11, 13));
            _claim2 = new Claim(1002, ClaimType.Home, "Basement flooded due to backed-up sewage line.", 5027.32d, new DateTime(2021, 10, 20), new DateTime(2021, 10, 22));
            _claim3 = new Claim(1003, ClaimType.Theft, "Robbed for gold wedding band.", 755.79d, new DateTime(2021, 08, 25), new DateTime(2021, 11, 2));
            _claimDirectory.AddContentToDirectory(_claim1);
            _claimDirectory.AddContentToDirectory(_claim2);
            _claimDirectory.AddContentToDirectory(_claim3);
        }
        [TestMethod]
        public void DeleteContent_ShouldDeleteContentFromDirectory()
        {
            Claim content = _claimDirectory.GetContentByClaimID(1001);
            bool removeResult = _claimDirectory.DeleteExistingContent(content);
            Assert.IsTrue(removeResult);
        }
        [TestMethod]
        public void GetContentsByClaimID_ShouldReturnCorrectContent()
        {
            Claim foundContent = _claimDirectory.GetContentByClaimID(1003);
            Assert.AreEqual(_claim3, foundContent);
        }
    }
}
