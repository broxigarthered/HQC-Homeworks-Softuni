namespace BULS.Tests
{
    using System;

    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Enums;
    using BangaloreUniversityLearningSystem.Exceptions;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestLogoutMethod
    {
        private UsersController testUserController;

        private IBangaloreUniversityDate testData;

        private User testUser;

        [TestInitialize]
        public void LogoutInitialization()
        {
            this.testData = new BangaloreUniversityDate();
            this.testUser = new User("Nikolay", "qwerty00", Role.Lecturer);
            this.testUserController = new UsersController(this.testData, this.testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Logout_ShouldThrowArgumentOutOfRangeException_WhenThereISNoCurrentUserLoggedIn()
        {
            this.testUserController.User = null;
            this.testUserController.Logout();
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void Logout_ShouldThrowAuthorizationFailedException_WhenThe_User_IsNotAuthorizedTo_PErform_CertainOperation()
        {
            User temporalUser = new User("RandomName", "WithRandomPassowrd", Role.Guest);
            this.testUserController.User = temporalUser;
            this.testUserController.HasCurrentUser = false;

            this.testUserController.Logout();
        }

        [TestMethod]
        public void LogoutShould_SuccessfullyLogoutUser()
        {
            User expected = null;

            this.testUserController.Logout();

            Assert.AreEqual(expected, this.testUserController.User);
        }
    }
}
