namespace BangaloreUniversityLearningSystem.Views {
    using System.Text;

    using Infrastructure;
    using Models;

    public class Create : View
    {
        private Course currentCourse;

        public Create(Course course)
            : base(course)
        {
            this.currentCourse = course;
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            // var course = this.currentCourse as Course;
            viewResult.AppendFormat("Course {0} created successfully.", this.currentCourse.Name).AppendLine();
        }
    }
}
