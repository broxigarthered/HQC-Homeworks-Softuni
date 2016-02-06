namespace ChepelareBookingSystem.Tests
{
    using System.Text;

    using ChepelareHotelBookingSystem.Controllers;
    using ChepelareHotelBookingSystem.Data;
    using ChepelareHotelBookingSystem.Enums;
    using ChepelareHotelBookingSystem.Infrastructure;
    using ChepelareHotelBookingSystem.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class VenuesAllMethodTests
    {
        private VenuesController sampleController;
        private HotelBookingSystemData sampleData;

        private User sampleUser;

        [TestInitialize]
        public void SetUp()
        {
            this.sampleData = new HotelBookingSystemData();
            this.sampleUser = new User("SampleName", "SamplePassword", Roles.VenueAdmin);
            this.sampleController = new VenuesController(this.sampleData, this.sampleUser);
        }

        [TestMethod]
        public void All_ShouldReturnProperMessage_InCaseOfNoVenuesTo_Show()
        {
            var expected = "There are currently no venues to show.";
            var actual = this.sampleController.All().Display();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void All_ShouldReturnVenues_OrderedInWay_Of_TheirAddition()
        {
            var venue = new Venue("SampleVenue", "SampleAddress", "NotThatInteresting", this.sampleUser);
            var secondVenue = new Venue("SampleVenueTwo", "SampleAddressTwo", "NotTatInterestnig", this.sampleUser);
            var sampleStringBuilder = new StringBuilder();

            this.sampleController.Add("SampleVenue", "SampleAddress", "NotThatInteresting");
            this.sampleController.Add("SampleVenueTwo", "SampleAddressTwo", "NotTatInterestnig");
            sampleStringBuilder.AppendFormat("*[1] {0}, located at {1}", venue.Name, venue.Address)
                .AppendLine()
                .AppendFormat("Free rooms: {0}", venue.Rooms.Count)
                .AppendLine();
            sampleStringBuilder.AppendFormat("*[2] {0}, located at {1}", secondVenue.Name, secondVenue.Address)
                .AppendLine()
                .AppendFormat("Free rooms: {0}", secondVenue.Rooms.Count);

            var expected = sampleStringBuilder.ToString();
            var actual = this.sampleController.All().Display();

            Assert.AreEqual(expected, actual);
        }
    }
}
