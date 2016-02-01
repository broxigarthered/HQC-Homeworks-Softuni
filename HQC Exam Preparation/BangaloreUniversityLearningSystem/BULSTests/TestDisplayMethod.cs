namespace BULS.Tests
{
    using System.Text;

    using BangaloreUniversityLearningSystem.Enums;
    using BangaloreUniversityLearningSystem.Infrastructure;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Views;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestDisplayMethod
    {
        private View testView;

        private User testUser;

        [TestInitialize]
        public void DisplayInitialization()
        {
            this.testUser = new User("Pesheto", "1234566", Role.Student);
            this.testView = new Logout(this.testUser);
        }

        [TestMethod]
        public void BuildViewResultShould_BeTheSame_ModifyGiven_StringBuilderProperly()
        {
            StringBuilder testStringBuilder = new StringBuilder();
            StringBuilder expectedBuilder = new StringBuilder();

            expectedBuilder.AppendFormat("User {0} logged out successfully.", this.testUser.Username)
                .AppendLine();
            this.testView.BuildViewResult(testStringBuilder);

            Assert.AreEqual(expectedBuilder.ToString(), testStringBuilder.ToString());
        }
    }
}
