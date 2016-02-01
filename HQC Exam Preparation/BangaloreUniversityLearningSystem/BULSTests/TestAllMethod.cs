namespace BULS.Tests
{
    using System.Text;

    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Enums;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Views;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestAllMethod
    {
        private CoursesController testController;

        private IBangaloreUniversityDate testData;

        private User testUser;

        [TestInitialize]
        public void AllInitialization()
        {
            this.testUser = new User("SampleName", "SamplePassword", Role.Lecturer);
            this.testData = new BangaloreUniversityDate();
            this.testController = new CoursesController(this.testData,
                this.testUser);
        }

        [TestMethod]
        public void AllShould_Return_CertainMessageWhenThereAre_NoPresentCourses()
        {
            var expectedMessage = "No courses.";
            var actualValue = this.testController.All().Display();

            Assert.AreEqual(expectedMessage, actualValue);
        }

        [TestMethod]
        public void TestAll_ShouldDisplayInCorrectFormat()
        {
            this.testController.Create("High Quality Code");
            this.testController.Create("Java-Basics");
            this.testController.Enroll(1);
            this.testController.Enroll(2);

            StringBuilder expected = new StringBuilder();
            expected.AppendFormat("All courses:")
                .AppendLine()
                .Append("High Quality Code (1 students)")
                .AppendLine()
                .Append("Java-Basics (1 students)");

            var actualValue = this.testController.All().Display();

            Assert.AreEqual(expected.ToString(), actualValue);
        }

        [TestMethod]
        public void TestAll_ShouldDisplayTheCoursesSorted_Alphabetically()
        {
            this.testController.Create("High Quality Code");
            this.testController.Create("Java-Basics");
            this.testController.Create("Advanced C#");
            this.testController.Create("Obect oriented programming");

            this.testController.Enroll(2);
            this.testController.Enroll(4);

            StringBuilder expected = new StringBuilder();
            expected.AppendFormat("All courses:")
                .AppendLine()
                .Append("Advanced C# (0 students)")
                .AppendLine()
                .Append("High Quality Code (0 students)")
                .AppendLine()
                .Append("Java-Basics (1 students)")
                .AppendLine()
                .Append("Obect oriented programming (1 students)");

            var actualValue = this.testController.All().Display();

            Assert.AreEqual(expected.ToString(), actualValue);
        }

        [TestMethod]
        public void TestAll_ShouldDisplayTheCoursesSorted_Alphabetically_ThenInDescending_Order()
        {
            //this.testData.Course.Add(new Course("TestCourse"));
            this.testController.Create("Advanced C#");
            this.testController.Create("Advanced Java");
            this.testController.Enroll(1);

            StringBuilder expected = new StringBuilder();
            expected.AppendFormat("All courses:")
                .AppendLine()
                .Append("Advanced C# (1 students)")
                .AppendLine()
                .Append("Advanced Java (0 students)");

            var actualValue = this.testController.All().Display();

            Assert.AreEqual(expected.ToString(), actualValue);
        }
    }
}
