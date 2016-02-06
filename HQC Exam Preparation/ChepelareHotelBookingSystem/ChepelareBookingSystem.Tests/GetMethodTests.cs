namespace ChepelareBookingSystem.Tests
{
    using ChepelareHotelBookingSystem.Data;
    using ChepelareHotelBookingSystem.Enums;
    using ChepelareHotelBookingSystem.Interfaces;
    using ChepelareHotelBookingSystem.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetMethodTests
    {
        private IRepository<Venue> testRepository;

        [TestInitialize]
        public void InitializeGetMethod()
        {
            this.testRepository = new Repository<Venue>();
        }

        [TestMethod]
        public void GetShould_ReturnNull_WhenTheItem_IsNotPresent()
        {
            int randomIntegerNumber = 3;
            var actualValue = this.testRepository.Get(randomIntegerNumber);

            Assert.IsNull(actualValue);
        }

        [TestMethod]
        public void GetShould_Return_A_Proper_Item_WhenThe_Id_IsPresent()
        {
            User sampleUser = new User("OMGAuser", "qwertyyy", Roles.User);
            Venue sampleVenue = new Venue("SampleName", "SampleAdress", "SampleDescription", sampleUser);
            Venue sampleVenue2 = new Venue("SampleName2", "SampleAdress", "SampleDescription", sampleUser);
            Venue sampleVenue3 = new Venue("SampleName3", "SampleAdress", "SampleDescription", sampleUser);
            Venue sampleVenue4 = new Venue("SampleName4", "SampleAdress", "SampleDescription", sampleUser);
            var actual = "SampleName3";

            this.testRepository.Add(sampleVenue);
            this.testRepository.Add(sampleVenue2);
            this.testRepository.Add(sampleVenue3);
            this.testRepository.Add(sampleVenue4);
            var expected = this.testRepository.Get(3).Name;


            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetShould_ReturnNull_WhenIncorrectId_IsGiven()
        {
            User sampleUser = new User("OMGAuser", "qwertyyy", Roles.User);
            Venue sampleVenue = new Venue("SampleName", "SampleAdress", "SampleDescription", sampleUser);
            Venue sampleVenue2 = new Venue("SampleName3", "SampleAdress", "SampleDescription", sampleUser);

            this.testRepository.Add(sampleVenue);
            this.testRepository.Add(sampleVenue2);

            Assert.IsNull(this.testRepository.Get(3));
        }
    }
}
