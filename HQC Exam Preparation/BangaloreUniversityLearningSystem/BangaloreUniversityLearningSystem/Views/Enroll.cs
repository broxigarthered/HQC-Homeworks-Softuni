namespace BangaloreUniversityLearningSystem.Views
{
    using System.Text;

    using Infrastructure;
    using Models;

    public class Enroll : View
    {
        private Course currentCourse;

        public Enroll(Course course)
            : base(course)
        {
            this.currentCourse = course;
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("Student successfully enrolled in course {0}.", this.currentCourse.Name).AppendLine();
        }
    }
}
