namespace ChepelareBookingSystem.Tests
{
    using System;

    using ChepelareHotelBookingSystem.Controllers;
    using ChepelareHotelBookingSystem.Data;
    using ChepelareHotelBookingSystem.Enums;
    using ChepelareHotelBookingSystem.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UsersLogoutMethodTests
    {
        private UsersController testController;

        private HotelBookingSystemData testData;

        private User testUser;

        [TestInitialize]
        public void SetUp()
        {
            this.testData = new HotelBookingSystemData();
            this.testUser = new User("SampleName", "Samplepassword", Roles.User);
            this.testController = new UsersController(this.testData, this.testUser);
        }

        [TestMethod]
        public void LogoutShould_ChangeTheCurrentUser_ToNull_WhenSuccessfully_LoggedOut()
        {
            this.testController.Logout();
            Assert.IsNull(this.testController.CurrentUser);
        }

        [TestMethod]
        public void LogoutShould_ReturnProperMessageIfTheCurrentUser_IsSuccessfullyLoggedOut()
        {
            var expected = "The user SampleName has logged out.";

            this.testController.Register(
                this.testUser.Username,
                this.testUser.PasswordHash,
                this.testUser.PasswordHash,
                this.testUser.Role.ToString());
           var actual = this.testController.Logout();

            Assert.AreEqual(expected, actual.Display());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnAuthorizedUserCannotLogout()
        {
            var data = new HotelBookingSystemData();
            var controller = new UsersController(data, null);

            controller.Logout();
        }
    }
}
