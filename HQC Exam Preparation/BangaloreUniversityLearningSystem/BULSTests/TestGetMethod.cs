namespace BULS.Tests
{
    using System;

    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestGetMethod
    {
        private IRepository<string> testRepository;

        private Type item;

        [TestInitialize]
        public void TestInitialization()
        {
            this.testRepository = new Repository<string>();
        }

        [TestMethod]
        public void GetShould_ReturnNull_IfTheItem_Is_NotExisting_InTheList()
        {
            int sampleID = 3;
            Type expected = null;

            var returnedValue = this.testRepository.Get(sampleID);

            Assert.AreSame(expected, returnedValue);
        }

        [TestMethod]
        public void Get_Should_ReturnCertainItem_WhenTheItem_Id_ExistsInTheList()
        {
            int sampleID = 3;
            var expectedValue = "dubiozaKolektiv";

            this.testRepository.Add("ko4e");
            this.testRepository.Add("rakiq");
            this.testRepository.Add("dubiozaKolektiv");
            var returnedValue = this.testRepository.Get(sampleID);

            Assert.AreSame(expectedValue, returnedValue);
        }
    }
}
