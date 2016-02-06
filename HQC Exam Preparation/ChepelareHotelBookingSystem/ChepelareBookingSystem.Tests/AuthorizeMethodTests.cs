namespace ChepelareBookingSystem.Tests
{
    using System;

    using ChepelareHotelBookingSystem.Controllers;
    using ChepelareHotelBookingSystem.Data;
    using ChepelareHotelBookingSystem.Enums;
    using ChepelareHotelBookingSystem.Identity;
    using ChepelareHotelBookingSystem.Interfaces;
    using ChepelareHotelBookingSystem.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AuthorizeMethodTests
    {
        private RoomsController roomsControllerSample;

        private IHotelBookingSystemData dataSample;

        private User userSample;

        [TestInitialize]
        public void SetUp()
        {
            this.dataSample = new HotelBookingSystemData();
            this.userSample = new User("Peshoo", "qwerty11", Roles.VenueAdmin);
            this.roomsControllerSample = new RoomsController(this.dataSample, this.userSample);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AuthorizeShould_ThrowArgumentException_IfThereIsnt_CurrentlyLoggedUser()
        {
            var sampleRoomsController = new RoomsController(this.dataSample, null);
            sampleRoomsController.Add(12, 12, 33.55m);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void AuthorizeShouldThrowAuthorizaion_FailedException_IfTheUser_IsNotInRole()
        {
            var sampleUser = new User("Peshoo", "qwerty11", Roles.User);
            var sampleRoomsController = new RoomsController(this.dataSample, sampleUser);

            sampleRoomsController.Add(12, 12, 33.55m);
        }

        [TestMethod]
        public void AuthorizeShould_BePassed_AddMethod_ShouldThrowNotFound()
        {
            var returnedValue = this.roomsControllerSample.Add(1, 2, 3m);

            Assert.IsNotNull(returnedValue);
        }
    }
}
